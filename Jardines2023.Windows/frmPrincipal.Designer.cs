namespace Jardines2023.Windows
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.CategoriasButton = new System.Windows.Forms.Button();
            this.VentasButton = new System.Windows.Forms.Button();
            this.ProductosButton = new System.Windows.Forms.Button();
            this.ProveedoresButton = new System.Windows.Forms.Button();
            this.ClientesButton = new System.Windows.Forms.Button();
            this.CiudadesButton = new System.Windows.Forms.Button();
            this.PaisesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CategoriasButton
            // 
            this.CategoriasButton.Location = new System.Drawing.Point(60, 246);
            this.CategoriasButton.Name = "CategoriasButton";
            this.CategoriasButton.Size = new System.Drawing.Size(147, 76);
            this.CategoriasButton.TabIndex = 12;
            this.CategoriasButton.Text = "Categorías";
            this.CategoriasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CategoriasButton.UseVisualStyleBackColor = true;
            // 
            // VentasButton
            // 
            this.VentasButton.Location = new System.Drawing.Point(593, 246);
            this.VentasButton.Name = "VentasButton";
            this.VentasButton.Size = new System.Drawing.Size(147, 76);
            this.VentasButton.TabIndex = 13;
            this.VentasButton.Text = "Ventas";
            this.VentasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.VentasButton.UseVisualStyleBackColor = true;
            // 
            // ProductosButton
            // 
            this.ProductosButton.Location = new System.Drawing.Point(425, 246);
            this.ProductosButton.Name = "ProductosButton";
            this.ProductosButton.Size = new System.Drawing.Size(147, 76);
            this.ProductosButton.TabIndex = 14;
            this.ProductosButton.Text = "Productos";
            this.ProductosButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProductosButton.UseVisualStyleBackColor = true;
            // 
            // ProveedoresButton
            // 
            this.ProveedoresButton.Location = new System.Drawing.Point(242, 246);
            this.ProveedoresButton.Name = "ProveedoresButton";
            this.ProveedoresButton.Size = new System.Drawing.Size(147, 76);
            this.ProveedoresButton.TabIndex = 15;
            this.ProveedoresButton.Text = "Proveedores";
            this.ProveedoresButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProveedoresButton.UseVisualStyleBackColor = true;
            // 
            // ClientesButton
            // 
            this.ClientesButton.Location = new System.Drawing.Point(425, 129);
            this.ClientesButton.Name = "ClientesButton";
            this.ClientesButton.Size = new System.Drawing.Size(147, 76);
            this.ClientesButton.TabIndex = 16;
            this.ClientesButton.Text = "Clientes";
            this.ClientesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClientesButton.UseVisualStyleBackColor = true;
            // 
            // CiudadesButton
            // 
            this.CiudadesButton.Location = new System.Drawing.Point(242, 129);
            this.CiudadesButton.Name = "CiudadesButton";
            this.CiudadesButton.Size = new System.Drawing.Size(147, 76);
            this.CiudadesButton.TabIndex = 17;
            this.CiudadesButton.Text = "Ciudades";
            this.CiudadesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CiudadesButton.UseVisualStyleBackColor = true;
            // 
            // PaisesButton
            // 
            this.PaisesButton.Location = new System.Drawing.Point(60, 129);
            this.PaisesButton.Name = "PaisesButton";
            this.PaisesButton.Size = new System.Drawing.Size(147, 76);
            this.PaisesButton.TabIndex = 18;
            this.PaisesButton.Text = "Países";
            this.PaisesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PaisesButton.UseVisualStyleBackColor = true;
            this.PaisesButton.Click += new System.EventHandler(this.PaisesButton_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CategoriasButton);
            this.Controls.Add(this.VentasButton);
            this.Controls.Add(this.ProductosButton);
            this.Controls.Add(this.ProveedoresButton);
            this.Controls.Add(this.ClientesButton);
            this.Controls.Add(this.CiudadesButton);
            this.Controls.Add(this.PaisesButton);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CategoriasButton;
        private System.Windows.Forms.Button VentasButton;
        private System.Windows.Forms.Button ProductosButton;
        private System.Windows.Forms.Button ProveedoresButton;
        private System.Windows.Forms.Button ClientesButton;
        private System.Windows.Forms.Button CiudadesButton;
        private System.Windows.Forms.Button PaisesButton;
    }
}

