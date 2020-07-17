namespace Academia
{
    partial class ComisionDesktop
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.txtAnioEspecialidad = new System.Windows.Forms.TextBox();
            this.lblAnioEspecialidad = new System.Windows.Forms.Label();
            this.txtIdPlan = new System.Windows.Forms.TextBox();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(135, 192);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(216, 192);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(84, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID de Comision: ";
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
            this.txtID.Location = new System.Drawing.Point(135, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(156, 20);
            this.txtID.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(79, 38);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(213, 90);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.Text = "";
            // 
            // txtAnioEspecialidad
            // 
            this.txtAnioEspecialidad.Location = new System.Drawing.Point(135, 134);
            this.txtAnioEspecialidad.Name = "txtAnioEspecialidad";
            this.txtAnioEspecialidad.Size = new System.Drawing.Size(156, 20);
            this.txtAnioEspecialidad.TabIndex = 7;
            // 
            // lblAnioEspecialidad
            // 
            this.lblAnioEspecialidad.AutoSize = true;
            this.lblAnioEspecialidad.Location = new System.Drawing.Point(12, 134);
            this.lblAnioEspecialidad.Name = "lblAnioEspecialidad";
            this.lblAnioEspecialidad.Size = new System.Drawing.Size(110, 13);
            this.lblAnioEspecialidad.TabIndex = 6;
            this.lblAnioEspecialidad.Text = "Año de Especialidad: ";
            // 
            // txtIdPlan
            // 
            this.txtIdPlan.Location = new System.Drawing.Point(135, 166);
            this.txtIdPlan.Name = "txtIdPlan";
            this.txtIdPlan.Size = new System.Drawing.Size(156, 20);
            this.txtIdPlan.TabIndex = 9;
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(13, 166);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(48, 13);
            this.lblIdPlan.TabIndex = 8;
            this.lblIdPlan.Text = "ID Plan: ";
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 230);
            this.Controls.Add(this.txtIdPlan);
            this.Controls.Add(this.lblIdPlan);
            this.Controls.Add(this.txtAnioEspecialidad);
            this.Controls.Add(this.lblAnioEspecialidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "ComisionDesktop";
            this.Text = "Comision";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtAnioEspecialidad;
        private System.Windows.Forms.Label lblAnioEspecialidad;
        private System.Windows.Forms.TextBox txtIdPlan;
        private System.Windows.Forms.Label lblIdPlan;
    }
}