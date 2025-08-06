namespace EtiquetasTransferencias
{
    partial class FrmInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GpbImpresion = new GroupBox();
            LblFormato = new Label();
            CmbFormato = new ComboBox();
            LblImpresora = new Label();
            CmbImpresora = new ComboBox();
            BtnImprimir = new Button();
            LblProducto = new Label();
            LblCodigoDeProducto = new Label();
            TxtCantidad = new TextBox();
            LblCantidad = new Label();
            BtnBuscar = new Button();
            TxtCodigoProducto = new TextBox();
            GpbEtiquetas = new GroupBox();
            BtnFiltrosBuscar = new Button();
            CmbFiltroEstado = new ComboBox();
            TxtFiltroCodigoEtiqueta = new TextBox();
            LblFiltroCodigoEtiqueta = new Label();
            LblFiltroEstado = new Label();
            TxtFiltroDescripcion = new TextBox();
            LblFiltroDescripcion = new Label();
            LblFiltroCodigoProducto = new Label();
            TxtFiltroCodigoProducto = new TextBox();
            BtnHabilitar = new Button();
            BtnReimprimir = new Button();
            BtnDeshabilitar = new Button();
            DgvEtiquetas = new DataGridView();
            GpbImpresion.SuspendLayout();
            GpbEtiquetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvEtiquetas).BeginInit();
            SuspendLayout();
            // 
            // GpbImpresion
            // 
            GpbImpresion.Controls.Add(LblFormato);
            GpbImpresion.Controls.Add(CmbFormato);
            GpbImpresion.Controls.Add(LblImpresora);
            GpbImpresion.Controls.Add(CmbImpresora);
            GpbImpresion.Controls.Add(BtnImprimir);
            GpbImpresion.Controls.Add(LblProducto);
            GpbImpresion.Controls.Add(LblCodigoDeProducto);
            GpbImpresion.Controls.Add(TxtCantidad);
            GpbImpresion.Controls.Add(LblCantidad);
            GpbImpresion.Controls.Add(BtnBuscar);
            GpbImpresion.Controls.Add(TxtCodigoProducto);
            GpbImpresion.Location = new Point(12, 12);
            GpbImpresion.Name = "GpbImpresion";
            GpbImpresion.Size = new Size(298, 319);
            GpbImpresion.TabIndex = 1;
            GpbImpresion.TabStop = false;
            GpbImpresion.Text = "Impresion";
            // 
            // LblFormato
            // 
            LblFormato.AutoSize = true;
            LblFormato.Location = new Point(6, 195);
            LblFormato.Name = "LblFormato";
            LblFormato.Size = new Size(52, 15);
            LblFormato.TabIndex = 10;
            LblFormato.Text = "Formato";
            // 
            // CmbFormato
            // 
            CmbFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbFormato.FormattingEnabled = true;
            CmbFormato.Items.AddRange(new object[] { "ZPL", "PNG", "PDF" });
            CmbFormato.Location = new Point(6, 213);
            CmbFormato.Name = "CmbFormato";
            CmbFormato.Size = new Size(121, 23);
            CmbFormato.TabIndex = 8;
            // 
            // LblImpresora
            // 
            LblImpresora.AutoSize = true;
            LblImpresora.Location = new Point(6, 139);
            LblImpresora.Name = "LblImpresora";
            LblImpresora.Size = new Size(60, 15);
            LblImpresora.TabIndex = 7;
            LblImpresora.Text = "Impresora";
            // 
            // CmbImpresora
            // 
            CmbImpresora.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbImpresora.FormattingEnabled = true;
            CmbImpresora.ImeMode = ImeMode.NoControl;
            CmbImpresora.Location = new Point(6, 157);
            CmbImpresora.Name = "CmbImpresora";
            CmbImpresora.Size = new Size(286, 23);
            CmbImpresora.TabIndex = 6;
            CmbImpresora.SelectedIndexChanged += CmbImpresora_SelectedIndexChanged;
            // 
            // BtnImprimir
            // 
            BtnImprimir.Location = new Point(217, 290);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(75, 23);
            BtnImprimir.TabIndex = 3;
            BtnImprimir.Text = "Imprimir";
            BtnImprimir.UseVisualStyleBackColor = true;
            BtnImprimir.Click += BtnImprimir_Click;
            // 
            // LblProducto
            // 
            LblProducto.AutoSize = true;
            LblProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LblProducto.Location = new Point(6, 73);
            LblProducto.Name = "LblProducto";
            LblProducto.Size = new Size(0, 15);
            LblProducto.TabIndex = 5;
            LblProducto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblCodigoDeProducto
            // 
            LblCodigoDeProducto.AutoSize = true;
            LblCodigoDeProducto.Location = new Point(6, 29);
            LblCodigoDeProducto.Name = "LblCodigoDeProducto";
            LblCodigoDeProducto.Size = new Size(114, 15);
            LblCodigoDeProducto.TabIndex = 4;
            LblCodigoDeProducto.Text = "Codigo de producto";
            // 
            // TxtCantidad
            // 
            TxtCantidad.Location = new Point(67, 104);
            TxtCantidad.Name = "TxtCantidad";
            TxtCantidad.Size = new Size(225, 23);
            TxtCantidad.TabIndex = 2;
            // 
            // LblCantidad
            // 
            LblCantidad.AutoSize = true;
            LblCantidad.Location = new Point(6, 107);
            LblCantidad.Name = "LblCantidad";
            LblCantidad.Size = new Size(55, 15);
            LblCantidad.TabIndex = 2;
            LblCantidad.Text = "Cantidad";
            // 
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(217, 47);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(75, 23);
            BtnBuscar.TabIndex = 1;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // TxtCodigoProducto
            // 
            TxtCodigoProducto.Location = new Point(6, 47);
            TxtCodigoProducto.Name = "TxtCodigoProducto";
            TxtCodigoProducto.Size = new Size(205, 23);
            TxtCodigoProducto.TabIndex = 0;
            // 
            // GpbEtiquetas
            // 
            GpbEtiquetas.Controls.Add(BtnFiltrosBuscar);
            GpbEtiquetas.Controls.Add(CmbFiltroEstado);
            GpbEtiquetas.Controls.Add(TxtFiltroCodigoEtiqueta);
            GpbEtiquetas.Controls.Add(LblFiltroCodigoEtiqueta);
            GpbEtiquetas.Controls.Add(LblFiltroEstado);
            GpbEtiquetas.Controls.Add(TxtFiltroDescripcion);
            GpbEtiquetas.Controls.Add(LblFiltroDescripcion);
            GpbEtiquetas.Controls.Add(LblFiltroCodigoProducto);
            GpbEtiquetas.Controls.Add(TxtFiltroCodigoProducto);
            GpbEtiquetas.Controls.Add(BtnHabilitar);
            GpbEtiquetas.Controls.Add(BtnReimprimir);
            GpbEtiquetas.Controls.Add(BtnDeshabilitar);
            GpbEtiquetas.Controls.Add(DgvEtiquetas);
            GpbEtiquetas.Location = new Point(316, 12);
            GpbEtiquetas.Name = "GpbEtiquetas";
            GpbEtiquetas.Size = new Size(614, 319);
            GpbEtiquetas.TabIndex = 2;
            GpbEtiquetas.TabStop = false;
            GpbEtiquetas.Text = "Etiquetas";
            // 
            // BtnFiltrosBuscar
            // 
            BtnFiltrosBuscar.Location = new Point(533, 37);
            BtnFiltrosBuscar.Name = "BtnFiltrosBuscar";
            BtnFiltrosBuscar.Size = new Size(75, 23);
            BtnFiltrosBuscar.TabIndex = 8;
            BtnFiltrosBuscar.Text = "Buscar";
            BtnFiltrosBuscar.UseVisualStyleBackColor = true;
            BtnFiltrosBuscar.Click += BtnFiltrosBuscar_Click;
            // 
            // CmbFiltroEstado
            // 
            CmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbFiltroEstado.FormattingEnabled = true;
            CmbFiltroEstado.Location = new Point(216, 37);
            CmbFiltroEstado.Name = "CmbFiltroEstado";
            CmbFiltroEstado.Size = new Size(100, 23);
            CmbFiltroEstado.TabIndex = 6;
            // 
            // TxtFiltroCodigoEtiqueta
            // 
            TxtFiltroCodigoEtiqueta.Location = new Point(322, 37);
            TxtFiltroCodigoEtiqueta.Name = "TxtFiltroCodigoEtiqueta";
            TxtFiltroCodigoEtiqueta.Size = new Size(100, 23);
            TxtFiltroCodigoEtiqueta.TabIndex = 7;
            // 
            // LblFiltroCodigoEtiqueta
            // 
            LblFiltroCodigoEtiqueta.AutoSize = true;
            LblFiltroCodigoEtiqueta.Location = new Point(322, 19);
            LblFiltroCodigoEtiqueta.Name = "LblFiltroCodigoEtiqueta";
            LblFiltroCodigoEtiqueta.Size = new Size(92, 15);
            LblFiltroCodigoEtiqueta.TabIndex = 11;
            LblFiltroCodigoEtiqueta.Text = "Codigo Etiqueta";
            // 
            // LblFiltroEstado
            // 
            LblFiltroEstado.AutoSize = true;
            LblFiltroEstado.Location = new Point(216, 19);
            LblFiltroEstado.Name = "LblFiltroEstado";
            LblFiltroEstado.Size = new Size(42, 15);
            LblFiltroEstado.TabIndex = 9;
            LblFiltroEstado.Text = "Estado";
            // 
            // TxtFiltroDescripcion
            // 
            TxtFiltroDescripcion.Location = new Point(110, 37);
            TxtFiltroDescripcion.Name = "TxtFiltroDescripcion";
            TxtFiltroDescripcion.Size = new Size(100, 23);
            TxtFiltroDescripcion.TabIndex = 5;
            // 
            // LblFiltroDescripcion
            // 
            LblFiltroDescripcion.AutoSize = true;
            LblFiltroDescripcion.Location = new Point(110, 19);
            LblFiltroDescripcion.Name = "LblFiltroDescripcion";
            LblFiltroDescripcion.Size = new Size(65, 15);
            LblFiltroDescripcion.TabIndex = 7;
            LblFiltroDescripcion.Text = "Descipcion";
            // 
            // LblFiltroCodigoProducto
            // 
            LblFiltroCodigoProducto.AutoSize = true;
            LblFiltroCodigoProducto.Location = new Point(6, 19);
            LblFiltroCodigoProducto.Name = "LblFiltroCodigoProducto";
            LblFiltroCodigoProducto.Size = new Size(98, 15);
            LblFiltroCodigoProducto.TabIndex = 6;
            LblFiltroCodigoProducto.Text = "Codigo Producto";
            // 
            // TxtFiltroCodigoProducto
            // 
            TxtFiltroCodigoProducto.Location = new Point(6, 37);
            TxtFiltroCodigoProducto.Name = "TxtFiltroCodigoProducto";
            TxtFiltroCodigoProducto.Size = new Size(98, 23);
            TxtFiltroCodigoProducto.TabIndex = 4;
            // 
            // BtnHabilitar
            // 
            BtnHabilitar.Location = new Point(533, 290);
            BtnHabilitar.Name = "BtnHabilitar";
            BtnHabilitar.Size = new Size(75, 23);
            BtnHabilitar.TabIndex = 12;
            BtnHabilitar.Text = "Habilitar";
            BtnHabilitar.UseVisualStyleBackColor = true;
            BtnHabilitar.Click += BtnHabilitar_Click;
            // 
            // BtnReimprimir
            // 
            BtnReimprimir.Location = new Point(6, 290);
            BtnReimprimir.Name = "BtnReimprimir";
            BtnReimprimir.Size = new Size(75, 23);
            BtnReimprimir.TabIndex = 10;
            BtnReimprimir.Text = "Reimprimir";
            BtnReimprimir.UseVisualStyleBackColor = true;
            BtnReimprimir.Click += BtnReimprimir_Click;
            // 
            // BtnDeshabilitar
            // 
            BtnDeshabilitar.Location = new Point(448, 290);
            BtnDeshabilitar.Name = "BtnDeshabilitar";
            BtnDeshabilitar.Size = new Size(79, 23);
            BtnDeshabilitar.TabIndex = 11;
            BtnDeshabilitar.Text = "Deshabilitar";
            BtnDeshabilitar.UseVisualStyleBackColor = true;
            BtnDeshabilitar.Click += BtnDeshabilitar_Click;
            // 
            // DgvEtiquetas
            // 
            DgvEtiquetas.AllowUserToAddRows = false;
            DgvEtiquetas.AllowUserToDeleteRows = false;
            DgvEtiquetas.AllowUserToOrderColumns = true;
            DgvEtiquetas.AllowUserToResizeRows = false;
            DgvEtiquetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEtiquetas.Location = new Point(6, 66);
            DgvEtiquetas.MultiSelect = false;
            DgvEtiquetas.Name = "DgvEtiquetas";
            DgvEtiquetas.ReadOnly = true;
            DgvEtiquetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEtiquetas.ShowEditingIcon = false;
            DgvEtiquetas.Size = new Size(602, 218);
            DgvEtiquetas.TabIndex = 9;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 343);
            Controls.Add(GpbEtiquetas);
            Controls.Add(GpbImpresion);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmInicio";
            ShowIcon = false;
            Text = "Etiquetas Transferencias";
            Load += FrmInicio_Load;
            GpbImpresion.ResumeLayout(false);
            GpbImpresion.PerformLayout();
            GpbEtiquetas.ResumeLayout(false);
            GpbEtiquetas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvEtiquetas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GpbImpresion;
        private GroupBox GpbEtiquetas;
        private DataGridView DgvEtiquetas;
        private TextBox TxtCantidad;
        private Label LblCantidad;
        private Button BtnBuscar;
        private TextBox TxtCodigoProducto;
        private Label LblCodigoDeProducto;
        private Button BtnImprimir;
        private Label LblProducto;
        private Button BtnDeshabilitar;
        private Button BtnReimprimir;
        private Button BtnHabilitar;
        private TextBox TxtFiltroDescripcion;
        private Label LblFiltroDescripcion;
        private Label LblFiltroCodigoProducto;
        private TextBox TxtFiltroCodigoProducto;
        private TextBox TxtFiltroCodigoEtiqueta;
        private Label LblFiltroCodigoEtiqueta;
        private Label LblFiltroEstado;
        private ComboBox CmbFiltroEstado;
        private Button BtnFiltrosBuscar;
        private Label LblImpresora;
        private ComboBox CmbImpresora;
        private Label LblFormato;
        private ComboBox CmbFormato;
    }
}