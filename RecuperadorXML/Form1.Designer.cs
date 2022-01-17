namespace RecuperadorXML
{
    partial class formulario
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOrigen = new System.Windows.Forms.Button();
            this.tbxOrigen = new System.Windows.Forms.TextBox();
            this.tbxDestino = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lbxPrueba = new System.Windows.Forms.ListBox();
            this.btnDestino = new System.Windows.Forms.Button();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblContadorXML = new System.Windows.Forms.Label();
            this.lblV1 = new System.Windows.Forms.Label();
            this.lblV2 = new System.Windows.Forms.Label();
            this.ttmensaje = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnOrigen
            // 
            this.btnOrigen.BackColor = System.Drawing.Color.Green;
            this.btnOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrigen.ForeColor = System.Drawing.Color.White;
            this.btnOrigen.Location = new System.Drawing.Point(12, 24);
            this.btnOrigen.Name = "btnOrigen";
            this.btnOrigen.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnOrigen.Size = new System.Drawing.Size(123, 33);
            this.btnOrigen.TabIndex = 0;
            this.btnOrigen.Text = "ORIGEN";
            this.btnOrigen.UseVisualStyleBackColor = false;
            this.btnOrigen.Click += new System.EventHandler(this.btnOrigen_Click);
            // 
            // tbxOrigen
            // 
            this.tbxOrigen.Enabled = false;
            this.tbxOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxOrigen.Location = new System.Drawing.Point(158, 27);
            this.tbxOrigen.Name = "tbxOrigen";
            this.tbxOrigen.ReadOnly = true;
            this.tbxOrigen.Size = new System.Drawing.Size(306, 23);
            this.tbxOrigen.TabIndex = 1;
            // 
            // tbxDestino
            // 
            this.tbxDestino.Enabled = false;
            this.tbxDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDestino.Location = new System.Drawing.Point(158, 68);
            this.tbxDestino.Name = "tbxDestino";
            this.tbxDestino.ReadOnly = true;
            this.tbxDestino.Size = new System.Drawing.Size(306, 23);
            this.tbxDestino.TabIndex = 2;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Teal;
            this.btnExportar.Enabled = false;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(13, 241);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnExportar.Size = new System.Drawing.Size(451, 40);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lbxPrueba
            // 
            this.lbxPrueba.FormattingEnabled = true;
            this.lbxPrueba.Location = new System.Drawing.Point(12, 102);
            this.lbxPrueba.Name = "lbxPrueba";
            this.lbxPrueba.Size = new System.Drawing.Size(452, 108);
            this.lbxPrueba.TabIndex = 4;
            this.lbxPrueba.Click += new System.EventHandler(this.lbxPrueba_Click);
            // 
            // btnDestino
            // 
            this.btnDestino.BackColor = System.Drawing.Color.DimGray;
            this.btnDestino.Enabled = false;
            this.btnDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDestino.ForeColor = System.Drawing.Color.White;
            this.btnDestino.Location = new System.Drawing.Point(12, 63);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnDestino.Size = new System.Drawing.Size(122, 33);
            this.btnDestino.TabIndex = 5;
            this.btnDestino.Text = "DESTINO";
            this.btnDestino.UseVisualStyleBackColor = false;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.ForeColor = System.Drawing.Color.Blue;
            this.lblContador.Location = new System.Drawing.Point(13, 217);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(175, 18);
            this.lblContador.TabIndex = 6;
            this.lblContador.Text = "Archivos Contabilizados: ";
            // 
            // lblContadorXML
            // 
            this.lblContadorXML.AutoSize = true;
            this.lblContadorXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorXML.ForeColor = System.Drawing.Color.Blue;
            this.lblContadorXML.Location = new System.Drawing.Point(234, 217);
            this.lblContadorXML.Name = "lblContadorXML";
            this.lblContadorXML.Size = new System.Drawing.Size(108, 18);
            this.lblContadorXML.TabIndex = 7;
            this.lblContadorXML.Text = "Archivos XML: ";
            // 
            // lblV1
            // 
            this.lblV1.AutoSize = true;
            this.lblV1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblV1.ForeColor = System.Drawing.Color.Blue;
            this.lblV1.Location = new System.Drawing.Point(182, 217);
            this.lblV1.Name = "lblV1";
            this.lblV1.Size = new System.Drawing.Size(16, 18);
            this.lblV1.TabIndex = 8;
            this.lblV1.Text = "0";
            // 
            // lblV2
            // 
            this.lblV2.AutoSize = true;
            this.lblV2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblV2.ForeColor = System.Drawing.Color.Blue;
            this.lblV2.Location = new System.Drawing.Point(335, 217);
            this.lblV2.Name = "lblV2";
            this.lblV2.Size = new System.Drawing.Size(16, 18);
            this.lblV2.TabIndex = 9;
            this.lblV2.Text = "0";
            // 
            // ttmensaje
            // 
            this.ttmensaje.IsBalloon = true;
            // 
            // formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(480, 302);
            this.Controls.Add(this.lblV2);
            this.Controls.Add(this.lblV1);
            this.Controls.Add(this.lblContadorXML);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.btnDestino);
            this.Controls.Add(this.lbxPrueba);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.tbxDestino);
            this.Controls.Add(this.tbxOrigen);
            this.Controls.Add(this.btnOrigen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "formulario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML A EXCEL";
            this.Click += new System.EventHandler(this.formulario_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOrigen;
        private System.Windows.Forms.TextBox tbxOrigen;
        private System.Windows.Forms.TextBox tbxDestino;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ListBox lbxPrueba;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblContadorXML;
        private System.Windows.Forms.Label lblV1;
        private System.Windows.Forms.Label lblV2;
        private System.Windows.Forms.ToolTip ttmensaje;
    }
}

