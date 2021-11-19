using System;
using System.IO;

namespace a_lexico
{
	class Program
	{
		public static int estado; // estado de la maquina
		public static string resultado,ultimotoken; // donde guardaremos el resultado de la ejecucion del programa
		public static string cestado; 
		public static int linea; // para saber el numero de linea del token
		public static string lineas;
		
		public static void Main(string[] args)
		{
			if(args.Length != 0){
				Console.WriteLine(args[0]); // mostramos el error presentado
				//StreamReader objReader = new StreamReader("alexico_temporal.txt"); // objeto para abrir un archivo en modo lectura
	            StreamReader objReader = new StreamReader(args[0]); // objeto para abrir un archivo en modo lectura
	            string sLine = ""; // string que contendra el contenido del archivo
	            lineas ="";
	            linea=0;
	            try
	            {
	                sLine = objReader.ReadToEnd();// leemos todo el contenido del archivo
	                //Console.WriteLine(sLine); // mostramos el error presentado
	                objReader.Close();
	            }
	            catch (Exception e)// por si se presento una excepcion
	            {
	                Console.WriteLine("The process failed: {0}", e.ToString()); // mostramos el error presentado
	            }
	            //Console.WriteLine(sLine); // mostramos el error presentado
				
				estado = 0;// inicializamos el estado inicial
				resultado = ""; // inicializamos la variable donde guardaremos el resultado del programa
				cestado =""; // variable para ir guardando lo que se va analizando en la maquina de estados
				ultimotoken=""; // para saber cual fue el ultimo token que aparecio
				//string cadena = "\nxa aint inta int x thenaaa iii program 2 2.15 +285+285 -5  bool { < >= ; = == != , * / - +  float if( \nread write( then else\n if\n until while fi ";
				// pasamos la cadena a un array
				char [] cadena_x = sLine.ToCharArray();
				for(int i=0; i< sLine.Length; i++ ){ // analizamos caracter por caracter de la cadena
				    //Console.WriteLine(" "+estado+"   " +cestado);
				    if(cadena_x[i] !='\n')
				    	i = maquina_es(cadena_x[i],i,cadena_x); // checamos el caracter en turno
				    else{
				    	linea++;
				    	i = maquina_es(' ',i,cadena_x); // checamos el caracter en turno
				    }
				}
			//}
			//Console.WriteLine(" "+estado+"" +cestado);
			if(estado == 2 || estado == 6 || estado == 10|| estado == 12|| estado == 14|| estado == 19
			   || estado == 24|| estado ==  28|| estado == 32|| estado == 36|| estado == 38|| estado == 42|| estado == 49 )
				maquina_es(' ',cadena_x.Length-1,cadena_x);
			else if(cestado.Length != 0){
				if(checa_identificador(cestado))
					muestra_token(cestado,"Identificador");
				else
					muestra_token(cestado,"Token no identificado");
			}
			lineas+=""+linea+"\n";
			guardar();
			}
			//Console.Write("Press any key to continue . . . ");
			//Console.ReadKey(true);
		}
		
		public static void guardar(){// funcion para guardar el resultado en un archivo
			StreamWriter objWriter = new StreamWriter("alexico_temporal.txt"); // objeto para abrir un archivo en modo escritura
            objWriter.Write(resultado);// guardamos el resultado en un archivo
            objWriter.Close();
            
            StreamWriter objWriter2 = new StreamWriter("n_lines.txt");
            objWriter2.Write(lineas);
            objWriter2.Close();
		}
		
		public static void muestra_token(string token,string tipo){
			/*if(token.Substring(token.Length-1,1)=="\n"){
				char [] aux = token.ToCharArray();
				string res ="";
				for(int i=0; i< aux.Length-2;i++){
					if(aux[i]==' ' ||aux[i]=='\n' )
						break;
					res += aux[i];
				}
				resultado+=res+"\n";
				resultado+=tipo+"\n";
				Console.WriteLine(res + " --> "+tipo);
			}
			else{*/
				resultado+=token+"\n";
				resultado+=tipo+"\n";
				Console.WriteLine(token + " --> "+tipo);
				ultimotoken=tipo;
				lineas+=""+linea+"\n";
			//}
			estado = 0;
			cestado ="";
		}
		
		public static bool comprueba_numero(string cadena){
			bool res = true;
			char [] checa = cadena.ToCharArray();
			for(int i=1;i<cadena.Length;i++){
				if(!Char.IsDigit(checa[i])){
					res = false;
					break;
				}
			}
			return res;
		}
		
		public static bool checa_identificador(string cadena){
			if(cadena != ""){
			bool res = true;
			char [] c = cadena.ToCharArray();
			if(Char.IsLetter(c[0])){
				for(int i=0; i< cadena.Length;i++){
					if(!Char.IsLetterOrDigit(c[i])){
						res = false;
						break;
					}
				}
			}
			else
				res = false;
			return res;
			}
			else
				return false;
		}
		
		public static bool checa_numero(string cadena){
			bool res = true;
			int punto=0;
			char [] c = cadena.ToCharArray();
			for(int i=0; i< cadena.Length;i++){
				if(!Char.IsDigit(c[i])){
					if(c[i]=='.'){
						punto++;
						if(punto>1){
							res = false;
							break;
						}	
					}
					else{
						res = false;
						break;
					}
				}
			}
			if((cadena.Substring(cadena.Length-1,1)) == "."){
				res = false;
			}
			return res;
		}
		
		public static int maquina_es(char c, int i, char[] cadena){// aqui analizamos todo el coedigo caracter por caracter
			if(c != ' '){
				cestado += ""+c;
			}
			else{
				if(cestado!= "" &&  cestado!= "if" &&  cestado!= "then" &&  cestado!= "else" &&  cestado!= "fi"
				  &&  cestado!= "do" &&  cestado!= "until" &&  cestado!= "while" &&  cestado!= "read"
				  &&  cestado!= "write" &&  cestado!= "float" &&  cestado!= "int" &&  cestado!= "bool"
				  &&  cestado!= "program"){
					if(checa_identificador(cestado))// checamos si lo que encontramos es un identificador
					muestra_token(cestado,"Identificador");
				}
			}
			switch(c){
		    	case '+':
		    	case '-':
					if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		// checamos si es un signo de un numero
		    		//if(Char.IsDigit(cadena[i+1]) && cadena[i-1]==' '){
		    		if(ultimotoken!="Numero" && ultimotoken != "Identificador"){ 
		    			// significa que es un numero con signo
		    			string numero =""+c;
		    			i++;
		    			while(cadena[i]!= ' ' && cadena[i]!= '\n' && cadena[i]!= '+' && cadena[i]!= '-' && cadena[i]!= '*'
		    			     && cadena[i]!= '/'){
		    				numero+=cadena[i];
		    				i++;
		    				if(i==cadena.Length)
		    					break;
		    			}
		    			if(comprueba_numero(numero))
		    				muestra_token(numero,"Numero");
		    			else
		    				muestra_token(numero,"token no identificado");
		    		}
		    		else // significa que es un signo
		    			if(c=='+')
		    				muestra_token("+","Operador Suma");
		    			else
		    				muestra_token("-","Operador Resta");
		    		break;
		    	case '*':
		    		if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		muestra_token("*","Operador Multiplicacion");
		    		break;
		    	case '/':
		    		if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		muestra_token("/","Operador Division");
		    		break;
		    	case ',':
		    		if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		muestra_token(",","Coma");
		    		break;
		    	case ';':
		    		if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		muestra_token(";","Delimitador");
		    		break;
		    	case '<':
		    		if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		if(cadena[i+1]!='=')
		    			muestra_token("<","Comparacion Menor que");
		    		else{
		    			muestra_token("<=","Comparacion Menor igual que");
		    			i++;
		    		}
		    		break;
		    	case '>':
		    		if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		if(cadena[i+1]!='=')
		    			muestra_token(">","Comparacion Mayor que");
		    		else{
		    			muestra_token(">=","Comparacion Mayor igual que");
		    			i++;
		    		}
		    		break;
		    	case '=':
		    		if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
		    		if(cadena[i+1]!='=')
		    			muestra_token("=","Simbolo Asignacion");
		    		else{
		    			muestra_token("==","Comparacion igual que");
		    			i++;
		    		}
		    		break;
		    	case '!':
		    		if(cadena[i+1]=='='){
		    			muestra_token("!=","Comparacion Diferente de");
		    			i++;
		    		}
		    		break;
				case ' ':
				case '\n':
					switch(estado){
						case 2: // if
		    			case 6: // then
		    			case 10: // else
		    			case 12: // fi
		    			case 14: // do
		    			case 19: // until
		    			case 24: // while
		    			case 28: // read
		    			case 32: // write
		    			case 36: // float
		    			case 38: // int
		    			case 42: // bool
		    			case 49: // program
							muestra_token(cestado,"keyword");
							break;
						case 100: // quiere decir que es un identificador
							// checamos que si siga las reglas de un identificador
							if(checa_identificador(cestado))
								muestra_token(cestado,"Identificador");
							else
								muestra_token(cestado,"Token no identificado");
							break;
					}
					break;
				case '(':
					switch(estado){
						case 2: // if
						case 19: // until
						case 24: // while
						case 32: // write
							string aux = cestado.Substring(cestado.Length-1,1);
							muestra_token(cestado.Substring(0,cestado.Length-1),"keyword");
							muestra_token(aux,"Parentesis que abre");
							break;	
						default:
							muestra_token("(","Parentesis que abre");
							break;							
					}
					break;
				case ')':
					if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
					muestra_token(")","Parentesis que cierra");
					break;
				case '}':
					if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
					if(estado==12)
						muestra_token("fi","Keyword");
					muestra_token("}","Llave que cierra");
					break;
				case '{':
					if(checa_identificador(cestado.Substring(0,cestado.Length-1)))// checamos si lo que encontramos es un identificador
						muestra_token(cestado.Substring(0,cestado.Length-1),"Identificador");
					switch(estado){
		    			case 6: // then
		    			case 10: // else
		    			case 14: // do
						case 49: // program
							string aux = cestado.Substring(cestado.Length-1,1);
							muestra_token(cestado.Substring(0,cestado.Length-1),"keyword");
							muestra_token(aux,"LLave que abre");
							//i++;
							break;
						default:
							muestra_token("{","LLave que abre");
							break;
					}
					break;
				case 'i':
					switch(estado){
						case 0: estado = 1; // i
							break;
						case 11: estado = 12; // fi
							break;
						case 17: estado = 18; // unti
							break;
						case 21: estado = 22; // whi
							break;
						case 29: estado = 30; // wri
							break;
						default : estado =100; // identificador
							break;	
					}
					break;
				case 'f': 
					switch(estado){
						case 1: estado = 2; // if
							break;
						case 0: estado = 11; // f
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 't': 
					switch(estado){
						case 0: estado = 3; // t
							break;
						case 16: estado = 17; // unt
							break;
						case 30: estado = 31; // writ
							break;
						case 35: estado = 36; // float
							break;
						case 37: estado = 38; // int
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'h': 
					switch(estado){
						case 3: estado = 4; // th
							break;
						case 20: estado = 21; // wh
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'e': 
					switch(estado){
						case 4: estado = 5; // the
							break;
						case 0: estado = 7; // e
							break;
						case 9: estado = 10; // else
							break;
						case 23: estado = 24; // while
							break;
						case 25: estado = 26; // re
							break;
						case 31: estado = 32; // write
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'n': 
					switch(estado){
						case 5: estado = 6; // then
							break;
						case 15: estado = 16; // un
							break;
						case 1: estado = 37; // in
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'l': 
					switch(estado){
						case 7: estado = 8; // el
							break;
						case 18: estado = 19; // until
							break;
						case 22: estado = 23; // whil
							break;
						case 11: estado = 33; // fl
							break;
						case 41: estado = 42; // bool
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 's': 
					switch(estado){
						case 8: estado = 9; // els
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'd': 
					switch(estado){
						case 0: estado = 13; // d
							break;
						case 27: estado = 28; // read
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'o': 
					switch(estado){
						case 13: estado = 14; // do
							break;
						case 33: estado = 34; // flo
							break;
						case 39: estado = 40; // bo
							break;
						case 40: estado = 41; // boo
							break;
						case 44: estado = 45; // pro
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'u': 
					switch(estado){
						case 0: estado = 15; // u
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'w': 
					switch(estado){
						case 0: estado = 20; // w
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'r': 
					switch(estado){
						case 0: estado = 25; // r
							break;
						case 20: estado = 29; // wr
							break;
						case 43: estado = 44; // pr
							break;
						case 46: estado = 47; // progr
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'a': 
					switch(estado){
						case 26: estado = 27; // rea
							break;
						case 34: estado = 35; // floa
							break;
						case 47: estado = 48; // progra
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'b': 
					switch(estado){
						case 0: estado = 39; // b
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'p': 
					switch(estado){
						case 0: estado = 43; // p
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'g': 
					switch(estado){
						case 45: estado = 46; // prog
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				case 'm': 
					switch(estado){
						case 48: estado = 49; // program
							break;
						default : estado =100; // identificador
							break;
					}
					break;
				default:
					if(Char.IsLetter(c)){ // quiere decir que puede ser un identificador
						string ide ="";
						while(cadena[i]!= '+' && cadena[i]!= '-'  && cadena[i]!= '*' && cadena[i]!= '/'
						     && cadena[i]!= ' ' && cadena[i]!= '\n' && cadena[i]!= '<' && cadena[i]!= '>'
						    && cadena[i]!= '!' && cadena[i]!= '=' && cadena[i]!= ')' && cadena[i]!= ','
						   && cadena[i]!= ';'){
							ide += ""+cadena[i];
							i++;
							if(i==cadena.Length)
								break;
						}
						i--;
						if(checa_identificador(ide))
							muestra_token(ide,"Identificador");
						else
							muestra_token(ide,"Token no identificado");
					}
					else if(Char.IsDigit(c) || c=='.'){ // signfica que es puede ser un numero
						string ide ="";
						while(cadena[i]!= '+' && cadena[i]!= '-'  && cadena[i]!= '*' && cadena[i]!= '/'
						     && cadena[i]!= ' ' && cadena[i]!= '\n' && cadena[i]!= '<' && cadena[i]!= '>'
						    && cadena[i]!= '!' && cadena[i]!= '=' && cadena[i]!= ')' && cadena[i]!= ','
						   && cadena[i]!= ';'){
							ide += ""+cadena[i];
							i++;
							if(i==cadena.Length)
								break;
						}
						i--;
						if(checa_numero(ide))
							muestra_token(ide,"Numero");
						else
							muestra_token(ide,"Token no identificado");
						
					}
					break;
			}
			if(estado == 100){// quiere decir que encontro algo que puede ser un identificador
				string ide =""; // auxiliar para guardar lo que hay delante de lo que puede ser el identificador
				i++;
				if(i == cadena.Length)
					i=cadena.Length-1;
				while(cadena[i]!= '+' && cadena[i]!= '-'  && cadena[i]!= '*' && cadena[i]!= '/'
				     && cadena[i]!= ' ' && cadena[i]!= '\n' && cadena[i]!= '<' && cadena[i]!= '>'
				     && cadena[i]!= '!' && cadena[i]!= '=' && cadena[i]!= ')' && cadena[i]!= ','
				     && cadena[i]!= ';'){
				    	ide += ""+cadena[i];
						i++;
						if(i==cadena.Length)
								break;
				}
				i--;
				ide = cestado+ide;
				if(checa_identificador(ide))// checamos si lo que encontramos es un identificador
					muestra_token(ide,"Identificador");
				else
					muestra_token(ide,"Token no identificado");
			}
			return i;
		}// fin de maquina_es
	}
}