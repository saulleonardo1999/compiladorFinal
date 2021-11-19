/*
 * Created by SharpDevelop.
 * User: Ricardo
 * Date: 20/02/2013
 * Time: 05:04 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Entorno_desarrollo
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarCtrlCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarCtrlVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarDelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorTextoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorLetras1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorLetras2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorComentariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.l_compilar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.l_eliminar = new System.Windows.Forms.Button();
            this.l_pegar = new System.Windows.Forms.Button();
            this.l_copiar = new System.Windows.Forms.Button();
            this.l_cortar = new System.Windows.Forms.Button();
            this.l_guardar = new System.Windows.Forms.Button();
            this.l_abrir = new System.Windows.Forms.Button();
            this.l_nuevo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.RichTextBox();
            this.Errores = new System.Windows.Forms.TabControl();
            this.ventana_error = new System.Windows.Forms.TabPage();
            this.errores_a = new System.Windows.Forms.RichTextBox();
            this.ventana_resultado = new System.Windows.Forms.TabPage();
            this.codigoIntermedio_a = new System.Windows.Forms.RichTextBox();
            this.o = new System.Windows.Forms.TabControl();
            this.semantico = new System.Windows.Forms.TabPage();
            this.treeSemantico = new System.Windows.Forms.TreeView();
            this.cod_intermedio = new System.Windows.Forms.TabPage();
            this.treeCodIntermedio = new System.Windows.Forms.TreeView();
            this.posicion = new System.Windows.Forms.Label();
            this.sintactico = new System.Windows.Forms.TabPage();
            this.tree = new System.Windows.Forms.TreeView();
            this.lexico = new System.Windows.Forms.TabPage();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabla_simbolos = new System.Windows.Forms.DataGridView();
            this.lineas = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Errores.SuspendLayout();
            this.ventana_error.SuspendLayout();
            this.o.SuspendLayout();
            this.semantico.SuspendLayout();
            this.cod_intermedio.SuspendLayout();
            this.sintactico.SuspendLayout();
            this.lexico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_simbolos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Crimson;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.formatoToolStripMenuItem,
            this.compilarToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.nuevo;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.NuevoToolStripMenuItemClick);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.abrir;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItemClick);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.guardar;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItemClick);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.GuardarComoToolStripMenuItemClick);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.cerrar;
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.CerrarToolStripMenuItemClick);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarToolStripMenuItem,
            this.copiarCtrlCToolStripMenuItem,
            this.pegarCtrlVToolStripMenuItem,
            this.borrarDelToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.cortar;
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.cortarToolStripMenuItem.Text = "Cortar     Ctrl + X";
            this.cortarToolStripMenuItem.Click += new System.EventHandler(this.CortarToolStripMenuItemClick);
            // 
            // copiarCtrlCToolStripMenuItem
            // 
            this.copiarCtrlCToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.copiar;
            this.copiarCtrlCToolStripMenuItem.Name = "copiarCtrlCToolStripMenuItem";
            this.copiarCtrlCToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.copiarCtrlCToolStripMenuItem.Text = "Copiar     Ctrl + C";
            this.copiarCtrlCToolStripMenuItem.Click += new System.EventHandler(this.CopiarCtrlCToolStripMenuItemClick);
            // 
            // pegarCtrlVToolStripMenuItem
            // 
            this.pegarCtrlVToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.pegar;
            this.pegarCtrlVToolStripMenuItem.Name = "pegarCtrlVToolStripMenuItem";
            this.pegarCtrlVToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.pegarCtrlVToolStripMenuItem.Text = "Pegar      Ctrl + V";
            this.pegarCtrlVToolStripMenuItem.Click += new System.EventHandler(this.PegarCtrlVToolStripMenuItemClick);
            // 
            // borrarDelToolStripMenuItem
            // 
            this.borrarDelToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.cerrar;
            this.borrarDelToolStripMenuItem.Name = "borrarDelToolStripMenuItem";
            this.borrarDelToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.borrarDelToolStripMenuItem.Text = "Borrar      Del";
            this.borrarDelToolStripMenuItem.Click += new System.EventHandler(this.BorrarDelToolStripMenuItemClick);
            // 
            // formatoToolStripMenuItem
            // 
            this.formatoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorFondoToolStripMenuItem,
            this.colorTextoToolStripMenuItem,
            this.colorLetras1ToolStripMenuItem,
            this.colorLetras2ToolStripMenuItem,
            this.colorComentariosToolStripMenuItem});
            this.formatoToolStripMenuItem.Name = "formatoToolStripMenuItem";
            this.formatoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.formatoToolStripMenuItem.Text = "Formato";
            // 
            // colorFondoToolStripMenuItem
            // 
            this.colorFondoToolStripMenuItem.Name = "colorFondoToolStripMenuItem";
            this.colorFondoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.colorFondoToolStripMenuItem.Text = "Color Fondo";
            this.colorFondoToolStripMenuItem.Click += new System.EventHandler(this.ColorFondoToolStripMenuItemClick);
            // 
            // colorTextoToolStripMenuItem
            // 
            this.colorTextoToolStripMenuItem.Name = "colorTextoToolStripMenuItem";
            this.colorTextoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.colorTextoToolStripMenuItem.Text = "Color Texto";
            this.colorTextoToolStripMenuItem.Click += new System.EventHandler(this.ColorTextoToolStripMenuItemClick);
            // 
            // colorLetras1ToolStripMenuItem
            // 
            this.colorLetras1ToolStripMenuItem.Name = "colorLetras1ToolStripMenuItem";
            this.colorLetras1ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.colorLetras1ToolStripMenuItem.Text = "Color Letras 1";
            this.colorLetras1ToolStripMenuItem.Click += new System.EventHandler(this.ColorLetras1ToolStripMenuItemClick);
            // 
            // colorLetras2ToolStripMenuItem
            // 
            this.colorLetras2ToolStripMenuItem.Name = "colorLetras2ToolStripMenuItem";
            this.colorLetras2ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.colorLetras2ToolStripMenuItem.Text = "Color Letras 2";
            this.colorLetras2ToolStripMenuItem.Click += new System.EventHandler(this.ColorLetras2ToolStripMenuItemClick);
            // 
            // colorComentariosToolStripMenuItem
            // 
            this.colorComentariosToolStripMenuItem.Name = "colorComentariosToolStripMenuItem";
            this.colorComentariosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.colorComentariosToolStripMenuItem.Text = "Color Comentarios";
            this.colorComentariosToolStripMenuItem.Click += new System.EventHandler(this.ColorComentariosToolStripMenuItemClick);
            // 
            // compilarToolStripMenuItem
            // 
            this.compilarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compilarToolStripMenuItem1});
            this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
            this.compilarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.compilarToolStripMenuItem.Text = "Compilar";
            // 
            // compilarToolStripMenuItem1
            // 
            this.compilarToolStripMenuItem1.Image = global::Entorno_desarrollo.Imagenes.compilar;
            this.compilarToolStripMenuItem1.Name = "compilarToolStripMenuItem1";
            this.compilarToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.compilarToolStripMenuItem1.Text = "Compilar";
            this.compilarToolStripMenuItem1.Click += new System.EventHandler(this.CompilarToolStripMenuItem1Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayudaToolStripMenuItem1,
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // ayudaToolStripMenuItem1
            // 
            this.ayudaToolStripMenuItem1.Image = global::Entorno_desarrollo.Imagenes.ayuda;
            this.ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            this.ayudaToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.ayudaToolStripMenuItem1.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Image = global::Entorno_desarrollo.Imagenes.acerca;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de ...";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.l_compilar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.l_eliminar);
            this.panel1.Controls.Add(this.l_pegar);
            this.panel1.Controls.Add(this.l_copiar);
            this.panel1.Controls.Add(this.l_cortar);
            this.panel1.Controls.Add(this.l_guardar);
            this.panel1.Controls.Add(this.l_abrir);
            this.panel1.Controls.Add(this.l_nuevo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 29);
            this.panel1.TabIndex = 1;
            // 
            // l_compilar
            // 
            this.l_compilar.BackColor = System.Drawing.Color.Crimson;
            this.l_compilar.BackgroundImage = global::Entorno_desarrollo.Imagenes.compilar;
            this.l_compilar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_compilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_compilar.ForeColor = System.Drawing.Color.Transparent;
            this.l_compilar.Location = new System.Drawing.Point(223, 4);
            this.l_compilar.Name = "l_compilar";
            this.l_compilar.Size = new System.Drawing.Size(21, 20);
            this.l_compilar.TabIndex = 18;
            this.l_compilar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_compilar.UseVisualStyleBackColor = false;
            this.l_compilar.Click += new System.EventHandler(this.L_compilarClick);
            this.l_compilar.MouseEnter += new System.EventHandler(this.L_compilarMouseEnter);
            this.l_compilar.MouseLeave += new System.EventHandler(this.L_compilarMouseLeave);
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Image = global::Entorno_desarrollo.Imagenes.separador;
            this.label3.Location = new System.Drawing.Point(95, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 19);
            this.label3.TabIndex = 17;
            // 
            // l_eliminar
            // 
            this.l_eliminar.BackColor = System.Drawing.Color.Transparent;
            this.l_eliminar.BackgroundImage = global::Entorno_desarrollo.Imagenes.cerrar;
            this.l_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_eliminar.ForeColor = System.Drawing.Color.Transparent;
            this.l_eliminar.Location = new System.Drawing.Point(189, 4);
            this.l_eliminar.Name = "l_eliminar";
            this.l_eliminar.Size = new System.Drawing.Size(21, 20);
            this.l_eliminar.TabIndex = 16;
            this.l_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_eliminar.UseVisualStyleBackColor = false;
            this.l_eliminar.Click += new System.EventHandler(this.L_eliminarClick);
            this.l_eliminar.MouseEnter += new System.EventHandler(this.L_eliminarMouseEnter);
            this.l_eliminar.MouseLeave += new System.EventHandler(this.L_eliminarMouseLeave);
            // 
            // l_pegar
            // 
            this.l_pegar.BackColor = System.Drawing.Color.Transparent;
            this.l_pegar.BackgroundImage = global::Entorno_desarrollo.Imagenes.pegar;
            this.l_pegar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_pegar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_pegar.ForeColor = System.Drawing.Color.Transparent;
            this.l_pegar.Location = new System.Drawing.Point(163, 4);
            this.l_pegar.Name = "l_pegar";
            this.l_pegar.Size = new System.Drawing.Size(21, 20);
            this.l_pegar.TabIndex = 15;
            this.l_pegar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_pegar.UseVisualStyleBackColor = false;
            this.l_pegar.Click += new System.EventHandler(this.L_pegarClick);
            this.l_pegar.MouseEnter += new System.EventHandler(this.L_pegarMouseEnter);
            this.l_pegar.MouseLeave += new System.EventHandler(this.L_pegarMouseLeave);
            // 
            // l_copiar
            // 
            this.l_copiar.BackColor = System.Drawing.Color.Transparent;
            this.l_copiar.BackgroundImage = global::Entorno_desarrollo.Imagenes.copiar;
            this.l_copiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_copiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_copiar.ForeColor = System.Drawing.Color.Transparent;
            this.l_copiar.Location = new System.Drawing.Point(136, 4);
            this.l_copiar.Name = "l_copiar";
            this.l_copiar.Size = new System.Drawing.Size(21, 20);
            this.l_copiar.TabIndex = 14;
            this.l_copiar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_copiar.UseVisualStyleBackColor = false;
            this.l_copiar.Click += new System.EventHandler(this.L_copiarClick);
            this.l_copiar.MouseEnter += new System.EventHandler(this.L_copiarMouseEnter);
            this.l_copiar.MouseLeave += new System.EventHandler(this.L_copiarMouseLeave);
            // 
            // l_cortar
            // 
            this.l_cortar.BackColor = System.Drawing.Color.Transparent;
            this.l_cortar.BackgroundImage = global::Entorno_desarrollo.Imagenes.cortar;
            this.l_cortar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_cortar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_cortar.ForeColor = System.Drawing.Color.Transparent;
            this.l_cortar.Location = new System.Drawing.Point(108, 5);
            this.l_cortar.Name = "l_cortar";
            this.l_cortar.Size = new System.Drawing.Size(21, 20);
            this.l_cortar.TabIndex = 13;
            this.l_cortar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_cortar.UseVisualStyleBackColor = false;
            this.l_cortar.Click += new System.EventHandler(this.L_cortarClick);
            this.l_cortar.MouseEnter += new System.EventHandler(this.L_cortarMouseEnter);
            this.l_cortar.MouseLeave += new System.EventHandler(this.L_cortarMouseLeave);
            // 
            // l_guardar
            // 
            this.l_guardar.BackColor = System.Drawing.Color.Transparent;
            this.l_guardar.BackgroundImage = global::Entorno_desarrollo.Imagenes.guardar;
            this.l_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_guardar.ForeColor = System.Drawing.Color.Transparent;
            this.l_guardar.Location = new System.Drawing.Point(73, 3);
            this.l_guardar.Name = "l_guardar";
            this.l_guardar.Size = new System.Drawing.Size(21, 23);
            this.l_guardar.TabIndex = 12;
            this.l_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_guardar.UseVisualStyleBackColor = false;
            this.l_guardar.Click += new System.EventHandler(this.L_guardarClick);
            this.l_guardar.MouseEnter += new System.EventHandler(this.L_guardarMouseEnter);
            this.l_guardar.MouseLeave += new System.EventHandler(this.L_guardarMouseLeave);
            // 
            // l_abrir
            // 
            this.l_abrir.BackColor = System.Drawing.Color.Transparent;
            this.l_abrir.BackgroundImage = global::Entorno_desarrollo.Imagenes.abrir;
            this.l_abrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_abrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_abrir.ForeColor = System.Drawing.Color.Transparent;
            this.l_abrir.Location = new System.Drawing.Point(47, 2);
            this.l_abrir.Name = "l_abrir";
            this.l_abrir.Size = new System.Drawing.Size(21, 23);
            this.l_abrir.TabIndex = 11;
            this.l_abrir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_abrir.UseVisualStyleBackColor = false;
            this.l_abrir.Click += new System.EventHandler(this.L_abrirClick);
            this.l_abrir.MouseEnter += new System.EventHandler(this.L_abrirMouseEnter);
            this.l_abrir.MouseLeave += new System.EventHandler(this.L_abrirMouseLeave);
            // 
            // l_nuevo
            // 
            this.l_nuevo.BackColor = System.Drawing.Color.Transparent;
            this.l_nuevo.BackgroundImage = global::Entorno_desarrollo.Imagenes.nuevo;
            this.l_nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.l_nuevo.ForeColor = System.Drawing.Color.Transparent;
            this.l_nuevo.Location = new System.Drawing.Point(20, 2);
            this.l_nuevo.Name = "l_nuevo";
            this.l_nuevo.Size = new System.Drawing.Size(21, 23);
            this.l_nuevo.TabIndex = 10;
            this.l_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.l_nuevo.UseVisualStyleBackColor = false;
            this.l_nuevo.Click += new System.EventHandler(this.L_nuevoClick);
            this.l_nuevo.MouseEnter += new System.EventHandler(this.L_nuevoMouseEnter);
            this.l_nuevo.MouseLeave += new System.EventHandler(this.L_nuevoMouseLeave);
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Image = global::Entorno_desarrollo.Imagenes.separador;
            this.label2.Location = new System.Drawing.Point(211, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 19);
            this.label2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(95, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 19);
            this.label1.TabIndex = 3;
            // 
            // titulo
            // 
            this.titulo.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titulo.Location = new System.Drawing.Point(37, 59);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(287, 25);
            this.titulo.TabIndex = 2;
            this.titulo.Text = "Código a compilar (Sin titulo)";
            this.titulo.Click += new System.EventHandler(this.titulo_Click);
            // 
            // codigo
            // 
            this.codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigo.Location = new System.Drawing.Point(40, 81);
            this.codigo.Name = "codigo";
            this.codigo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.codigo.Size = new System.Drawing.Size(518, 326);
            this.codigo.TabIndex = 3;
            this.codigo.Text = "";
            this.codigo.VScroll += new System.EventHandler(this.CodigoVScroll);
            this.codigo.TextChanged += new System.EventHandler(this.CodigoTextChanged);
            this.codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoKeyDown);
            this.codigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CodigoKeyUp);
            this.codigo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CodigoMouseUp);
            // 
            // Errores
            // 
            this.Errores.Controls.Add(this.ventana_error);
            this.Errores.Controls.Add(this.ventana_resultado);
            this.Errores.Location = new System.Drawing.Point(12, 421);
            this.Errores.Name = "Errores";
            this.Errores.SelectedIndex = 0;
            this.Errores.Size = new System.Drawing.Size(546, 156);
            this.Errores.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.Errores.TabIndex = 4;
            // 
            // ventana_error
            // 
            this.ventana_error.BackColor = System.Drawing.Color.White;
            this.ventana_error.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ventana_error.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ventana_error.Controls.Add(this.errores_a);
            this.ventana_error.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ventana_error.Location = new System.Drawing.Point(4, 22);
            this.ventana_error.Name = "ventana_error";
            this.ventana_error.Padding = new System.Windows.Forms.Padding(3);
            this.ventana_error.Size = new System.Drawing.Size(538, 130);
            this.ventana_error.TabIndex = 0;
            this.ventana_error.Text = "Errores";
            this.ventana_error.UseVisualStyleBackColor = true;
            // 
            // errores_a
            // 
            this.errores_a.Location = new System.Drawing.Point(-2, -2);
            this.errores_a.Name = "errores_a";
            this.errores_a.Size = new System.Drawing.Size(538, 134);
            this.errores_a.TabIndex = 0;
            this.errores_a.Text = "";
            // 
            // ventana_resultado
            // 
            this.ventana_resultado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ventana_resultado.Location = new System.Drawing.Point(4, 22);
            this.ventana_resultado.Name = "ventana_resultado";
            this.ventana_resultado.Padding = new System.Windows.Forms.Padding(3);
            this.ventana_resultado.Size = new System.Drawing.Size(538, 130);
            this.ventana_resultado.TabIndex = 1;
            this.ventana_resultado.Text = "Resultado";
            this.ventana_resultado.UseVisualStyleBackColor = true;
            this.ventana_resultado.Click += new System.EventHandler(this.Ventana_resultadoClick);
            // 
            // codigoIntermedio_a
            // 
            this.codigoIntermedio_a.Location = new System.Drawing.Point(-2, -2);
            this.codigoIntermedio_a.Name = "codigoIntermedio_a";
            this.codigoIntermedio_a.Size = new System.Drawing.Size(538, 200);
            this.codigoIntermedio_a.TabIndex = 0;
            this.codigoIntermedio_a.Text = "";
            // 
            // o
            // 
            this.o.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.o.Controls.Add(this.semantico);
            this.o.Controls.Add(this.cod_intermedio);
            this.o.Location = new System.Drawing.Point(580, 334);
            this.o.Name = "o";
            this.o.SelectedIndex = 0;
            this.o.Size = new System.Drawing.Size(323, 243);
            this.o.TabIndex = 6;
            // 
            // semantico
            // 
            this.semantico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.semantico.Controls.Add(this.treeSemantico);
            this.semantico.Location = new System.Drawing.Point(4, 22);
            this.semantico.Name = "semantico";
            this.semantico.Padding = new System.Windows.Forms.Padding(3);
            this.semantico.Size = new System.Drawing.Size(315, 217);
            this.semantico.TabIndex = 0;
            this.semantico.Text = "Semantico";
            this.semantico.UseVisualStyleBackColor = true;
            // 
            // treeSemantico
            // 
            this.treeSemantico.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeSemantico.FullRowSelect = true;
            this.treeSemantico.Indent = 19;
            this.treeSemantico.Location = new System.Drawing.Point(-2, -2);
            this.treeSemantico.Name = "treeSemantico";
            this.treeSemantico.Size = new System.Drawing.Size(315, 219);
            this.treeSemantico.TabIndex = 1;
            // 
            // cod_intermedio
            // 
            this.cod_intermedio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cod_intermedio.Controls.Add(this.codigoIntermedio_a);
            this.cod_intermedio.Location = new System.Drawing.Point(4, 22);
            this.cod_intermedio.Name = "cod_intermedio";
            this.cod_intermedio.Padding = new System.Windows.Forms.Padding(3);
            this.cod_intermedio.Size = new System.Drawing.Size(315, 217);
            this.cod_intermedio.TabIndex = 10;
            this.cod_intermedio.Text = "Codigo Intermedio";
            this.cod_intermedio.UseVisualStyleBackColor = true;
            // 
            // treeCodIntermedio
            // 
            this.treeCodIntermedio.LineColor = System.Drawing.Color.Empty;
            this.treeCodIntermedio.Location = new System.Drawing.Point(0, 0);
            this.treeCodIntermedio.Name = "treeCodIntermedio";
            this.treeCodIntermedio.Size = new System.Drawing.Size(121, 97);
            this.treeCodIntermedio.TabIndex = 0;
            // 
            // posicion
            // 
            this.posicion.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posicion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.posicion.Location = new System.Drawing.Point(182, 410);
            this.posicion.Name = "posicion";
            this.posicion.Size = new System.Drawing.Size(376, 17);
            this.posicion.TabIndex = 8;
            this.posicion.Text = "Longitud: 0 Ln: 1 Col:  1";
            this.posicion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.posicion.Click += new System.EventHandler(this.posicion_Click);
            // 
            // sintactico
            // 
            this.sintactico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sintactico.Controls.Add(this.tree);
            this.sintactico.Location = new System.Drawing.Point(4, 22);
            this.sintactico.Name = "sintactico";
            this.sintactico.Padding = new System.Windows.Forms.Padding(3);
            this.sintactico.Size = new System.Drawing.Size(315, 206);
            this.sintactico.TabIndex = 1;
            this.sintactico.Text = "Sintactico";
            this.sintactico.UseVisualStyleBackColor = true;
            // 
            // tree
            // 
            this.tree.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree.FullRowSelect = true;
            this.tree.Indent = 19;
            this.tree.Location = new System.Drawing.Point(-2, 1);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(315, 203);
            this.tree.TabIndex = 0;
            // 
            // lexico
            // 
            this.lexico.BackColor = System.Drawing.Color.White;
            this.lexico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lexico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lexico.Controls.Add(this.tabla);
            this.lexico.Location = new System.Drawing.Point(4, 22);
            this.lexico.Name = "lexico";
            this.lexico.Padding = new System.Windows.Forms.Padding(3);
            this.lexico.Size = new System.Drawing.Size(315, 206);
            this.lexico.TabIndex = 0;
            this.lexico.Text = "Lexico";
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.AllowUserToResizeRows = false;
            this.tabla.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabla.Location = new System.Drawing.Point(-2, -2);
            this.tabla.Name = "tabla";
            this.tabla.ReadOnly = true;
            this.tabla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tabla.Size = new System.Drawing.Size(315, 206);
            this.tabla.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.lexico);
            this.tabControl1.Controls.Add(this.sintactico);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(580, 81);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(323, 232);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabla_simbolos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(315, 206);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Tabla de símbolos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabla_simbolos
            // 
            this.tabla_simbolos.AllowUserToAddRows = false;
            this.tabla_simbolos.AllowUserToDeleteRows = false;
            this.tabla_simbolos.AllowUserToResizeRows = false;
            this.tabla_simbolos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabla_simbolos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabla_simbolos.Location = new System.Drawing.Point(-1, 0);
            this.tabla_simbolos.Name = "tabla_simbolos";
            this.tabla_simbolos.ReadOnly = true;
            this.tabla_simbolos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tabla_simbolos.Size = new System.Drawing.Size(316, 205);
            this.tabla_simbolos.TabIndex = 10;
            // 
            // lineas
            // 
            this.lineas.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lineas.Location = new System.Drawing.Point(0, 84);
            this.lineas.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lineas.Name = "lineas";
            this.lineas.Size = new System.Drawing.Size(34, 323);
            this.lineas.TabIndex = 7;
            this.lineas.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n21\r\n22\r\n23" +
    "\r\n24\r\n25\r\n26\r\n27\r\n28\r\n29\r\n30\r\n31";
            this.lineas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(915, 587);
            this.Controls.Add(this.posicion);
            this.Controls.Add(this.lineas);
            this.Controls.Add(this.o);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Errores);
            this.Controls.Add(this.codigo);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kuchao Development";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Errores.ResumeLayout(false);
            this.ventana_error.ResumeLayout(false);
            this.o.ResumeLayout(false);
            this.semantico.ResumeLayout(false);
            this.cod_intermedio.ResumeLayout(false);
            this.sintactico.ResumeLayout(false);
            this.lexico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_simbolos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		public System.Windows.Forms.TreeView treeSemantico;
		public System.Windows.Forms.TreeView treeCodIntermedio;
		private System.Windows.Forms.DataGridView tabla_simbolos;
		private System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.RichTextBox errores_a;
		private System.Windows.Forms.RichTextBox codigoIntermedio_a;
		private System.Windows.Forms.DataGridView tabla;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button l_eliminar;
		private System.Windows.Forms.Button l_nuevo;
		private System.Windows.Forms.ToolStripMenuItem colorTextoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem colorComentariosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem colorLetras2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem colorLetras1ToolStripMenuItem;
		private System.Windows.Forms.Button l_compilar;
		private System.Windows.Forms.ToolStripMenuItem colorFondoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button l_cortar;
		private System.Windows.Forms.Button l_copiar;
		private System.Windows.Forms.Button l_pegar;
		private System.Windows.Forms.ToolStripMenuItem borrarDelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pegarCtrlVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copiarCtrlCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
		private System.Windows.Forms.Label posicion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button l_guardar;
		private System.Windows.Forms.Button l_abrir;
		private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
		private System.Windows.Forms.TabPage cod_intermedio;
		private System.Windows.Forms.TabPage semantico;
		private System.Windows.Forms.TabControl o;
		private System.Windows.Forms.TabPage sintactico;
		private System.Windows.Forms.TabPage lexico;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage ventana_resultado;
		private System.Windows.Forms.TabPage ventana_error;
		private System.Windows.Forms.TabControl Errores;
		private System.Windows.Forms.RichTextBox codigo;
		private System.Windows.Forms.Label titulo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lineas;
    }
}
