using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace analisis_sintactico_semantico
{
	class Program
	{
		//------------------------------------------//
		//----------  VAR DECLARATION --------------//
		//------------------------------------------//
		public enum TokenType
		    /* book-keeping tokens */
		    {ENDFILE,ERROR,
		    /* reserved words */
		    IF,THEN,ELSE,FI,DO,UNTIL,WHILE,READ,WRITE,FLOAT,INT,BOOL,PROGRAM,
		    /* multicharacter tokens */
		    ID,NUM,SentExp,
		    /* special symbols */
		    ASSIGN,EQ,LT,GT,LET,GET,NE,PLUS,MINUS,TIMES,OVER,LPAREN,RPAREN,SEMI,FK,LK, COMA
		    // EQ ==, LT <, GT >, LET <=, GET >=, NE !=, PLUES +, MINUES -, TIMES *, OVER /, LPAREN (, RPAREN ), SEMI ; , FK { , LT } , COMA ,
	    };
		
		// clase para guardar en la tabla de simbolos
		public class Valor{
			public string tipoValor;
			public float rValor;
			public int iValor;
			public bool bValor;
			public Valor(string t,float r,int i, bool b){
				this.tipoValor=t;
				this.rValor = r;
				this.iValor =i;
				this.bValor = b;
			}
		}
		// fin de la clase para la tabla de simbolos
		public static Hashtable table; // contendra la tabla de simbolos
		public static string typedecla = ""; // para saber que tipo de dato se esta declarando, y asi
		// poder guardarlo en la tabla de simbolos
		
		public const int MAXCHILDREN = 3; // numero maximo de hijos de un nodo
		public enum Type{Real,Int}; // tipo de contenido que tendra el nodo
		
		public enum NodeKind{StmtK,ExpK};
		public enum StmtKind{IfK,WhileK,AssignK,ReadK,WriteK,SentExp,Block,Dok,ProgramK,DeclarationK,Errork};
		public enum ExpKind{OpK,ConstK,IdK};
		public enum StateType{ START,INASSIGN,INCOMMENT,INNUM,INID,DONE };
		public enum ExpType{Void,Integer,Boolean};
		public static string[] lines; // objeto para abrir un archivo en modo lectura
		public static string[] ltoken; // saber en que linea esta el token
		
		public static int n_line;
		public static int nl_token;
		
		public static TokenType token; /* holds current token */
		public static string tokenString;
		public static int lineno;
		public static bool Error;
		/* Variable indentno is used by printTree to
		* store current number of spaces to indent		 
		*/
		public static int indentno = 0;
		public static string archivo; // aqui guardaremos la informacion que sera grabada en un archivo
		public static string errores; // aqui guardaremos la informacion que sera grabada en un archivo
		public static string l_errores; // aqui guardaremos la informacion que sera grabada en un archivo
		public static string archivo_semantico; // aqui guardaremos la informacion que sera grabada en un archivo
		
		
		//------------------------------------------//
		//---------- END  VAR DECLARATION ----------//
		//------------------------------------------//
		
		//------------------------------------------//
		//----------  TREENODE DECLARATION ---------//
		//------------------------------------------//
		public class TreeNode{ // estructura de datos para un nodo del arbol
			public Type typecon; // para saber el tipo de lo que esta guardando el nodo
			public string contenido; // contenido del nodo
			
			public TreeNode  []child;
			public TreeNode sibling;
	     	public int lineno;
	     	public NodeKind nodekind;
	     	[StructLayout(LayoutKind.Explicit)]
	     	public struct kindu // union
			{
			    [System.Runtime.InteropServices.FieldOffset(0)]
			    public StmtKind stmt;
			
			    [System.Runtime.InteropServices.FieldOffset(0)]
			    public ExpKind exp;
			}
	     	public kindu kind;
	        public class attru // union
			{
			    public TokenType op;
			    public int val;
			    public string name;
			    
			}
	     	public attru attr;
	     	public ExpType type; /* for type checking of exps */
	     	
	     	public TreeNode(){
	     		child = new TreeNode[MAXCHILDREN];
	     		attr = new attru();
	     	}
		}
		//------------------------------------------//
		//-------- END TREENODE DECLARATION --------//
		//------------------------------------------//
		
			
		public static void Main(string[] args)
		{		
			lines = File.ReadAllLines("alexico_temporal.txt");
			ltoken = File.ReadAllLines("n_lines.txt");
			// inicializacion de variables
			n_line= 0; 
			nl_token =0;
			archivo ="";
			archivo_semantico ="";
			errores ="";
			l_errores="";
			TreeNode syntaxTree=null;
			table = new Hashtable();
			
			try{
				syntaxTree = parse(); // obtenemos los arboles
				printTree(syntaxTree); // imprimimos los arboles
				guardar(); // guardarmos los resultados
			}
			catch(Exception e){
				printTree(syntaxTree);
				guardar();
			}
			
			// mostramos la tabla de simbolos al igual que la guardamos
			Console.WriteLine("\n>> Tabla de simbolos\n");
			string tsim =""; // contendra el contenido de la tabla de simbolos para guardarla en un archivo
			foreach(DictionaryEntry entry in table)
			{
				Valor x = (Valor)entry.Value;
				if(x.tipoValor.Equals("INT")){
			    	Console.WriteLine(x.tipoValor+ "  : "+entry.Key + " : " +x.iValor  );
			    	tsim+=entry.Key+"\nINT\n"+x.iValor+"\n";
				}
				else if(x.tipoValor.Equals("FLOAT")){
					Console.WriteLine(x.tipoValor+ "  : "+entry.Key + " : " +x.rValor  );
					tsim+=entry.Key+"\nFLOAT\n"+x.rValor+"\n";
				}
				else{
					Console.WriteLine(x.tipoValor+ "  : "+entry.Key + " : " +x.bValor  );
					tsim+=entry.Key+"\nFLOAT\n"+x.bValor+"\n";
				}
			}
			StreamWriter objWriter = new StreamWriter("tsimbolos.txt"); // objeto para abrir un archivo en modo escritura
            objWriter.Write(tsim);// guardamos el resultado en un archivo
            objWriter.Close();
			// terminamos de mostrar y guardar la tabla de simbolos
            
			//Console.WriteLine("Hello World!");
			//Console.Write("Press any key to continue . . . ");
			//Console.ReadKey(true);
		}
		
		//------------------------------------------// Funcion para guardar en archivos, los resultados obtenidos
		//------------------ guardar ---------------//
		//------------------------------------------//
		public static void guardar(){
			StreamWriter objWriter = new StreamWriter("arbol_sintacto.txt"); // objeto para abrir un archivo en modo escritura
            objWriter.Write(archivo);// guardamos el resultado en un archivo
            objWriter.Close();
            
            StreamWriter objWriter2 = new StreamWriter("errores_sintacto.txt"); // objeto para abrir un archivo en modo escritura
            objWriter2.Write(errores);// guardamos el resultado en un archivo
            objWriter2.Close();
            
            StreamWriter objWriter3= new StreamWriter("line_errores.txt"); // objeto para abrir un archivo en modo escritura
            objWriter3.Write(l_errores);// guardamos el resultado en un archivo
            objWriter3.Close();
            
            StreamWriter objWriter4= new StreamWriter("arbol_semantico.txt"); // objeto para abrir un archivo en modo escritura
            objWriter4.Write(archivo_semantico);// guardamos el resultado en un archivo
            objWriter4.Close();
		}
		//------------------------------------------//
		//--------------- END guardar --------------//
		//------------------------------------------//
		
		//------------------------------------------// Funcion que obtiene los tokens
		//------------------ getToken --------------//
		//------------------------------------------//
		public static TokenType getToken(){
			TokenType currentToken = TokenType.ERROR;
   			int aux=0;
   			if(n_line>=lines.Length){
				currentToken = TokenType.ENDFILE;
			}
			else{
   				lineno = Convert.ToInt32(ltoken[nl_token]) +1;
   				nl_token++;
   				string line = lines[n_line]; // leemos el archivo
				n_line++;
	        	if(line == "if"){currentToken = TokenType.IF;}
	            else if(line == "then"){currentToken = TokenType.THEN;}
	            else if(line == "else"){currentToken = TokenType.ELSE;}
	            else if(line == "fi"){currentToken = TokenType.FI;}
	            else if(line == "do"){currentToken = TokenType.DO;}
	            else if(line == "until"){currentToken = TokenType.UNTIL;}
	            else if(line == "while"){currentToken = TokenType.WHILE;}
	            else if(line == "read"){currentToken = TokenType.READ;}
	            else if(line == "write"){currentToken = TokenType.WRITE;}
	            else if(line == "float"){currentToken = TokenType.FLOAT;}
	            else if(line == "int"){currentToken = TokenType.INT;}
	            else if(line == "bool"){currentToken = TokenType.BOOL;}
	            else if(line == "program"){currentToken = TokenType.PROGRAM;}
	            else if(line == "{"){currentToken = TokenType.FK;}
	            else if(line == "}"){currentToken = TokenType.LK;}
	            else if(line == ","){currentToken = TokenType.COMA;}
	            else if(line == "int"){currentToken = TokenType.INT;}
	            else if(line == "bool"){currentToken = TokenType.BOOL;}
	            else if(line == "float"){currentToken = TokenType.FLOAT;}
	            else{
	            	string auxiliar = lines[n_line]; n_line++;
	            	if(auxiliar=="Identificador")currentToken = TokenType.ID;
	            	else if(auxiliar=="Numero")currentToken = TokenType.NUM;
	            	else if(auxiliar=="Operador Multiplicacion")currentToken = TokenType.TIMES;
	            	else if(auxiliar=="Operador Division")currentToken = TokenType.OVER;
	            	else if(auxiliar=="Operador Suma")currentToken = TokenType.PLUS;
	            	else if(auxiliar=="Operador Resta")currentToken = TokenType.MINUS;
	            	else if(auxiliar=="Comparacion Menor igual que")currentToken = TokenType.LET;
	            	else if(auxiliar=="Comparacion Mayor igual que")currentToken = TokenType.GET;
	            	else if(auxiliar=="Comparacion Menor que")currentToken = TokenType.LT;
	            	else if(auxiliar=="Comparacion Mayor que")currentToken = TokenType.GT;
	            	else if(auxiliar=="Comparacion Diferente de")currentToken = TokenType.NE;
	            	else if(auxiliar=="Comparacion igual que")currentToken = TokenType.EQ;
	            	else if(auxiliar=="Simbolo Asignacion")currentToken = TokenType.ASSIGN;
	            	else if(auxiliar=="Parentesis que abre")currentToken = TokenType.LPAREN;
	            	else if(auxiliar=="Parentesis que cierra")currentToken = TokenType.RPAREN;
	            	else if(auxiliar=="Delimitador")currentToken = TokenType.SEMI;
	            	else currentToken = TokenType.ERROR;
	            	tokenString = line;
	            	aux=1;
	            }
	            if(aux==0){
	            	tokenString = lines[n_line]; 
	            	tokenString = line;
	            	n_line++;
	            }
	            else
	            	aux=0;
			}
			return currentToken;
		}
		//------------------------------------------//
		//---------------- END getToken ------------//
		//------------------------------------------//
		
		//------------------------------------------// Funcion que crea el arbol sintactico
		//---------------- parse -------------------//
		//------------------------------------------//
		public static TreeNode parse(){  
			TreeNode t = new TreeNode();
			token = getToken();
			t = program();
			if (token!=TokenType.ENDFILE)
    			syntaxError("Code ends before file\n");
			return t;
		} 
		//------------------------------------------//
		//---------------- END parse ---------------//
		//------------------------------------------//
		
		
		//------------------------------------------// FUncion que muestra los errores encontrados
		//---------------- syntaxError -------------//
		//------------------------------------------//
		static void syntaxError(string message){
			Console.Write("\nSYNTAX ERROR at line  "+lineno+" : "+message);
			errores+="\nSYNTAX ERROR at line  "+lineno+" : "+message;
			l_errores+=lineno+"\n";
		  	Error = true;
		}
		//------------------------------------------// 
		//------------ END syntaxError -------------//
		//------------------------------------------//
		
		//------------------------------------------// Funcion que crea un nuevo nodo de expresion, para la construccion
		//------------ newExpNode ------------------// del arbol sintactico
		//------------------------------------------//
		public static TreeNode newExpNode(ExpKind kind){ 
			TreeNode t = new TreeNode();
			for (int i=0;i<MAXCHILDREN;i++) {t.child[i] = null;}
		    t.sibling = null;
		   	t.nodekind = NodeKind.ExpK;
		    t.kind.exp = kind;
		    t.lineno = lineno;
		    t.type = ExpType.Void;
		  	return t;
		}
		//------------------------------------------//
		//---------- END newExpNode ----------------// 
		//------------------------------------------//
		
		/* Function newStmtNode creates a new statement
		 * node for syntax tree construction
		 */
		public static TreeNode  newStmtNode(StmtKind kind){ 
			TreeNode  t = new TreeNode();
		    for (int i=0;i<MAXCHILDREN;i++) t.child[i] = null;
		    t.sibling = null;
		    t.nodekind = NodeKind.StmtK;
		    t.kind.stmt = kind;
		    t.lineno = lineno;
		  	return t;
		}
		
		//------------------------------------------// Funcion que checa que concuerde el nodo analizado
		//-------------- match ---------------------// 
		//------------------------------------------//
		public static void match(TokenType expected){
			if (token == expected) 
				token = getToken();
		  	else {
		    	syntaxError("unexpected token -> ");
		    	Console.WriteLine(token+" "+tokenString+" "+expected);
		    	errores+=token+" currentToken -> "+tokenString+" , expected -> "+expected;
		    	if(token == TokenType.ERROR){
		    		token = getToken();
		    		match(expected);
		    	}
		  }
		}
		//------------------------------------------// 
		//---------- END match ---------------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion que imprime el arbol sintactico, usando espaciado para identificar 
		//---------- printTree ---------------------// los subarboles
		//------------------------------------------//
		public static void printTree( TreeNode  tree ){ 
			int i;
			indentno+=2;
			while (tree != null) {
		    	printSpaces();
		    	if (tree.nodekind==NodeKind.StmtK){ 
		    		switch (tree.kind.stmt) {
			        	case StmtKind.DeclarationK:
			          		Console.Write("Declaration "+tree.attr.name+" (li."+tree.lineno+")"+"\n");
			          		archivo+="Declaration "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Declaration "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
			          		break;
			          	case StmtKind.Errork:
			          		Console.Write("Error:  "+tree.attr.name+" (li."+tree.lineno+")"+"\n");
			          		archivo+="Error "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Error "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
			          		break;
			          case StmtKind.Block:
			          		Console.Write("Bloque "+ "(li."+tree.lineno+")"+"\n");
			          		archivo+="Bloque "+ "(li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Bloque "+ "(li."+tree.lineno+")"+"\n";
			          		break;
		    			case StmtKind.IfK:
			          		Console.Write("If "+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n");
			          		archivo+="If "+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="If "+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n";
			          	break;
			        	case StmtKind.WhileK:
			          		Console.Write("While "+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n");
			          		archivo+="While "+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="While "+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n";
			          	break;
			          	case StmtKind.ProgramK:
			          		Console.Write("Program "+" (li."+tree.lineno+")"+"\n");
			          		archivo+="Program "+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Program "+" (li."+tree.lineno+")"+"\n";
			          	break;
			     
			          	case StmtKind.Dok:
			          		Console.Write("Do "+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n");
			          		archivo+="Do "+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Do "+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n";
			          	break;
			        	case StmtKind.AssignK:
			          		Console.Write("Assign to: "+tree.attr.name+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n");
			          		archivo+="Assign to: "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Assign to: "+tree.attr.name+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n";
			          	break;
			        	case StmtKind.ReadK:
			          		Console.Write("Read: "+tree.attr.name+" (li."+tree.lineno+")"+"\n");
			          		archivo+="Read: "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Read: "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
			          	break;
			        	case StmtKind.WriteK:
			          		Console.Write("Write"+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n");
			          		archivo+="Write"+" (li."+tree.lineno+")"+"\n";
			          		archivo_semantico+="Write"+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n";
			          	break;
			        	default:
			          		Console.Write("Unknown ExpNode kind"+" (li."+tree.lineno+")"+"\n");
			          		errores+="Unknown ExpNode kind"+" (li."+tree.lineno+")"+"\n";
			          	break;
		      		}
		    	}
		    	else if (tree.nodekind==NodeKind.ExpK){ 
		    		switch (tree.kind.exp) {
		        		case ExpKind.OpK:
		          			Console.Write("Op: "+tree.attr.op+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n");
		          			archivo+="Op: "+tree.attr.op+" (li."+tree.lineno+")"+"\n";
		          			archivo_semantico+="Op: "+tree.attr.op+" (li."+tree.lineno+")"+" VALOR: "+tree.contenido+"\n";
		          		break;
				       	case ExpKind.ConstK:
				       		Console.Write("Num: "+tree.attr.name+" (li."+tree.lineno+")"+"\n");
				       		archivo+="Num: "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
				       		archivo_semantico+="Num: "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
				       	break;
				       	case ExpKind.IdK:
				       		Console.Write("Id: "+tree.attr.name+" (li."+tree.lineno+")"+" VALOR: " +tree.contenido+"\n");
				       		archivo+="Id: "+tree.attr.name+" (li."+tree.lineno+")"+"\n";
				       		archivo_semantico+="Id: "+tree.attr.name+" (li."+tree.lineno+")"+" VALOR: " +tree.contenido+"\n";
				       	break;
				       	default:
				       		Console.Write("Unknown ExpNode kind" +" (li."+tree.lineno+")"+"\n");
				       		archivo+="Unknown ExpNode kind" +" (li."+tree.lineno+")"+"\n";
				       	break;
		      		}	
		    	}
		    	else {
		    		Console.Write("Unknown node kind" +" (li."+tree.lineno+")"+"\n");
		    		errores+="Unknown node kind" +" (li."+tree.lineno+")"+"\n";
		    	}
		    	for (i=0;i<MAXCHILDREN;i++)
		        	printTree(tree.child[i]);
		    	tree = tree.sibling;
		  	}
			indentno-=2;
		}
		//------------------------------------------//
		//--------- END printTree ------------------//
		//------------------------------------------//
		
		//------------------------------------------// Realiza espaciado, pintando espacios
		//--------- printSpaces --------------------// Esto para los subarboles
		//------------------------------------------//
		public static void printSpaces(){ 
			int i;
			for (i=0;i<indentno;i++){
		    	Console.Write(" ");
		    	archivo+=" ";
		    	archivo_semantico+=" ";
			}
		}
		//------------------------------------------//
		//--------- END printSpaces ----------------//
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de repeticion
		//--------------- program ------------------// 
		//------------------------------------------//
		public static TreeNode program(){
			TreeNode  t = newStmtNode(StmtKind.ProgramK);
			if(token != TokenType.PROGRAM){
				t = newStmtNode(StmtKind.Errork);
			}
			match(TokenType.PROGRAM);
			if (t!=null) {
				match(TokenType.FK);
				if(token != TokenType.LK){
					TreeNode aux1 = list_decla();
					if(aux1 !=null)
						t.child[0] = aux1;
					TreeNode aux2 = list_stmt();
					if(aux2 != null)
						t.child[1] = aux2;
					match(TokenType.LK);
				}
				else
					match(TokenType.LK);
			}
			return t;
		}
		//------------------------------------------//
		//------------- END program ----------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de lista-declaracion
		//---------------- list_decla --------------// 
		//------------------------------------------//
		public static TreeNode list_decla(){
			TreeNode t=declaration();
			if(t!= null){
				match(TokenType.SEMI);
				if ((t!=null) && ((token==TokenType.INT)|| (token==TokenType.BOOL)|| (token==TokenType.FLOAT))){
					TreeNode aux = list_decla();
					if(aux != null)
						t.sibling = aux;
				}
				else{
					if(token == TokenType.ERROR){
						while(token == TokenType.ERROR){
		    				Console.WriteLine("Error de declaracion de tipos -> "+ tokenString +" en linea "+lineno);
		    				errores+="Error Token indefinido -> "+ tokenString +" en linea "+lineno;
		    				l_errores+=lineno+"\n";
		    				token = getToken();
		    			}
						TreeNode aux = list_decla();
						if(aux != null)
						t.sibling = aux;
					}
				}
			}
		  	return t;
		}
		//------------------------------------------//
		//---------------- END list_decla ----------// 
		//------------------------------------------//
				
		//------------------------------------------// Funcion para la gramatica de declaracion
		//---------------- declaration -------------// 
		//------------------------------------------//
		public static TreeNode declaration(){
			TreeNode t=null;
			if ((token==TokenType.INT)|| (token==TokenType.BOOL)|| (token==TokenType.FLOAT)){
				t = newStmtNode(StmtKind.DeclarationK);
				t.attr.name = tokenString;
				if(token == TokenType.INT){
					match(TokenType.INT);
					typedecla = "INT";
				}
				if(token == TokenType.BOOL){
					match(TokenType.BOOL);
					typedecla = "BOOL";
				}
				if(token == TokenType.FLOAT){
					match(TokenType.FLOAT);
					typedecla = "FLOAT";
				}
				TreeNode aux = list_var();
				if(aux != null)
					t.child[0] = aux;
				addhash(t.child[0].attr.name,typedecla); // añadimos la variable a la tabla
			}
			else if(token == TokenType.ERROR){
				t = newStmtNode(StmtKind.Errork);
				t.attr.name = "ERROR (Checar errores)";
				Console.WriteLine("Error de declaracion de tipos -> "+ tokenString +" en linea "+lineno);
		    	errores+="Error Token indefinido -> "+ tokenString +" en linea "+lineno;
		    	l_errores+=lineno+"\n";
				while(token == TokenType.ERROR){
		    		token = getToken();
				}
		    	TreeNode aux = list_var();
				if(aux != null)
					t.child[0] = aux;
			}
		  	return t;
		}
		//------------------------------------------//
		//---------------- END declaration ---------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de lista-variables
		//---------------- list_var ----------------// 
		//------------------------------------------//
		public static TreeNode list_var(){
			TreeNode t=null;
			t = newExpNode(ExpKind.IdK);
			if ((t!=null) && (token==TokenType.ID)){
				t.attr.name = tokenString;
			}
			else if(token == TokenType.ERROR){
				t = newStmtNode(StmtKind.Errork);
				t.attr.name = "Error de declaracion de variables";
				Console.WriteLine("Error de declaracion de variables -> "+ tokenString +" en linea "+lineno);
		    	errores+="Error Token indefinido -> "+ tokenString +" en linea "+lineno;
		    	l_errores+=lineno+"\n";
			}
			match(TokenType.ID);
			if(token == TokenType.COMA){
				match(TokenType.COMA);
				t.sibling = list_var();
				// buscamos el tipo 
				addhash(t.sibling.attr.name,typedecla); // añadimos la variable a la tabla
			}
		  	return t;
		}
		//------------------------------------------//
		//---------------- END list_var ------------// 
		//------------------------------------------//
		
		
		//------------------------------------------//
		//---------------- addhash -----------------// 
		//------------------------------------------//
		public static void addhash(string key,string val){
			try{
				table.Add(key,new Valor(val,0,0,false)); // añadimos los valores a la tabla
			}
			catch(Exception e){ // por si ya existia la llave que tratamos de agregar
				Console.WriteLine("ERROR SEMANTICO\nLa variable "+key+" ya ha sido declarada");
				errores+="\nERROR SEMANTICO\nLa variable "+key+" ya ha sido declarada por linea : "+lineno;
				l_errores+=lineno+"\n";
			}
		}
		//------------------------------------------//
		//---------------- END addhash -------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de lista-sentencia
		//---------------- list_stmt ---------------// 
		//------------------------------------------//
		public static TreeNode list_stmt(){
			TreeNode t = statement();
			if(token != TokenType.ENDFILE && token != TokenType.LK){ // } (LK) lo checamos en la gramatica de bloque
				t.sibling = list_stmt();
			}
		  	return t;
		}
		//------------------------------------------//
		//-------------- END list_stmt -------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de sentencia
		//---------------- statement ---------------// 
		//------------------------------------------//
		public static TreeNode statement(){
			TreeNode  t = null;
		  	switch (token) {
		    	case TokenType.IF : t = if_stmt(); break;
		    	case TokenType.DO : t = repeat_stmt(); break;
		    	case TokenType.WHILE : t = itera_stmt(); break;
		    	case TokenType.LPAREN:
		    	case TokenType.ID : 
		    		// checamos que exista el identificador
		    		if(table.ContainsKey(tokenString) == false){
		    			Console.WriteLine("ERROR SEMANTICO\nLa variable "+tokenString+" no existe");
		    			errores+="\nERROR SEMANTICO\nLa variable "+tokenString+" no existe por linea: "+lineno;
						l_errores+=lineno+"\n";	
		    			// como no existio esta variable, nos bricamos esta asignacion
		    			token = getToken();
		    			while( token != TokenType.SEMI && token != TokenType.LK){
		    				token = getToken();
		    			}
		    			token = getToken();// obtenemos el siguiente token
		    		}
		    		else{
		    			Valor aux = (Valor)table[tokenString];
		    			string key = tokenString;
		    			t = stmt_assign();
		    			// guardamos el nuevo valor en la tabla de simbolos
		    			if(aux.tipoValor=="INT"){
		    				if(float.Parse(t.contenido)%1 != 0 ){ // checamos si trata de asignar un valor real a una var int
		    					Console.WriteLine("ERROR SEMANTICO\nNo puedes asignar a "+key+" un valor real");
		    					errores+="\nERROR SEMANTICO\nNo puedes asignar a "+key+" un valor real por linea: "+lineno;
								l_errores+=lineno+"\n";
								t.contenido =""+0;
		    				}
		    				else
		    					aux.iValor = int.Parse(t.contenido);
		    			}
		    			else if (aux.tipoValor =="FLOAT")
		    				aux.rValor = float.Parse(t.contenido);
		    			else{
		    				if(t.contenido.ToUpper() == "TRUE")
		    					aux.bValor = true;
		    				else
		    					aux.bValor = false;
		    			}
		    			table[key] = new Valor(aux.tipoValor,aux.rValor,aux.iValor,aux.bValor);
		    		}
		    		break;
		    	case TokenType.READ : t = read_stmt(); break;
		    	case TokenType.WRITE : t = write_stmt(); break;
		    	case TokenType.FK : t = block(); break;
		    	case TokenType.LK : break;
		    	default : 
		    		t = newStmtNode(StmtKind.Errork);
		    		t.attr.name = "Error de sentencia";
		    		syntaxError("unexpected token -> ");
		    		errores+=token+" "+tokenString;
		    		Console.WriteLine(token+" "+tokenString);
		    		t = newStmtNode(StmtKind.Errork);
		    		t.attr.name=" Error de sentencia";
		    		token = getToken();
		            break;
		  	} /* end case */
		  	return t;
		}
		//------------------------------------------//
		//------------- END  statement -------------// 
		//------------------------------------------//
		
		//------------------------------------------// Gramatica para sentencia de asignacion
		//------------- if_stmt --------------------// 
		//------------------------------------------//
		public static TreeNode if_stmt(){
			TreeNode t = newStmtNode(StmtKind.IfK);
  			match(TokenType.IF);
  			match(TokenType.LPAREN);
  			if (t!=null) {
				t.child[0] = expression();
				t.contenido = t.child[0].contenido;
  			}
			match(TokenType.RPAREN);
			if (t!=null){
				TreeNode aux1 = newStmtNode(StmtKind.Block);
			    aux1.child[0] = block();
				t.child[1] = aux1;
			}
			if (token==TokenType.ELSE) {
			    match(TokenType.ELSE);
			    if (t!=null){
			    	TreeNode aux = newStmtNode(StmtKind.Block);
			    	aux.child[0] = block();
			    	t.child[2] = aux;
			    }
			 }
			 match(TokenType.FI);
			 return t;
		}
		//------------------------------------------//
		//----------- END if_stmt ------------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica bloque
		//-------------  block ---------------------// 
		//------------------------------------------//
		public static TreeNode block(){
			match(TokenType.FK);
			TreeNode t = list_stmt();
			match(TokenType.LK);
		  	return t;
		}
		//------------------------------------------//
		//------------- END  block -----------------// 
		//------------------------------------------//
		
		//------------------------------ ------------// Funcion para la gramatica de repeticion
		//--------------- repeat_stmt --------------// 
		//------------------------------------------//
		public static TreeNode repeat_stmt(){
			TreeNode  t = newStmtNode(StmtKind.Dok);
			match(TokenType.DO);
			if (t!=null) {
				TreeNode aux= newStmtNode(StmtKind.Block);
				aux.child[0] = block();
				t.child[0] = aux;
			}
			match(TokenType.UNTIL);
			match(TokenType.LPAREN);
			if (t!=null){
				t.child[1] = expression();
				t.contenido = t.child[1].contenido;
			}
			match(TokenType.RPAREN);
			match(TokenType.SEMI);
			return t;
		}
		//------------------------------------------//
		//------------- END repeat_stmt ------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de iteracion
		//--------------- itera_stmt ---------------// 
		//------------------------------------------//
		public static TreeNode itera_stmt(){
			TreeNode  t = newStmtNode(StmtKind.WhileK);
			match(TokenType.WHILE);
			match(TokenType.LPAREN);
			if (t!=null) {
				t.child[0] = expression();
				t.contenido = t.child[0].contenido;
			}
			match(TokenType.RPAREN);
			if (t!=null) {
				TreeNode aux1 = newStmtNode(StmtKind.Block);
				aux1.child[0] = block();
				t.child[1] = aux1;
			}
			return t;
		}
		//------------------------------------------//
		//------------- END itera_stmt -------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica sent-read
		//-------------  read_stmt -----------------// 
		//------------------------------------------//
		public static TreeNode read_stmt(){
			TreeNode t = newStmtNode(StmtKind.ReadK);
			match(TokenType.READ);
		  	if ((t!=null) && (token==TokenType.ID))
		    	t.attr.name = tokenString;
		  	match(TokenType.ID);
		  	match(TokenType.SEMI);
		  	return t;
		}
		//------------------------------------------//
		//----------- END  read_stmt ---------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica sent-write
		//-------------  write_stmt ----------------// 
		//------------------------------------------//
		public static TreeNode  write_stmt(){
			TreeNode t = newStmtNode(StmtKind.WriteK);
			match(TokenType.WRITE);
			if (t!=null){
				t.child[0] = expression();
				t.contenido = t.child[0].contenido;
			}
			match(TokenType.SEMI);
			return t;
		}
		//------------------------------------------//
		//------------- END  write_stmt ------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de expresion de asignacion
		//---------------- stmt_assign -------------// 
		//------------------------------------------//
		public static TreeNode  stmt_assign(){
			TreeNode t = null;
		  	switch (token) {
		    	case TokenType.ID :
					//Console.WriteLine(" AAAAAAAAAAA" +tokenString);
		      		t = newStmtNode(StmtKind.AssignK);
		      	    string aux = tokenString;
			      	if ((t!=null) && (token==TokenType.ID))
			      		t.attr.name = tokenString;
			      	match(TokenType.ID);
				  	match(TokenType.ASSIGN);
				  	if (t!=null)
				  		t.child[0] = expression();
				  	t.contenido = t.child[0].contenido; //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				  	match(TokenType.SEMI);
				  	break;
				 default:
				  	t = exp_sim();
				  	break;
			}
			return t;
		}
		//------------------------------------------//
		//-------------- END expression ------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de factor
		//------------------ factor ----------------// 
		//------------------------------------------//
		public static TreeNode  factor(){
			TreeNode t = null;
		  	switch (token) {
		    	case TokenType.NUM :
		      	t = newExpNode(ExpKind.ConstK);
		      	if ((t!=null) && (token==TokenType.NUM)){
			      	t.attr.name = tokenString;
			      	t.contenido = tokenString;
			      	
				}
			      match(TokenType.NUM);
			      break;
			    case TokenType.ID :
			      t = newExpNode(ExpKind.IdK);
			      if ((t!=null) && (token==TokenType.ID)){
			      	// primero checamos que no sea un dato bool
			      	if(tokenString.ToUpper().Equals("FALSE") || tokenString.ToUpper().Equals("TRUE")){
			      		t.contenido = tokenString;
			      		match(TokenType.ID);
			      	}
			        else if(table.ContainsKey(tokenString) == false){
			    			Console.WriteLine("ERROR SEMANTICO\nLa variable "+tokenString+" no existe");
			    			errores+="\nERROR SEMANTICO\nLa variable "+tokenString+" no existe por linea: "+lineno;
								l_errores+=lineno+"\n";
			    			// como no existio esta variable, nos bricamos esta asignacion
			    			token = getToken();
			    			while( token != TokenType.SEMI && token != TokenType.LK){
			    				token = getToken();
			    			}
			    			//token = getToken();// obtenemos el siguiente token
		    			}
				      	else{
				      		t.attr.name = tokenString;
				      		Valor aux = (Valor)table[tokenString];
				      		if(aux.tipoValor.Equals("INT"))
				      			t.contenido = ""+aux.iValor;
				      		else if(aux.tipoValor.Equals("FLOAT"))
				      			t.contenido = ""+aux.rValor;
				      		else
				      			t.contenido = ""+aux.bValor;
				      		//Console.WriteLine(">>>>>>>>>>>>>>>> "+t.contenido);
				      		match(TokenType.ID);
				      	}
			      }
			      break;
			    case TokenType.LPAREN :
			      match(TokenType.LPAREN);
			      t = expression();
			      match(TokenType.RPAREN);
			      break;
			    default:
			      syntaxError("unexpected token -> ");
			      errores+=token+" "+tokenString;
			      Console.WriteLine(token+" "+tokenString);
			      token = getToken();
			      t = newStmtNode(StmtKind.Errork);
			      break;
			}
			return t;
		}
		//------------------------------------------//
		//-------------- END factor ----------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de term
		//------------------ term ------------------// 
		//------------------------------------------//
		public static TreeNode term(){
			
			TreeNode  t = factor();
		  	TokenType aux;
			while ((token==TokenType.TIMES)||(token==TokenType.OVER)){ // TIMES = * , OVER = /
				TreeNode p = newExpNode(ExpKind.OpK);
		    	if (p!=null) {
		      		p.child[0] = t;
			      	p.attr.op = token;
			      	t = p;
			      	aux = token;
			      	match(token);
			      	p.child[1] = factor();  
			      	// guardamos el valor que se ha obtenido
			      	// checamos primero que se pueda hacer la operacion
			      	if(t.child[0].contenido.ToUpper().Equals("TRUE") || t.child[0].contenido.ToUpper().Equals("FALSE") ||
			      	   t.child[1].contenido.ToUpper().Equals("TRUE") || t.child[1].contenido.ToUpper().Equals("FALSE")){
			      		Console.WriteLine("ERROR SEMANTICO\nNo puedes hacer una operacion con booleanos");
						errores+="\nERROR SEMANTICO\nNo puedes hacer una operacion con booleanosa por linea : "+lineno;
						l_errores+=lineno+"\n";
						t.contenido="";
			      	}
			      	else {
			      		if(aux == TokenType.TIMES) // checamos si es una multiplicacion
			      			t.contenido = ""+float.Parse(t.child[0].contenido) * float.Parse(t.child[1].contenido);
			      		else // quizo decir que no era una multiplicacion si no una division
			      			t.contenido = ""+float.Parse(t.child[0].contenido) / float.Parse(t.child[1].contenido);
					}
		    	}
		  	}
		  	return t;
		}
		//------------------------------------------//
		//--------------- END term -----------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de expresion-simple
		//---------------- exp_sim -----------------// 
		//------------------------------------------//
		public static TreeNode exp_sim(){ // en el libro es simple_exp
			TreeNode t = term();
			TokenType aux;
			while ((token==TokenType.PLUS)||(token==TokenType.MINUS)){
				TreeNode p = newExpNode(ExpKind.OpK);
		    	if (p!=null) {
		      		p.child[0] = t;
		      		p.attr.op = token;
		      		t = p;
		      		aux = token;
		      		match(token);
		      		t.child[1] = term();
		      		//Console.WriteLine(""+(float.Parse(t.child[0].contenido) +" + "+ float.Parse(t.child[1].contenido)));
		      			
		      		// guardamos el valor que se ha obtenido
			      	// checamos primero que se pueda hacer la operacion
			      	if(t.child[0].contenido.ToUpper().Equals("TRUE") || t.child[0].contenido.ToUpper().Equals("FALSE") ||
			      	   t.child[1].contenido.ToUpper().Equals("TRUE") || t.child[1].contenido.ToUpper().Equals("FALSE")){
			      		Console.WriteLine("ERROR SEMANTICO\nNo puedes hacer una operacion con booleanos");
						errores+="\nERROR SEMANTICO\nNo puedes hacer una operacion con booleanos por linea : "+lineno;
						l_errores+=lineno+"\n";
						t.contenido="";
			      	}
			      	else{
			      		//Console.WriteLine(""+(float.Parse(t.child[0].contenido) +" + "+ float.Parse(t.child[1].contenido)));
		      			if(aux == TokenType.PLUS) // checamos si es una suma
			      			t.contenido = ""+(float.Parse(t.child[0].contenido) + float.Parse(t.child[1].contenido));
			      		else // quizo decir que no era una suma si no una resta
			      			t.contenido = ""+(float.Parse(t.child[0].contenido) - float.Parse(t.child[1].contenido));
			      	}
		    	}
		  	}
		  	return t;
		}
		//------------------------------------------//
		//-------------- END exp_sim ---------------// 
		//------------------------------------------//
		
		//------------------------------------------// Funcion para la gramatica de expresion
		//---------------- expression --------------// 
		//------------------------------------------//
		public static TreeNode  expression(){
			TreeNode t = exp_sim();
		  	if ((token==TokenType.EQ)||(token==TokenType.LT)||(token==TokenType.GT)||(token==TokenType.LET)||(token==TokenType.GET)||(token==TokenType.NE)) {
				TreeNode p = newExpNode(ExpKind.OpK);
		    	if (p!=null) {
		      		p.child[0] = t;
		      		p.attr.op = token;
		      		t = p;
		    	}
		    	match(token);
		    	if (t!=null)
		      		t.child[1] = exp_sim();
		    	// hacemos las comparaciones especificadas
		    	// primero checamos que no quieran hacer comparacion de booleanos
		    	if(t.child[0].contenido.ToUpper().Equals("TRUE") || t.child[0].contenido.ToUpper().Equals("FALSE") || 
		    	   t.child[1].contenido.ToUpper().Equals("TRUE") || t.child[1].contenido.ToUpper().Equals("FALSE") ){
		    		// significa que quisieron compara datos booleanos y esto no se puede
		    		Console.WriteLine("ERROR SEMANTICO\nNo puedes hacer una comparacion con booleanos");
					errores+="\nERROR SEMANTICO\nNo puedes hacer una comparacion con booleanos por linea : "+lineno;
					l_errores+=lineno+"\n";
					t.contenido="";
		    	}
		    	else{ // significa que si podemos hacer las comparaciones
		    		if(t.attr.op == TokenType.GT){ // comparamos >
		    			if(float.Parse(t.child[0].contenido) > float.Parse(t.child[1].contenido))
		    				t.contenido = "True";
		    			else
		    				t.contenido = "False";
		    		}
		    		else if(t.attr.op == TokenType.LT){ // comparamos <
		    			if(float.Parse(t.child[0].contenido) < float.Parse(t.child[1].contenido))
		    				t.contenido = "True";
		    			else
		    				t.contenido = "False";
		    		}
		    		else if(t.attr.op == TokenType.GET){ // comparamos >=
		    			if(float.Parse(t.child[0].contenido) >= float.Parse(t.child[1].contenido))
		    				t.contenido = "True";
		    			else
		    				t.contenido = "False";
		    		}
		    		else if(t.attr.op == TokenType.LET){ // comparamos <=
		    			if(float.Parse(t.child[0].contenido) <= float.Parse(t.child[1].contenido))
		    				t.contenido = "True";
		    			else
		    				t.contenido = "False";
		    		}
		    		else if(t.attr.op == TokenType.EQ){ // comparamos ==
		    			if(float.Parse(t.child[0].contenido) == float.Parse(t.child[1].contenido))
		    				t.contenido = "True";
		    			else
		    				t.contenido = "False";
		    		}
		    		else if(t.attr.op == TokenType.NE){ // comparamos !=
		    			if(float.Parse(t.child[0].contenido) != float.Parse(t.child[1].contenido))
		    				t.contenido = "True";
		    			else
		    				t.contenido = "False";
		    		}
		    	}
		    	
		  	}
		  	return t;
		}
		//------------------------------------------//
		//------------ END expression --------------// 
		//------------------------------------------//
	
		//------------------------------------------//
		//---------------- exp ---------------------// 
		//------------------------------------------//
		public static TreeNode exp(){ 
			TreeNode t = newStmtNode(StmtKind.AssignK);
  			if ((t!=null) && (token==TokenType.ID))
    			t.attr.name = tokenString;
  			match(TokenType.ID);
  			match(TokenType.ASSIGN);
  			if (t!=null) 
  				t.child[0] = exp_sim();
 				return t;
		}
		//------------------------------------------//
		//---------------- END exp -----------------// 
		//------------------------------------------//
	}
}