using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Entorno_desarrollo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string ruta_archivo;
		private string nombre;// nombre del codigo
		private string manejo_texto; // para cuando copian ó cortan texto
		private Color c_texto;// color para el texto normal
		private Color c_1;// color para las palabras reservadas if,else,while,etc..
		private Color c_2;// color para los identificadores int,float,etc..
		private Color c_3;// color para los  comentarios
		public int pos;
        public int t_index;
        public int loop_index;
        public string current_t;
        public StreamWriter wf;
		public MainForm()
		{
			InitializeComponent();
			try{
			pintaerror =1;
			// incializamos variables
			pos =0 ;
			codigo.Text ="";
	      	archivo_colores(); //obtiene los colores del tema
	      	// Create the ToolTip and associate with the Form container.
	         ToolTip toolTip1 = new ToolTip();
	
	         // Set up the delays for the ToolTip.
	         toolTip1.AutoPopDelay = 5000;
	         toolTip1.InitialDelay = 1000;
	         toolTip1.ReshowDelay = 500;
	         // Force the ToolTip text to be displayed whether or not the form is active.
	         toolTip1.ShowAlways = true;
	         //a_lexico.Visible = false;
	
	         // Set up the ToolTip text for the Button and Checkbox.
	         toolTip1.SetToolTip(this.l_nuevo, "Crea un nuevo archivo");
	     	 toolTip1.SetToolTip(this.l_abrir, "Abrir archivo");
		     toolTip1.SetToolTip(this.l_guardar, "Guardar archivo");
	      	 toolTip1.SetToolTip(this.l_cortar, "Cortar texto seleccionado");
	      	 toolTip1.SetToolTip(this.l_copiar, "Copiar texto seleccionado");
	      	 toolTip1.SetToolTip(this.l_pegar, "Pegar texto");
	      	 toolTip1.SetToolTip(this.l_eliminar, "Borrar");
	      	 toolTip1.SetToolTip(this.l_compilar, "Compilar código");
			}
			catch(Exception e){MessageBox.Show("Se ha producido un error en el compilador\nEste sera cerrado\nDISCULPE LAS MOLESTIAS", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		public void archivo_colores(){
			StreamReader objReader = new StreamReader("c_1.txt"); // objeto para abrir un archivo en modo lectura
            string sLine = ""; // string que contendra el contenido del archivo
            try
            {
                sLine = objReader.ReadLine();// leemos todo el contenido del archivo
                c_1 = Color.FromName(sLine); // obtenemos el color
                objReader.Close();
                
                objReader = new StreamReader("c_2.txt");
                sLine = objReader.ReadLine();// leemos todo el contenido del archivo
                c_2 = Color.FromName(sLine); // obtenemos el color
                objReader.Close();
                
                objReader = new StreamReader("c_3.txt");
                sLine = objReader.ReadLine();// leemos todo el contenido del archivo
                c_3 = Color.FromName(sLine); // obtenemos el color
                objReader.Close();
                
                objReader = new StreamReader("c_texto.txt");
                sLine = objReader.ReadLine();// leemos todo el contenido del archivo
                c_texto= Color.FromName(sLine); // obtenemos el color
                objReader.Close();
                codigo.ForeColor = c_texto;
                
                objReader = new StreamReader("c_fondo.txt");
                sLine = objReader.ReadLine();// leemos todo el contenido del archivo
                objReader.Close();
                
                codigo.BackColor = Color.FromName(sLine);
       			ventana_error.BackColor = Color.FromName(sLine);
       			ventana_resultado.BackColor = Color.FromName(sLine);
       			lexico.BackColor = Color.FromName(sLine);
       			sintactico.BackColor = Color.FromName(sLine);
       			semantico.BackColor = Color.FromName(sLine);
       			cod_intermedio.BackColor = Color.FromName(sLine);
                
            }
            catch (Exception e)// por si se presento una excepcion
            {
                Console.WriteLine("The process failed: {0}", e.ToString()); // mostramos el error presentado
            }		
		}
		
		void AbrirToolStripMenuItemClick(object sender, EventArgs e)
		{
				if(titulo.Text == "Código a compilar (Sin titulo)"){ // checamos si escribieron algo
					DialogResult result1 = MessageBox.Show("Deseas guardar los cambios hechos a \"Sin titulo\"?",
			                                       "Guardar",MessageBoxButtons.YesNoCancel,
			                                       MessageBoxIcon.Question);
					if(result1 == DialogResult.Yes){// si contestaron que si, mandamos llamar la funcion de guardar como
						GuardarComoToolStripMenuItemClick(sender,e);// funcion de guardar como
						codigo.Text=""; // limpiamos la pantalla para escritura
						abrir();
					}
					if(result1 != DialogResult.Cancel){// si contestaron que no, simplemente limpiamos la pantalla
						codigo.Text=""; // limpiamos la pantalla para escritura
						titulo.Text = "Código a compilar (Sin titulo)";// reiniciamos el titulo del codigo
						abrir();
					}
				}				
				else{// ó si hicieron cambios a un documento
					DialogResult result1 = MessageBox.Show("Deseas guardar los cambios hechos a \""+ nombre +"\"?",
			                                       "Guardar",MessageBoxButtons.YesNoCancel,
			                                       MessageBoxIcon.Question);
					if(result1 == DialogResult.Yes){// si contestaron que si, mandamos llamar la funcion de guardar 
						GuardarToolStripMenuItemClick(sender,e);// funcion de guardar
						abrir();
					}
					if(result1 != DialogResult.Cancel){// si contestaron que no, simplemente limpiamos la pantalla
						codigo.Text=""; // limpiamos la pantalla para escritura
						abrir();
					}
				}
		}
		
		private void abrir(){
			string path =""; // variable para guardar la ruta del archivo, que se elijio
            OpenFileDialog file = new OpenFileDialog(); // abrimos la ventana
            if (file.ShowDialog() == DialogResult.OK) // checamos que no se haya presentado un error al elegir un archivo
            {
                path = file.FileName;// guardamos la ruta del archivo
                ruta_archivo = path; // guardamos la ruta del archivo abierto
            }
            if(path != ""){ // checamos que hayan seleccionado un archivo, para evitar un error
	            nombre = Path.GetFileNameWithoutExtension(file.FileName); // guardamos el nombre del codigo
            	leer(path); // mandamos llamar la funcion que lee el archivo
	            l_guardar.Focus(); // quitamos el foco del texto, por que podria quedar textoi subrayado
            }
		}
		
		private void leer(string ruta)// funcion que lee el contenido del archivo
        {
            StreamReader objReader = new StreamReader(ruta); // objeto para abrir un archivo en modo lectura
            string sLine = ""; // string que contendra el contenido del archivo
            try
            {
                sLine = objReader.ReadToEnd();// leemos todo el contenido del archivo
                codigo.Text = sLine;// Mostramos el contenido del archivo
                titulo.Text = "Codigo a compilar ( " + Path.GetFileNameWithoutExtension(ruta) + " ) ";// mostramos el nombre del archivo
                objReader.Close();
                busqueda(0,codigo.TextLength); // buscamos las palabras que se tienen que colorear
            }
            catch (Exception e)// por si se presento una excepcion
            {
                Console.WriteLine("The process failed: {0}", e.ToString()); // mostramos el error presentado
            }		
        }// fin de funcion que lee el contenido del archivo
		
		
		private void busqueda(int inicio,int fin){
			
				// coloreamos las palabras reservadas
                buscacolorea("if",inicio,fin,0); // mandamos que palabra buscar, donde empezar a buscar y donde terminar
                buscacolorea("then",inicio,fin,0);
                buscacolorea("else",inicio,fin,0);
                buscacolorea("fi",inicio,fin,0);
                buscacolorea("do",inicio,fin,0);
                buscacolorea("until",inicio,fin,0);
                buscacolorea("while",inicio,fin,0);
                buscacolorea("read",inicio,fin,0);
                buscacolorea("write",inicio,fin,0);	
                // coloreamos los identificadores de tipo
                buscacolorea("float",inicio,fin,0);
                buscacolorea("int",inicio,fin,0);
                buscacolorea("bool",inicio,fin,0);
				buscacolorea("program",inicio,fin,0);                
				// coloreamos los comentarios
				buscacolorea("//",inicio,fin,1);
                buscacolorea("/*",inicio,fin,1);
        	
		}
		
		private void buscacolorea(string sen, int inicio, int tam, int desicion){// funcion que busca una sentencia para colorearla diferente del resto(palabra reservada)
			while(inicio <=tam){// buscamos hasta que termine el texto
				if(desicion ==0 )
					inicio = codigo.Find(sen,inicio,RichTextBoxFinds.WholeWord) + 1;
              	else
              		inicio = codigo.Find(sen,inicio,RichTextBoxFinds.MatchCase) + 1;
              	if(sen =="//" && inicio != 0){ // hacemos esto, para colorear todo el comentario
              		string currentlinetext = codigo.Lines[codigo.GetLineFromCharIndex(inicio)];// obtenemos la linea en que nos encontramos actualmente
              		int aux = currentlinetext.IndexOf("//");// buscamos en donde inicia el comentario (dentro de la linea)
              		codigo.Select(inicio-1,currentlinetext.Length - aux);// coloreamos el comentario, desde donde empieza, hasta el final de la linea
              	}
              	if(sen =="/*" && inicio != 0){ // hacemos esto, para colorear todo el comentario
              		int final = codigo.Find("*/",inicio,RichTextBoxFinds.MatchCase);// buscamos en donde termina el comentario
              		if(final == -1){
              			final=codigo.TextLength-2;
              		}
              		codigo.Select(inicio-1,final-inicio+3);// coloreamos el comentario, desde donde empieza, hasta el final de este
              		inicio = final +1;// reposicionamos el inicio para continuar con la busqueda de mas comentarios, el +3 es para
              		// que tambien tome en cuenta al colorear los simbolos */
              	}

              	if(inicio == 0)// quiere decir que ya no encontro coincidencias y rompemos el ciclo
	      			break;
	      		if(sen == "if" || sen == "then" || sen == "else" || sen == "fi" || sen == "do" || sen == "until" || sen == "while" 
	      		   || sen == "read" || sen == "write")// checamos si las vamos a pintar de color 1
	      			sentencias1();// madamos pintar diferente lo que encontro
	      		else if(sen == "float" || sen == "int" || sen == "bool" || sen == "program")
	      			sentencias2();// madamos pintar diferente lo que encontro
	      		else
	      			sentencias3();
	      		
            }
		}
		
		private void sentencias1(){// funcion que pinta de otro color, texto encontrado
			codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
	    	codigo.SelectionColor = c_1;
		}
		
		private void sentencias2(){// funcion que pinta de otro color, texto encontrado
			codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Bold);
	    	codigo.SelectionColor = c_2;
		}
		
		private void sentencias3(){// funcion que pinta de otro color, texto encontrado
			codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
	    	codigo.SelectionColor = c_3;
		}
		
		void NuevoToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(codigo.Text != "" || titulo.Text != "Código a compilar (Sin titulo)"){// checamos si han escrito algo o si han abierto un docuemtno y hecho cambios
				if(titulo.Text == "Código a compilar (Sin titulo)"){ // checamos si escribieron algo
					DialogResult result1 = MessageBox.Show("Deseas guardar los cambios hechos a \"Sin titulo\"?",
			                                       "Guardar",MessageBoxButtons.YesNoCancel,
			                                       MessageBoxIcon.Question);
					if(result1 == DialogResult.Yes){// si contestaron que si, mandamos llamar la funcion de guardar como
						GuardarComoToolStripMenuItemClick(sender,e);// funcion de guardar como
					}
					if(result1 != DialogResult.Cancel){// si contestaron que no, simplemente limpiamos la pantalla
						codigo.Text=""; // limpiamos la pantalla para escritura
						titulo.Text = "Código a compilar (Sin titulo)";// reiniciamos el titulo del codigo
					}
				}				
				else{// ó si hicieron cambios a un documento
					DialogResult result1 = MessageBox.Show("Deseas guardar los cambios hechos a \""+ nombre +"\"?",
			                                       "Guardar",MessageBoxButtons.YesNoCancel,
			                                       MessageBoxIcon.Question);
					if(result1 == DialogResult.Yes){// si contestaron que si, mandamos llamar la funcion de guardar 
						GuardarToolStripMenuItemClick(sender,e);// funcion de guardar
					}
					if(result1 != DialogResult.Cancel){// si contestaron que no, simplemente limpiamos la pantalla
						codigo.Text=""; // limpiamos la pantalla para escritura
						titulo.Text = "Código a compilar (Sin titulo)";// reiniciamos el titulo del codigo
					}
				}
			}
		}
		
		
		void GuardarToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(titulo.Text == "Código a compilar (Sin titulo)"){// checamos si se escribio en un archivo sin titulo
				GuardarComoToolStripMenuItemClick(sender,e); // mandamos llamar la funcion de guardar como
			}
			else{ // si no, guardamos en el archivo abierto
				StreamWriter objWriter = new StreamWriter(ruta_archivo); // objeto para abrir un archivo en modo escritura
            	objWriter.Write(codigo.Text);
            	objWriter.Close();
            	MessageBox.Show("Archivo Guardado","Archivo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
        }
		
		void GuardarComoToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveFileDialog file = new SaveFileDialog(); // abrimos la ventana para guardar el archivo
            file.Title = "Save text Files";// titulo de la ventana
            file.CheckPathExists = true; // checa si existe la ruta
            file.DefaultExt = "txt"; // la extension por default es txt
            file.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // filtra los archivos por todos ó txt
            file.FilterIndex = 2;
            file.RestoreDirectory = true;     
            if (file.ShowDialog() == DialogResult.OK) // checamos que no se haya presentado un error al mostrar la ventana
            {
                titulo.Text = "Codigo a compilar ( " + Path.GetFileNameWithoutExtension(file.FileName) + " ) ";// mostramos el nombre del archivo
 				nombre = Path.GetFileNameWithoutExtension(file.FileName); // guardamos el nombre del codigo
                ruta_archivo = file.FileName; // guardamos la ruta del archivo abierto
                StreamWriter objWriter = new StreamWriter(file.FileName); // objeto para abrir un archivo en modo escritura
                objWriter.Write(codigo.Text); // escribirmos el codigo en el archivo
                objWriter.Close();// cerramos el objeto que escribe
            }
		}
		
		void CerrarToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();// terminamos la aplicacion
		}
		
		
		void L_nuevoClick(object sender, EventArgs e)// icono de nuevo
		{
			NuevoToolStripMenuItemClick(sender,e);// mismo funcionamiento que Nuevo
		}
		
		void L_abrirClick(object sender, EventArgs e)// icono de abrir
		{
			AbrirToolStripMenuItemClick(sender,e);// mismo funcionamiento que Abrir
		}
		
		void L_guardarClick(object sender, EventArgs e)// icono de guardar
		{
			GuardarToolStripMenuItemClick(sender,e);// mismo funcionamiento que Guardar
		}
		
		
		void CodigoMouseUp(object sender, MouseEventArgs e)// cuando hacen clic, actualizamos la posicion del caret
		{
			int position = codigo.SelectionStart; // encontramos la posicion actual
			int line = codigo.GetLineFromCharIndex(position);// obtenemos el numero de linea 
			int col = position - codigo.GetFirstCharIndexFromLine(line);// obtenemos el numero de la columna
			posicion.Text = "Longitud: "+codigo.Text.Length +" Ln: "+(line+1) +" Col: "+(col+1); // actualizamos la etiqueta que nos muestra la informacion		
		}
		

		
		void CodigoKeyUp(object sender, KeyEventArgs e)
		{
			
			/*
			int inicial = codigo.SelectionStart;
			codigo.Enabled = false;
			//codigo.SelectAll();
			//codigo.SelectionColor = c_texto;
			//codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
			//busqueda(0,codigo.TextLength);
			
		
			
			int position2 = codigo.SelectionStart; // encontramos la posicion actual
			int line22 = codigo.GetLineFromCharIndex(position2);// obtenemos el numero de linea 
			int x=0;
			if(line22 != 0){
				while(codigo.GetLineFromCharIndex(position2) == line22){
					position2--;
					x++;
				}
			}
			if(x !=0)
				x--;
			string currentlinetext;
			if(codigo.TextLength != 0)
				currentlinetext = codigo.Lines[codigo.GetLineFromCharIndex(inicial)];// obtenemos la linea en que nos encontramos actualmente
            else
            	currentlinetext ="";
			
			int i;
			if(x==0)
				i = 0;
			else
				i = inicial-1;
			codigo.Select(i-x,currentlinetext.Length+1);
			codigo.SelectionColor = c_texto;
			codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
		
			busqueda(i-x,((i-x)+currentlinetext.Length));
	
			buscacolorea("/*",0,codigo.TextLength,1);
			a.Text = ""+(i-x)+" "+((inicial-x)+currentlinetext.Length);
		
			
			codigo.Enabled = true;
			codigo.Select(inicial,0);
			codigo.Focus();
			
			int position = codigo.SelectionStart; // encontramos la posicion actual
			int line2 = codigo.GetLineFromCharIndex(position);// obtenemos el numero de linea 
			int col = position - codigo.GetFirstCharIndexFromLine(line2);// obtenemos el numero de la columna
			posicion.Text = "Longitud: "+codigo.Text.Length +" Ln: "+(line2+1) +" Col: "+(col+1); // actualizamos la etiqueta que nos muestra la informacion		
			
			/*
			int inicial = codigo.SelectionStart;
			codigo.Enabled = false;
			codigo.SelectAll();
			codigo.SelectionColor = c_texto;
			codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
			busqueda(0,codigo.TextLength);
			
			codigo.Enabled = true;
			codigo.Select(inicial,0);
			codigo.Focus();
			
			int position = codigo.SelectionStart; // encontramos la posicion actual
			int line2 = codigo.GetLineFromCharIndex(position);// obtenemos el numero de linea 
			int col = position - codigo.GetFirstCharIndexFromLine(line2);// obtenemos el numero de la columna
			posicion.Text = "Longitud: "+codigo.Text.Length +" Ln: "+(line2+1) +" Col: "+(col+1); // actualizamos la etiqueta que nos muestra la informacion		
			*/		
		}
		
		void PegarCtrlVToolStripMenuItemClick(object sender, EventArgs e)
		{
			codigo.SelectedRtf = manejo_texto; // añadimos el texto
		}
		
		void CortarToolStripMenuItemClick(object sender, EventArgs e)
		{
			manejo_texto = codigo.SelectedRtf; // obtenemos el texto que se cortara
			codigo.SelectedRtf ="";// quitamos el texto cortado
		}
		
		void CopiarCtrlCToolStripMenuItemClick(object sender, EventArgs e)
		{
			manejo_texto = codigo.SelectedRtf;// copiamos el texto seleccionado
		}
		
		void BorrarDelToolStripMenuItemClick(object sender, EventArgs e)
		{
			codigo.SelectedText = ""; // borramos el texto
		}

		void ColorFondoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ColorDialog MyDialog = new ColorDialog();// abrimos el selector de color
			if (MyDialog.ShowDialog() == DialogResult.OK){ // cambiamos los fondos
       			codigo.BackColor =  MyDialog.Color;
       			ventana_error.BackColor = MyDialog.Color;
       			ventana_resultado.BackColor = MyDialog.Color;
       			lexico.BackColor = MyDialog.Color;
       			sintactico.BackColor = MyDialog.Color;
       			semantico.BackColor = MyDialog.Color;
       			cod_intermedio.BackColor = MyDialog.Color;
       			
       			string fileName = "c_fondo.txt";
			    FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			    StreamWriter writer = new StreamWriter(stream);
			
			    writer.WriteLine(MyDialog.Color.Name);
			    writer.Close();
			}
		}
		
		void CodigoVScroll(object sender, EventArgs e)
		{
		    updateNumberLabel(); // mandamos actualizar la etiqueta
		}
		
		
		private void updateNumberLabel()
		{
		    //we get index of first visible char and 
		    //number of first visible line
		    Point pos = new Point(0, 0);
		    int firstIndex = codigo.GetCharIndexFromPosition(pos);
		    int firstLine = codigo.GetLineFromCharIndex(firstIndex);
		
		    //now we get index of last visible char 
		    //and number of last visible line
		    pos.X = ClientRectangle.Width;
		    pos.Y = ClientRectangle.Height;
		    int lastIndex = codigo.GetCharIndexFromPosition(pos);
		    int lastLine = codigo.GetLineFromCharIndex(lastIndex);
		
		    //this is point position of last visible char, we'll 
		    //use its Y value for calculating numberLabel size
		    pos = codigo.GetPositionFromCharIndex(lastIndex);
		
		    //finally, renumber label
		    lineas.Text = "";
		    
		    int position = codigo.SelectionStart;
			int line = codigo.GetLineFromCharIndex(position);
			if(line <1)
				firstLine -=1;
		    for (int i = firstLine +1; i <= lastLine + 1; i++)
		    {
		       lineas.Text += i + 1 + "\n";
		    }
		}
		
		
		
		void CodigoKeyDown(object sender, KeyEventArgs e)
		{
			/*
			if(e.KeyValue == 8){
				// obtenemos un caracter anterior
				int pos = codigo.SelectionStart;
				int inicio;
				if(pos -1 <0)
					inicio = 0;
				else
					inicio = pos-1;
				codigo.Select(inicio,1);
				string uno = codigo.SelectedText;
				
				if(pos -2 <0)
					inicio = 0;
				else
					inicio = pos-2;
				codigo.Select(inicio,1);
				string dos = codigo.SelectedText;
				if(uno == "*" && dos == "/" && codigo.SelectionColor == c_3){
					int fin = codigo.Find("",inicio,RichTextBoxFinds.MatchCase); aqui fin de comentario
					/*if(fin == -1)
						fin = codigo.TextLength;
					codigo.Select(inicio,fin-inicio);
					codigo.SelectionColor = c_texto;
					busqueda(inicio,fin);
				}
				codigo.Select(pos,0);
			}*/
		}
		
		void ColorLetras1ToolStripMenuItemClick(object sender, EventArgs e) // color de palabras reservadas
		{
			ColorDialog MyDialog = new ColorDialog();// abrimos el selector de color
			if (MyDialog.ShowDialog() == DialogResult.OK){ // cambiamos los fondos
       			int pos = codigo.SelectionStart; // guardamos la posicion actual
       			c_1 = MyDialog.Color; // guardamos el nuevo color
       			busqueda(0,codigo.TextLength); // busquedamos las palabras que se colorean, para que se coloren de su color
				codigo.Select(pos,0); // volvemos a la posicion inicial
				
				string fileName = "c_1.txt";
			    FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			    StreamWriter writer = new StreamWriter(stream);
			
			    writer.WriteLine(c_1.Name);
			    writer.Close();
			}
		}
		
		void ColorTextoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ColorDialog MyDialog = new ColorDialog();// abrimos el selector de color
			if (MyDialog.ShowDialog() == DialogResult.OK){ // cambiamos el color del texto normal
				int pos = codigo.SelectionStart; // guardamos la posicion actual
				c_texto = MyDialog.Color; // obtenemos el color elegido
				codigo.SelectAll();// seleccionamos todo el texto, para cambiarle el color
				codigo.SelectionColor = c_texto; // cambiamos el color del texto
				codigo.ForeColor = c_texto;// designamos el nuevo color de texto
       			busqueda(0,codigo.TextLength); // busquedamos las palabras que se colorean, para que se coloren de su color
				codigo.Select(pos,0); // volvemos a la posicion inicial
				
				string fileName = "c_texto.txt";
			    FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			    StreamWriter writer = new StreamWriter(stream);
			
			    writer.WriteLine(MyDialog.Color.Name);
			    writer.Close();
			}
		}
		
		void ColorLetras2ToolStripMenuItemClick(object sender, EventArgs e)
		{
			ColorDialog MyDialog = new ColorDialog();// abrimos el selector de color
			if (MyDialog.ShowDialog() == DialogResult.OK){ // cambiamos los fondos
       			int pos = codigo.SelectionStart; // guardamos la posicion actual
       			c_2 = MyDialog.Color; // guardamos el nuevo color
       			busqueda(0,codigo.TextLength); // busquedamos las palabras que se colorean, para que se coloren de su color
				codigo.Select(pos,0); // volvemos a la posicion inicial
				
				string fileName = "c_2.txt";
			    FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			    StreamWriter writer = new StreamWriter(stream);
			
			    writer.WriteLine(c_2.Name);
			    writer.Close();
			}
		}
		
		void ColorComentariosToolStripMenuItemClick(object sender, EventArgs e)
		{
			ColorDialog MyDialog = new ColorDialog();// abrimos el selector de color
			if (MyDialog.ShowDialog() == DialogResult.OK){ // cambiamos los fondos
       			int pos = codigo.SelectionStart; // guardamos la posicion actual
       			c_3 = MyDialog.Color; // guardamos el nuevo color
       			busqueda(0,codigo.TextLength); // busquedamos las palabras que se colorean, para que se coloren de su color
				codigo.Select(pos,0); // volvemos a la posicion inicial
				
				string fileName = "c_3.txt";
			    FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			    StreamWriter writer = new StreamWriter(stream);
			
			    writer.WriteLine(c_3.Name);
			    writer.Close();
			}
		}
		
		void L_nuevoMouseEnter(object sender, EventArgs e)
		{
			l_nuevo.ForeColor = Color.LightSteelBlue;
		}
		
		void L_nuevoMouseLeave(object sender, EventArgs e)
		{
			l_nuevo.ForeColor = Color.Transparent;
		}
		
		void L_abrirMouseEnter(object sender, EventArgs e)
		{
			l_abrir.ForeColor = Color.LightSteelBlue;
		}
		
		void L_abrirMouseLeave(object sender, EventArgs e)
		{
			l_abrir.ForeColor = Color.Transparent;
		}
		
		void L_guardarMouseEnter(object sender, EventArgs e)
		{
			l_guardar.ForeColor = Color.LightSteelBlue;
		}
		
		void L_guardarMouseLeave(object sender, EventArgs e)
		{
			l_guardar.ForeColor = Color.Transparent;
		}
		
		void L_cortarMouseEnter(object sender, EventArgs e)
		{
			l_cortar.ForeColor = Color.LightSteelBlue;
		}
		
		void L_cortarMouseLeave(object sender, EventArgs e)
		{
			l_cortar.ForeColor = Color.Transparent;
		}
		
		void L_copiarMouseEnter(object sender, EventArgs e)
		{
			l_copiar.ForeColor = Color.LightSteelBlue;
		}
		
		void L_copiarMouseLeave(object sender, EventArgs e)
		{
			l_copiar.ForeColor = Color.Transparent;
		}
		
		void L_pegarMouseEnter(object sender, EventArgs e)
		{
			l_pegar.ForeColor = Color.LightSteelBlue;
		}
		
		void L_pegarMouseLeave(object sender, EventArgs e)
		{
			l_pegar.ForeColor = Color.Transparent;
		}
		
		void L_eliminarMouseEnter(object sender, EventArgs e)
		{
			l_eliminar.ForeColor = Color.LightSteelBlue;
		}
		
		void L_eliminarMouseLeave(object sender, EventArgs e)
		{
			l_eliminar.ForeColor = Color.Transparent;
		}
		
		void L_compilarMouseEnter(object sender, System.EventArgs e)
		{
			l_compilar.ForeColor = Color.LightSteelBlue;
		}
		
		void L_compilarMouseLeave(object sender, EventArgs e)
		{
			l_compilar.ForeColor = Color.Transparent;
		}
		
		void L_cortarClick(object sender, EventArgs e)
		{
			CortarToolStripMenuItemClick(sender,e);
		}
		
		void L_copiarClick(object sender, EventArgs e)
		{
			CopiarCtrlCToolStripMenuItemClick(sender,e);
		}
		
		void L_pegarClick(object sender, EventArgs e)
		{
			PegarCtrlVToolStripMenuItemClick(sender,e);
		}
		
		void L_eliminarClick(object sender, EventArgs e)
		{
			BorrarDelToolStripMenuItemClick(sender,e);
		}
		public int pintaerror;
		
		void CodigoTextChanged(object sender, EventArgs e)
		{
			int inicial = codigo.SelectionStart;
			codigo.Enabled = false;
			codigo.SelectAll();
			codigo.SelectionColor = c_texto;
			if(pintaerror == 1){
				codigo.SelectionBackColor = Color.White;
			}
			codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
			busqueda(0,codigo.TextLength);
			
		
			/*
			int position2 = codigo.SelectionStart; // encontramos la posicion actual
			int line22 = codigo.GetLineFromCharIndex(position2);// obtenemos el numero de linea 
			int x=0;
			if(line22 != 0){
				while(codigo.GetLineFromCharIndex(position2) == line22){
					position2--;
					x++;
				}
			}
			if(x !=0)
				x--;
			string currentlinetext;
			if(codigo.TextLength != 0)
				currentlinetext = codigo.Lines[codigo.GetLineFromCharIndex(inicial)];// obtenemos la linea en que nos encontramos actualmente
            else
            	currentlinetext ="";
			
			int i;
			if(x==0)
				i = 0;
			else
				i = inicial-1;
			codigo.Select(i-x,currentlinetext.Length+1);
			codigo.SelectionColor = c_texto;
			codigo.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
		
			busqueda(i-x,((i-x)+currentlinetext.Length));
	
			buscacolorea("/*",0,codigo.TextLength,1);
			a.Text = ""+(i-x)+" "+((inicial-x)+currentlinetext.Length);
			*/
			
			codigo.Enabled = true;
			codigo.Select(inicial,0);
			codigo.Focus();
			
			int position = codigo.SelectionStart; // encontramos la posicion actual
			int line2 = codigo.GetLineFromCharIndex(position);// obtenemos el numero de linea 
			int col = position - codigo.GetFirstCharIndexFromLine(line2);// obtenemos el numero de la columna
			posicion.Text = "Longitud: "+codigo.Text.Length +" Ln: "+(line2+1) +" Col: "+(col+1); // actualizamos la etiqueta que nos muestra la informacion		
			
		}
		void CompilarToolStripMenuItem1Click(object sender, EventArgs e)
		{
//			GuardarToolStripMenuItemClick(sender,e);// mismo funcionamiento que Guardar
			errores_a.Text="";
			codigoIntermedio_a.Text="";
			// con este codigo eliminamos los comentarios
			string palabra ="";
			for(int i=0; i< codigo.Text.Length; i++){
				codigo.Select(i,1);
				if(codigo.SelectionColor != c_3){
					palabra+= codigo.SelectedText;
				}
			}
			
			StreamWriter objWriter = new StreamWriter("alexico_temporal.txt"); // objeto para abrir un archivo en modo escritura
            objWriter.Write(palabra);
            objWriter.Close();
            //MessageBox.Show("Archivo Guardado","Archivo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			
			
			string archivo = "alexico_temporal.txt"; // archivo que analizar el analizador lexico
			System.Diagnostics.Process p = new  System.Diagnostics.Process(); // creamos un nuevo proceso para ejecutar el CMD
			p.StartInfo.FileName="CMD.exe"; // ejecutaremos una consola
			p.StartInfo.Arguments="/C  a_lexico "+archivo; // LE decimos que archivo ejectuar y los argumentos
			p.Start();// iniciamos la consola
			p.WaitForExit(); // esperamos a que termine la consola, para mostrar los resultados
			
			tabla.DataSource = crearTabla(); // creamos la nueva tabla
			
			p = new  System.Diagnostics.Process(); // creamos un nuevo proceso para ejecutar el CMD
			p.StartInfo.FileName="CMD.exe"; // ejecutaremos una consola
			p.StartInfo.Arguments="/C  analisis_sintactico_semantico"; // LE decimos que archivo ejectuar y los argumentos
			p.Start();// iniciamos la consola
			p.WaitForExit(); // esperamos a que termine la consola, para mostrar los resultados

			string YourApplicationPath = "C:/Users/saull/Desktop/Compiladores_I/compilador/compilador/bin/Debug/netcoreapp3.1/compilador.exe";			
			p.StartInfo.WorkingDirectory = Path.GetDirectoryName(YourApplicationPath);
			p.StartInfo.FileName="cmd.exe"; // ejecutaremos una consola
			p.StartInfo.Arguments="/c "+ Path.GetFileName(YourApplicationPath)+ " program.txt"; // LE decimos que archivo ejectuar y los argumentos
			p.Start();// iniciamos la consola
			p.WaitForExit(); // esperamos a que termine la consola, para mostrar los resultados

			
			 // esperamos a que termine la consola, para mostrar los resultados
			
			string []lines = File.ReadAllLines("arbol_sintacto.txt");
			string []l_e = File.ReadAllLines("line_errores.txt");
			
			string []errores = File.ReadAllLines("errores_sintacto.txt");
			for(int i=0;i<errores.Length;i++)
				errores_a.Text+=errores[i]+"\n";

			string []codigoI = File.ReadAllLines("codigoIntermedio.txt");
			for(int i=0;i<codigoI.Length;i++)
				codigoIntermedio_a.Text+=codigoI[i]+"\n";
			
			tree.Nodes.Clear();
			tree.BeginUpdate();
			pos =0;
			TreeNode node = make_tree(lines,4);
			tree.Nodes.Add(node);
			tree.EndUpdate();

				
			string []lines2 = File.ReadAllLines("arbol_semantico.txt");
			treeSemantico.Nodes.Clear();
			treeSemantico.BeginUpdate();
			pos=0;
			node = make_tree(lines2,4);
			treeSemantico.Nodes.Add(node);
			treeSemantico.EndUpdate();

			pintaerror =2;
			int last = -1;
			for(int i=0; i< l_e.Length;i++){
				if((Convert.ToInt32(l_e[i])-1) != last){
					int firstcharindex = codigo.GetFirstCharIndexFromLine(Convert.ToInt32(l_e[i]) -1);;
					int currentline = codigo.GetLineFromCharIndex(firstcharindex);
					string currentlinetext = codigo.Lines[currentline];
					codigo.Select(firstcharindex, currentlinetext.Length);
					codigo.SelectionBackColor = Color.Yellow;
					last = Convert.ToInt32(l_e[i]) -1;
				}
			}
			pintaerror =1;	
			tabla_simbolos.DataSource = crearTablaSimbolos(); // creamos la nueva tabla con los simbolos
		}
		
		public static int cuenta_espacios(string linea){
			int x=0;
			char []l = linea.ToCharArray();
			for(;x<l.Length;x++){
				if(l[x]!=' ')
					break;
			}
			return x;
		}
		
		public TreeNode make_tree(string [] line, int hijo){
			TreeNode node = new TreeNode();
			node.Text = line[pos];
			pos++;
			while(pos < line.Length ){
				if(cuenta_espacios(line[pos]) == hijo){
					node.Nodes.Add(make_tree2(line,hijo+2));
				}
			}
			return node;
		}
		
		public TreeNode make_tree2(string [] line, int hijo){
			TreeNode node = new TreeNode(line[pos]);
			pos++;
			if(pos< line.Length){
				while(cuenta_espacios(line[pos])== (hijo) && pos < line.Length){
					node.Nodes.Add(make_tree2(line,hijo+2));
					if(pos >= line.Length)
						break;
				}
			}
			return node;
		}
	
		public static DataTable crearTabla(){
			DataTable tabla=new DataTable(); // creamos una nueva tabla
			// agregamos los cabezados a las columnas de nuestra tala
			tabla.Columns.Add("Numero de token");
			tabla.Columns.Add("Lexema");
			tabla.Columns.Add("Token");
			
			
			StreamReader objReader = new StreamReader("alexico_temporal.txt"); // objeto para abrir un archivo en modo lectura
			try
			{
            	string line; // donde guardamos la linea leida del texto
            	int row=0; // contador de filas, para mostrar el numero de token encontrado
            	int aux=0; // auxiliar para saber que elemento estamos colocando en la fila
                while((line = objReader.ReadLine()) != null) // leemos el archivo
				{
                	if(aux==0){ // significa que tenemos que agregar una nueva fila
                		tabla.Rows.Add(tabla.NewRow()); // agregamos una nueva fila a la tabla
                		tabla.Rows[row][0]=row+1; // agregamos el numero de token
                		tabla.Rows[row][1]=line; // agregamos el tipo de token
                		aux++; // cambiamos el auxikiar
                	}
                	else if(aux == 1){
                		tabla.Rows[row][2]=line; // agregamos el lexema (el valor del token)
                		aux=0; // cambiamos el auxiliar
                		row++;// aumentamos el numero de fila (numero de token encontrado)
                	}
				}
            	objReader.Close(); // cerramos el archivo
            }
            catch (Exception ee)// por si se presento una excepcion
            {
                Console.WriteLine("The process failed: {0}", ee.ToString()); // mostramos el error presentado
            }	
			return tabla; /// regresamos la tabla creada para que sea mostrada
		}
		
		public static DataTable crearTablaSimbolos(){
			DataTable tabla=new DataTable(); // creamos una nueva tabla
			// agregamos los cabezados a las columnas de nuestra tala
			tabla.Columns.Add("Identificador");
			tabla.Columns.Add("Tipo");
			tabla.Columns.Add("Valor");
			
			
			StreamReader objReader = new StreamReader("tsimbolos.txt"); // objeto para abrir un archivo en modo lectura
			try
			{
            	string line; // donde guardamos la linea leida del texto
            	int aux=0; // auxiliar para saber que elemento estamos colocando en la fila
                int row=0;
            	while((line = objReader.ReadLine()) != null) // leemos el archivo
				{
                	if(aux==0){ // significa que tenemos que agregar una nueva fila
                		
            			tabla.Rows.Add(tabla.NewRow()); // agregamos una nueva fila a la tabla
                		tabla.Rows[row][0]=line; // agregamos el simbolo
                		aux++; // cambiamos el auxikiar
                	}
                	else if(aux==1){
                		tabla.Rows[row][1]=line; // agregamos el tipo del simboloa
                		aux++;
                	}
                	else if(aux == 2){
                		tabla.Rows[row][2]=line; // agregamos el lexema (el valor del token)
                		aux=0; // cambiamos el auxiliar
                		row++;
                	}
				}
            	objReader.Close(); // cerramos el archivo
            }
            catch (Exception ee)// por si se presento una excepcion
            {
                Console.WriteLine("The process failed: {0}", ee.ToString()); // mostramos el error presentado
            }	
			return tabla; /// regresamos la tabla creada para que sea mostrada
		}
		
		
		void L_compilarClick(object sender, EventArgs e)
		{
            File.Delete("C:/Users/saull/Desktop/Compiladores_I/compilador/compilador/bin/Debug/netcoreapp3.1/program.txt");
            StreamWriter objWriter = new StreamWriter("C:/Users/saull/Desktop/Compiladores_I/compilador/compilador/bin/Debug/netcoreapp3.1/program.txt"); // objeto para abrir un archivo en modo escritura
            objWriter.Write(codigo.Text);
            objWriter.Close();
			CompilarToolStripMenuItem1Click(sender,e);
		}
		
		
		void Ventana_resultadoClick(object sender, EventArgs e)
		{
			
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }

        private void posicion_Click(object sender, EventArgs e)
        {

        }
    }
}
