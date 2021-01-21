namespace Academia
{
    partial class formPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoUsuarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaComisionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaEspecialidadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaMateriaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.tsmiEstadoAcademico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatosPersonales = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaHoyUserControl1 = new UI.Desktop.FechaHoyUserControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRToolStripMenuItem,
            this.funcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aRToolStripMenuItem
            // 
            this.aRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.aRToolStripMenuItem.Name = "aRToolStripMenuItem";
            this.aRToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.aRToolStripMenuItem.Text = "Archivo";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.loginToolStripMenuItem.Text = "Cerrar Sesión";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // funcionesToolStripMenuItem
            // 
            this.funcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUsuarios,
            this.tsmiPersonas,
            this.tsmiComisiones,
            this.tsmiDocentes,
            this.tsmiEspecialidades,
            this.tsmiMaterias,
            this.tsmiPlanes,
            this.tsmiCursos,
            this.tsmiEstadoAcademico,
            this.tsmiInscripcion,
            this.tsmiDatosPersonales});
            this.funcionesToolStripMenuItem.Name = "funcionesToolStripMenuItem";
            this.funcionesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.funcionesToolStripMenuItem.Text = "Funciones";
            // 
            // tsmiUsuarios
            // 
            this.tsmiUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem,
            this.nuevoUsuarioMenuItem});
            this.tsmiUsuarios.Name = "tsmiUsuarios";
            this.tsmiUsuarios.Size = new System.Drawing.Size(200, 22);
            this.tsmiUsuarios.Text = "Menú de Usuarios";
            // 
            // listarToolStripMenuItem
            // 
            this.listarToolStripMenuItem.Name = "listarToolStripMenuItem";
            this.listarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listarToolStripMenuItem.Text = "Listar";
            this.listarToolStripMenuItem.Click += new System.EventHandler(this.listarToolStripMenuItem_Click);
            // 
            // nuevoUsuarioMenuItem
            // 
            this.nuevoUsuarioMenuItem.Name = "nuevoUsuarioMenuItem";
            this.nuevoUsuarioMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoUsuarioMenuItem.Text = "Registrar Nuevo";
            this.nuevoUsuarioMenuItem.Click += new System.EventHandler(this.registrarNuevoToolStripMenuItem_Click);
            // 
            // tsmiPersonas
            // 
            this.tsmiPersonas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem5,
            this.registrarNuevaToolStripMenuItem});
            this.tsmiPersonas.Name = "tsmiPersonas";
            this.tsmiPersonas.Size = new System.Drawing.Size(200, 22);
            this.tsmiPersonas.Text = "Menú de Personas";
            // 
            // listarToolStripMenuItem5
            // 
            this.listarToolStripMenuItem5.Name = "listarToolStripMenuItem5";
            this.listarToolStripMenuItem5.Size = new System.Drawing.Size(157, 22);
            this.listarToolStripMenuItem5.Text = "Listar";
            this.listarToolStripMenuItem5.Click += new System.EventHandler(this.listarToolStripMenuItem5_Click);
            // 
            // registrarNuevaToolStripMenuItem
            // 
            this.registrarNuevaToolStripMenuItem.Name = "registrarNuevaToolStripMenuItem";
            this.registrarNuevaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.registrarNuevaToolStripMenuItem.Text = "Registrar Nueva";
            this.registrarNuevaToolStripMenuItem.Click += new System.EventHandler(this.registrarNuevaToolStripMenuItem_Click_1);
            // 
            // tsmiComisiones
            // 
            this.tsmiComisiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem1,
            this.nuevaComisionMenuItem});
            this.tsmiComisiones.Name = "tsmiComisiones";
            this.tsmiComisiones.Size = new System.Drawing.Size(200, 22);
            this.tsmiComisiones.Text = "Menú de Comisiones";
            // 
            // listarToolStripMenuItem1
            // 
            this.listarToolStripMenuItem1.Name = "listarToolStripMenuItem1";
            this.listarToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.listarToolStripMenuItem1.Text = "Listar";
            this.listarToolStripMenuItem1.Click += new System.EventHandler(this.listarToolStripMenuItem1_Click);
            // 
            // nuevaComisionMenuItem
            // 
            this.nuevaComisionMenuItem.Name = "nuevaComisionMenuItem";
            this.nuevaComisionMenuItem.Size = new System.Drawing.Size(157, 22);
            this.nuevaComisionMenuItem.Text = "Registrar Nueva";
            this.nuevaComisionMenuItem.Click += new System.EventHandler(this.registrarNuevaToolStripMenuItem_Click);
            // 
            // tsmiDocentes
            // 
            this.tsmiDocentes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem6,
            this.registrarNuevoToolStripMenuItem});
            this.tsmiDocentes.Name = "tsmiDocentes";
            this.tsmiDocentes.Size = new System.Drawing.Size(200, 22);
            this.tsmiDocentes.Text = "Menú de Docentes";
            // 
            // listarToolStripMenuItem6
            // 
            this.listarToolStripMenuItem6.Name = "listarToolStripMenuItem6";
            this.listarToolStripMenuItem6.Size = new System.Drawing.Size(158, 22);
            this.listarToolStripMenuItem6.Text = "Listar";
            this.listarToolStripMenuItem6.Click += new System.EventHandler(this.listarToolStripMenuItem6_Click);
            // 
            // registrarNuevoToolStripMenuItem
            // 
            this.registrarNuevoToolStripMenuItem.Name = "registrarNuevoToolStripMenuItem";
            this.registrarNuevoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.registrarNuevoToolStripMenuItem.Text = "Registrar Nuevo";
            this.registrarNuevoToolStripMenuItem.Click += new System.EventHandler(this.registrarNuevoToolStripMenuItem_Click_1);
            // 
            // tsmiEspecialidades
            // 
            this.tsmiEspecialidades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem2,
            this.nuevaEspecialidadMenuItem});
            this.tsmiEspecialidades.Name = "tsmiEspecialidades";
            this.tsmiEspecialidades.Size = new System.Drawing.Size(200, 22);
            this.tsmiEspecialidades.Text = "Menú de Especialidades";
            this.tsmiEspecialidades.Click += new System.EventHandler(this.listadoDeEspecialidadesToolStripMenuItem_Click);
            // 
            // listarToolStripMenuItem2
            // 
            this.listarToolStripMenuItem2.Name = "listarToolStripMenuItem2";
            this.listarToolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
            this.listarToolStripMenuItem2.Text = "Listar";
            this.listarToolStripMenuItem2.Click += new System.EventHandler(this.listarToolStripMenuItem2_Click);
            // 
            // nuevaEspecialidadMenuItem
            // 
            this.nuevaEspecialidadMenuItem.Name = "nuevaEspecialidadMenuItem";
            this.nuevaEspecialidadMenuItem.Size = new System.Drawing.Size(157, 22);
            this.nuevaEspecialidadMenuItem.Text = "Registrar Nueva";
            this.nuevaEspecialidadMenuItem.Click += new System.EventHandler(this.registrarNuevaToolStripMenuItem1_Click);
            // 
            // tsmiMaterias
            // 
            this.tsmiMaterias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem3,
            this.nuevaMateriaMenuItem});
            this.tsmiMaterias.Name = "tsmiMaterias";
            this.tsmiMaterias.Size = new System.Drawing.Size(200, 22);
            this.tsmiMaterias.Text = "Menú de Materias";
            // 
            // listarToolStripMenuItem3
            // 
            this.listarToolStripMenuItem3.Name = "listarToolStripMenuItem3";
            this.listarToolStripMenuItem3.Size = new System.Drawing.Size(157, 22);
            this.listarToolStripMenuItem3.Text = "Listar";
            this.listarToolStripMenuItem3.Click += new System.EventHandler(this.listarToolStripMenuItem3_Click);
            // 
            // nuevaMateriaMenuItem
            // 
            this.nuevaMateriaMenuItem.Name = "nuevaMateriaMenuItem";
            this.nuevaMateriaMenuItem.Size = new System.Drawing.Size(157, 22);
            this.nuevaMateriaMenuItem.Text = "Registrar Nueva";
            this.nuevaMateriaMenuItem.Click += new System.EventHandler(this.registrarNuevaToolStripMenuItem2_Click);
            // 
            // tsmiPlanes
            // 
            this.tsmiPlanes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem4,
            this.nuevoPlanMenuItem});
            this.tsmiPlanes.Name = "tsmiPlanes";
            this.tsmiPlanes.Size = new System.Drawing.Size(200, 22);
            this.tsmiPlanes.Text = "Menú de Planes";
            // 
            // listarToolStripMenuItem4
            // 
            this.listarToolStripMenuItem4.Name = "listarToolStripMenuItem4";
            this.listarToolStripMenuItem4.Size = new System.Drawing.Size(135, 22);
            this.listarToolStripMenuItem4.Text = "Listar";
            this.listarToolStripMenuItem4.Click += new System.EventHandler(this.listarToolStripMenuItem4_Click);
            // 
            // nuevoPlanMenuItem
            // 
            this.nuevoPlanMenuItem.Name = "nuevoPlanMenuItem";
            this.nuevoPlanMenuItem.Size = new System.Drawing.Size(135, 22);
            this.nuevoPlanMenuItem.Text = "Nuevo Plan";
            this.nuevoPlanMenuItem.Click += new System.EventHandler(this.nuevoPlanToolStripMenuItem_Click);
            // 
            // tsmiCursos
            // 
            this.tsmiCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem7,
            this.registrarNuevoToolStripMenuItem1});
            this.tsmiCursos.Name = "tsmiCursos";
            this.tsmiCursos.Size = new System.Drawing.Size(200, 22);
            this.tsmiCursos.Text = "Menú de Cursos";
            // 
            // listarToolStripMenuItem7
            // 
            this.listarToolStripMenuItem7.Name = "listarToolStripMenuItem7";
            this.listarToolStripMenuItem7.Size = new System.Drawing.Size(158, 22);
            this.listarToolStripMenuItem7.Text = "Listar";
            this.listarToolStripMenuItem7.Click += new System.EventHandler(this.listarToolStripMenuItem7_Click);
            // 
            // registrarNuevoToolStripMenuItem1
            // 
            this.registrarNuevoToolStripMenuItem1.Name = "registrarNuevoToolStripMenuItem1";
            this.registrarNuevoToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.registrarNuevoToolStripMenuItem1.Text = "Registrar Nuevo";
            this.registrarNuevoToolStripMenuItem1.Click += new System.EventHandler(this.registrarNuevoToolStripMenuItem1_Click);
            // 
            // tsmiInscripcion
            // 
            this.tsmiInscripcion.Name = "tsmiInscripcion";
            this.tsmiInscripcion.Size = new System.Drawing.Size(200, 22);
            this.tsmiInscripcion.Text = "Registrar Inscripción";
            this.tsmiInscripcion.Click += new System.EventHandler(this.registrarInscripciónToolStripMenuItem_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(167, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 18);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Usuario:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(418, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 18);
            this.lblTipo.TabIndex = 5;
            this.lblTipo.Text = "Tipo:";
            // 
            // tsmiEstadoAcademico
            // 
            this.tsmiEstadoAcademico.Name = "tsmiEstadoAcademico";
            this.tsmiEstadoAcademico.Size = new System.Drawing.Size(200, 22);
            this.tsmiEstadoAcademico.Text = "Ver Estado Académico";
            // 
            // tsmiDatosPersonales
            // 
            this.tsmiDatosPersonales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.personaToolStripMenuItem});
            this.tsmiDatosPersonales.Name = "tsmiDatosPersonales";
            this.tsmiDatosPersonales.Size = new System.Drawing.Size(200, 22);
            this.tsmiDatosPersonales.Text = "Ver Datos Personales";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // personaToolStripMenuItem
            // 
            this.personaToolStripMenuItem.Name = "personaToolStripMenuItem";
            this.personaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.personaToolStripMenuItem.Text = "Persona";
            this.personaToolStripMenuItem.Click += new System.EventHandler(this.personaToolStripMenuItem_Click);
            // 
            // fechaHoyUserControl1
            // 
            this.fechaHoyUserControl1.Font = new System.Drawing.Font("Calibri", 10F);
            this.fechaHoyUserControl1.Location = new System.Drawing.Point(736, 0);
            this.fechaHoyUserControl1.Name = "fechaHoyUserControl1";
            this.fechaHoyUserControl1.Size = new System.Drawing.Size(248, 24);
            this.fechaHoyUserControl1.TabIndex = 7;
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.fechaHoyUserControl1);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiComisiones;
        private System.Windows.Forms.ToolStripMenuItem tsmiEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaterias;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoUsuarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevaComisionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem nuevaEspecialidadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem nuevaMateriaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanes;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem nuevoPlanMenuItem;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonas;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem registrarNuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiInscripcion;
        private System.Windows.Forms.ToolStripMenuItem tsmiDocentes;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem registrarNuevoToolStripMenuItem;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ToolStripMenuItem tsmiCursos;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem registrarNuevoToolStripMenuItem1;
        private UI.Desktop.FechaHoyUserControl fechaHoyUserControl1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEstadoAcademico;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatosPersonales;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personaToolStripMenuItem;
    }
}