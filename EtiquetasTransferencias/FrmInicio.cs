using EscoBLLCore;
using EtiquetasTransferencias.EtiquetasModels;
using PdfiumViewer;
using System.Drawing.Printing;
using System.Globalization;
using System.Net;
using System.Text;

namespace EtiquetasTransferencias
{
    public partial class FrmInicio : Form
    {
        public class ProdEtiqEsta
        {
            public string? ProductoCodigo { get; set; }
            public string? ProductoDescripcion { get; set; }
            public decimal? Cantidad { get; set; }
            public string? Estado { get; set; }
            public string? CodigoEtiqueta { get; set; }
        }
        private producto? Producto { get; set; }
        private string Zpl { get; } = Properties.Settings.Default.ZplEtiqueta;
        public FrmInicio()
        {
            InitializeComponent();
        }

        #region Eventos
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            using var db = new ESCORIALContext();
            Producto = 
                db
                .producto
                .FirstOrDefault(x => 
                    x.codigo.Contains(TxtCodigoProducto.Text)
                );
            if (Producto == null)
            {
                MostrarError("No se encontró el código de producto.");
                Producto = new producto();
                return;
            }
            LblProducto.Text = $"{Producto.codigo} - {Producto.descripcion}";
        }
        private void FrmInicio_Load(object sender, EventArgs e)
        {
            DgvEtiquetas.DataSource = ObtenerEtiquetas();
            CmbFormato.SelectedIndex = 0;
            IniciarEstados();
            IniciarImpresoras();
        }
        private void BtnDeshabilitar_Click(object sender, EventArgs e)
        {
            CambiarEstadoEtiqueta(6, "Etiqueta deshabilitada correctamente");
        }
        private void BtnHabilitar_Click(object sender, EventArgs e)
        {
            CambiarEstadoEtiqueta(5, "Etiqueta habilitada correctamente");
        }
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.Impresora))
            {
                MostrarError("Se debe seleccionar una impresora.");
                return;
            }
            if (Producto == null || string.IsNullOrEmpty(Producto.codigo))
            {
                MostrarError("No se seleccionó un producto.");
                return;
            }
            if (string.IsNullOrEmpty(TxtCantidad.Text))
            {
                MostrarError("Se debe ingresar cantidad de unidades.");
                return;
            }
            if (CmbFormato.SelectedItem is null)
            {
                MostrarError("Se debe seleccionar un formato");
                return;
            }
            var nuevoCodigo = ObtenerNumeroUnicoEtiqueta();
            var zpl = ObtenerZpl(Producto.descripcion, Producto.codigo, TxtCantidad.Text, nuevoCodigo);
            var formato = CmbFormato.Items[CmbFormato.SelectedIndex]!.ToString();
            var isPrinted = Imprimir(zpl, formato!);
            if (!isPrinted)
            {
                MostrarError("Se produjo un error durante la impresión o se canceló la misma.");
                return;
            }
            var nuevaEtiqueta = new EscoTxEtiqueta
            {
                cantidad = decimal.Parse(TxtCantidad.Text),
                codigo = nuevoCodigo,
                estado_id = 5,
                fecha = DateTime.Now,
                producto_id = Producto.id
            };
            using var db = new ESCORIALContext();
            db.EscoTxEtiqueta.Add(nuevaEtiqueta);
            db.SaveChanges();
            DgvEtiquetas.DataSource = ObtenerEtiquetas();
        }
        private void BtnReimprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.Impresora))
            {
                MostrarError("Se debe seleccionar una impresora.");
                return;
            }
            if (DgvEtiquetas.SelectedRows.Count == 0)
            {
                MostrarError("Error en fila seleccionada.");
                return;
            }
            var filaSeleccionada = DgvEtiquetas.SelectedRows[0];
            var estadoValue = filaSeleccionada.Cells[3].Value?.ToString();
            if (estadoValue != null && !estadoValue.Equals("Activo"))
            {
                MostrarError("No se puede imprimir una etiqueta inactiva.");
                return;
            }
            var zpl = ObtenerZpl(
                filaSeleccionada.Cells[1].Value?.ToString(),
                filaSeleccionada.Cells[0].Value?.ToString(),
                filaSeleccionada.Cells[2].Value?.ToString(),
                filaSeleccionada.Cells[4].Value?.ToString()
            );
            var formato = CmbFormato.Items[CmbFormato.SelectedIndex]!.ToString();
            var isPrinted = Imprimir(zpl, formato!);
            if (!isPrinted)
            {
                MostrarError("Se produjo un error durante la impresión o se canceló la misma.");
                return;
            }
        }
        private void BtnFiltrosBuscar_Click(object sender, EventArgs e)
        {
            string estado = CmbFiltroEstado.SelectedValue?.ToString() ?? string.Empty;
            DgvEtiquetas.DataSource = ObtenerEtiquetas()
                .Where(x =>
                    (x.ProductoCodigo ?? string.Empty).Contains(TxtFiltroCodigoProducto.Text ?? string.Empty) &&
                    (x.ProductoDescripcion ?? string.Empty).Contains(TxtFiltroDescripcion.Text ?? string.Empty) &&
                    (x.CodigoEtiqueta ?? string.Empty).Contains(TxtFiltroCodigoEtiqueta.Text ?? string.Empty) &&
                    (estado == "Todos" || (x.Estado ?? string.Empty).Contains(estado ?? string.Empty))
                )
                .ToList();
        }
        private void CmbImpresora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbImpresora.SelectedItem != null)
            {
                Properties.Settings.Default.Impresora = CmbImpresora.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        #region Funciones
        private static List<ProdEtiqEsta> ObtenerEtiquetas()
        {
            using var db = new ESCORIALContext();
            return
                db
                .producto
                .Join(
                    db.EscoTxEtiqueta,
                    producto => producto.id,
                    etiqueta => etiqueta.producto_id,
                    (producto, etiqueta) => new
                    {
                        producto,
                        etiqueta
                    }
                )
                .Join(
                    db.EscoTxEstado,
                    pe => pe.etiqueta.estado_id,
                    estado => estado.id,
                    (pe, estado) => new ProdEtiqEsta
                    {
                        ProductoCodigo = pe.producto.codigo,
                        ProductoDescripcion = pe.producto.descripcion,
                        Cantidad = pe.etiqueta.cantidad,
                        Estado = estado.descripcion,
                        CodigoEtiqueta = pe.etiqueta.codigo
                    }
                )
                .OrderBy(
                    x => x.CodigoEtiqueta
                )
                .ToList();
        }
        private void IniciarEstados()
        {
            using var db = new ESCORIALContext();
            var estados = db.EscoTxEstado.ToList();
            estados.Add(new EscoTxEstado { id = 0, descripcion = "Todos", codigo = "TOD" });
            CmbFiltroEstado.DataSource = estados;
            CmbFiltroEstado.DisplayMember = nameof(EscoTxEstado.descripcion);
            CmbFiltroEstado.ValueMember = nameof(EscoTxEstado.descripcion);
        }
        private void IniciarImpresoras()
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
                CmbImpresora.Items.Add(printer);
            CmbImpresora.SelectedItem = Properties.Settings.Default.Impresora;
        }
        private void CambiarEstadoEtiqueta(int nuevoEstadoId, string mensajeExito)
        {
            if (DgvEtiquetas.SelectedRows.Count == 0)
            {
                MostrarError("No se ha seleccionado una fila.");
                return;
            }
            var filaSeleccionada = DgvEtiquetas.SelectedRows[0];
            using var db = new ESCORIALContext();
            var etiqueta = db.EscoTxEtiqueta.FirstOrDefault(x => x.codigo.Equals(filaSeleccionada.Cells[4].Value) && x.estado_id != nuevoEstadoId);
            if (etiqueta == null)
            {
                MostrarError("No se encontró la etiqueta.");
                return;
            }
            etiqueta.estado_id = nuevoEstadoId;
            db.SaveChanges();
            DgvEtiquetas.DataSource = ObtenerEtiquetas();
            MessageBox.Show(mensajeExito);
        }
        private static string ObtenerNumeroUnicoEtiqueta()
        {
            var random = new Random();
            string codigo;
            var codigosExistentes = ObtenerEtiquetas().Select(x => x.CodigoEtiqueta).ToList();
            do
            {
                var part1 = random.Next(100, 999);           
                var part2 = random.Next(1000000, 9999999);   
                var part3 = random.Next(100, 999);         
                codigo = $"{part1}{part2}{part3}";
            } while (codigosExistentes.Contains(codigo));
            return codigo;
        }
        private static void MostrarError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private string ObtenerZpl(string? descripcion, string? codigo, string? cantidad, string? codigoEtiqueta)
        {
            return Zpl
                .Replace("#DESCRIPCION#", descripcion)
                .Replace("#CODIGO#", codigo)
                .Replace("#CANTIDAD#", cantidad)
                .Replace("#CODIGOETIQUETA#", codigoEtiqueta);
        }
        private bool Imprimir(string zpl, string formato)
        {
            formato = formato.ToLower();
            if (formato.Equals("zpl"))
            {
                RawPrinterHelper.SendStringToPrinter(Properties.Settings.Default.Impresora, zpl);
                return true;
            }
            else if (formato.Equals("pdf") || formato.Equals("png"))
            {
                var obj = ConvertZplToFile(zpl, formato);
                var res = MessageBox.Show("Desea imprimir o guardar el archivo?\nSi para imprimir, no para guardar.", "Impresion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (formato.Equals("png"))
                        ImprimirImagen(obj, Properties.Settings.Default.Impresora);
                    if (formato.Equals("pdf"))
                        ImprimirPdf(obj, Properties.Settings.Default.Impresora);
                    return true;
                }
                if (res == DialogResult.No)
                {
                    using SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = formato == "pdf" ? "PDF files (*.pdf)|*.pdf" : "PNG files (*.png)|*.png";
                    sfd.FileName = "etiqueta";
                    if (sfd.ShowDialog() == DialogResult.OK)
                        File.WriteAllBytes(sfd.FileName, obj);
                    return true;
                }
                if (res == DialogResult.Cancel)
                    return false;
            }
            else
            {
                throw new ArgumentException("Formato no soportado.");
            }
            return false;
        }
        public static byte[] ConvertZplToFile(string zpl, string format = "pdf", string size = "4x6", string density = "8dpmm")
        {
            if (format != "pdf" && format != "png")
                throw new ArgumentException("Formato no soportado. Usa 'pdf' o 'png'.");
            string url = $"http://api.labelary.com/v1/printers/{density}/labels/{size}/0/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = format == "pdf" ? "application/pdf" : "image/png";
            request.ContentType = "application/x-www-form-urlencoded";
            var zplNormalizado = RemoverCaracteresEspeciales(zpl);
            byte[] zplBytes = System.Text.Encoding.UTF8.GetBytes(zplNormalizado);
            request.ContentLength = zplBytes.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(zplBytes, 0, zplBytes.Length);
            }
            try
            {
                using var response = (HttpWebResponse)request.GetResponse();
                using var responseStream = response.GetResponseStream();
                using var memoryStream = new MemoryStream();
                responseStream.CopyTo(memoryStream);
                return memoryStream.ToArray(); // Devuelve el contenido como byte[]
            }
            catch (WebException ex)
            {
                using var errorResponse = (HttpWebResponse)ex.Response;
                using var reader = new StreamReader(errorResponse.GetResponseStream());
                string errorText = reader.ReadToEnd();
                throw new Exception($"Error de Labelary: {ex.Status} - {errorText}");
            }
        }
        private void ImprimirImagen(byte[] imagenBytes, string nombreImpresora)
        {
            using var stream = new MemoryStream(imagenBytes);
            Image imagen = Image.FromStream(stream);

            PrintDocument pd = new PrintDocument
            {
                PrinterSettings = new PrinterSettings
                {
                    PrinterName = nombreImpresora
                }
            };

            pd.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawImage(imagen, new Point(0, 0));
            };

            pd.Print();
        }

        private void ImprimirPdf(byte[] pdfBytes, string nombreImpresora)
        {
            using var stream = new MemoryStream(pdfBytes);
            using var document = PdfiumViewer.PdfDocument.Load(stream);
            var printDoc = document.CreatePrintDocument();
            printDoc.PrinterSettings = new PrinterSettings
            {
                PrinterName = nombreImpresora
            };

            printDoc.Print();
        }
        public static string RemoverCaracteresEspeciales(string texto)
        {
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in textoNormalizado)
            {
                UnicodeCategory cat = CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            string textoSinDiacriticos = sb.ToString().Normalize(NormalizationForm.FormC);
            textoSinDiacriticos = textoSinDiacriticos
                .Replace("ñ", "n")
                .Replace("Ñ", "N")
                .Replace("ç", "c")
                .Replace("Ç", "C");

            return textoSinDiacriticos;
        }
        #endregion
    }
}