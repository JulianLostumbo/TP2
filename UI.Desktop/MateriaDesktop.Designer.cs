namespace Academia
{
    partial class MateriaDesktop
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblHsSemanales = new System.Windows.Forms.Label();
            this.lblHorasTotales = new System.Windows.Forms.Label();
            this.txtHsSemanales = new System.Windows.Forms.TextBox();
            this.txtHsTotales = new System.Windows.Forms.TextBox();
            this.txtIdPlan = new System.Windows.Forms.TextBox();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(129, 210);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(217, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 38);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 13);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripcion: ";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(110, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(181, 20);
            this.txtID.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(79, 38);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(213, 74);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.Text = "";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(77, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID de Materia: ";
            // 
            // lblHsSemanales
            // 
            this.lblHsSemanales.AutoSize = true;
            this.lblHsSemanales.Location = new System.Drawing.Point(13, 118);
            this.lblHsSemanales.Name = "lblHsSemanales";
            this.lblHsSemanales.Size = new System.Drawing.Size(96, 13);
            this.lblHsSemanales.TabIndex = 6;
            this.lblHsSemanales.Text = "Horas Semanales: ";
            // 
            // lblHorasTotales
            // 
            this.lblHorasTotales.AutoSize = true;
            this.lblHorasTotales.Location = new System.Drawing.Point(13, 154);
            this.lblHorasTotales.Name = "lblHorasTotales";
            this.lblHorasTotales.Size = new System.Drawing.Size(79, 13);
            this.lblHorasTotales.TabIndex = 7;
            this.lblHorasTotales.Text = "Horas Totales: ";
            // 
            // txtHsSemanales
            // 
            this.txtHsSemanales.Location = new System.Drawing.Point(110, 118);
            this.txtHsSemanales.Name = "txtHsSemanales";
            this.txtHsSemanales.Size = new System.Drawing.Size(181, 20);
            this.txtHsSemanales.TabIndex = 8;
            // 
            // txtHsTotales
            // 
            this.txtHsTotales.Location = new System.Drawing.Point(110, 151);
            this.txtHsTotales.Name = "txtHsTotales";
            this.txtHsTotales.Size = new System.Drawing.Size(181, 20);
            this.txtHsTotales.TabIndex = 9;
            // 
            // txtIdPlan
            // 
            this.txtIdPlan.Location = new System.Drawing.Point(110, 181);
            this.txtIdPlan.Name = "txtIdPlan";
            this.txtIdPlan.Size = new System.Drawing.Size(181, 20);
            this.txtIdPlan.TabIndex = 10;
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(13, 184);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(48, 13);
            this.lblIdPlan.TabIndex = 11;
            this.lblIdPlan.Text = "ID Plan: ";
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 244);
            this.Controls.Add(this.lblIdPlan);
            this.Controls.Add(this.txtIdPlan);
            this.Controls.Add(this.txtHsTotales);
            this.Controls.Add(this.txtHsSemanales);
            this.Controls.Add(this.lblHorasTotales);
            this.Controls.Add(this.lblHsSemanales);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "MateriaDesktop";
            this.Text = "Materia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblHsSemanales;
        private System.Windows.Forms.Label lblHorasTotales;
        private System.Windows.Forms.TextBox txtHsSemanales;
        private System.Windows.Forms.TextBox txtHsTotales;
        private System.Windows.Forms.TextBox txtIdPlan;
        private System.Windows.Forms.Label lblIdPlan;
    }
}