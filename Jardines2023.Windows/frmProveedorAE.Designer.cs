namespace Jardines2023.Windows
{
    partial class frmProveedorAE
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.btnAgregarPais = new System.Windows.Forms.Button();
            this.cboCiudades = new System.Windows.Forms.ComboBox();
            this.cboPaises = new System.Windows.Forms.ComboBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(541, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 66);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(204, 286);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 66);
            this.btnOK.TabIndex = 71;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.Location = new System.Drawing.Point(568, 208);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(43, 38);
            this.btnAgregarCiudad.TabIndex = 68;
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            // 
            // btnAgregarPais
            // 
            this.btnAgregarPais.Location = new System.Drawing.Point(568, 162);
            this.btnAgregarPais.Name = "btnAgregarPais";
            this.btnAgregarPais.Size = new System.Drawing.Size(43, 38);
            this.btnAgregarPais.TabIndex = 69;
            this.btnAgregarPais.UseVisualStyleBackColor = true;
            // 
            // cboCiudades
            // 
            this.cboCiudades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudades.FormattingEnabled = true;
            this.cboCiudades.Location = new System.Drawing.Point(250, 218);
            this.cboCiudades.Name = "cboCiudades";
            this.cboCiudades.Size = new System.Drawing.Size(282, 21);
            this.cboCiudades.TabIndex = 61;
            // 
            // cboPaises
            // 
            this.cboPaises.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaises.FormattingEnabled = true;
            this.cboPaises.Location = new System.Drawing.Point(250, 172);
            this.cboPaises.Name = "cboPaises";
            this.cboPaises.Size = new System.Drawing.Size(282, 21);
            this.cboPaises.TabIndex = 60;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(250, 98);
            this.txtProveedor.MaxLength = 255;
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(282, 20);
            this.txtProveedor.TabIndex = 58;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(250, 134);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(224, 20);
            this.txtDireccion.TabIndex = 59;
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(559, 134);
            this.txtCodPostal.MaxLength = 10;
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(57, 20);
            this.txtCodPostal.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Proveedor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Ciudad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Dirección:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "País:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(489, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Cod. Postal:";
            // 
            // frmProveedorAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAgregarCiudad);
            this.Controls.Add(this.btnAgregarPais);
            this.Controls.Add(this.cboCiudades);
            this.Controls.Add(this.cboPaises);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCodPostal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProveedorAE";
            this.Text = "frmProveedorAE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAgregarCiudad;
        private System.Windows.Forms.Button btnAgregarPais;
        private System.Windows.Forms.ComboBox cboCiudades;
        private System.Windows.Forms.ComboBox cboPaises;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}