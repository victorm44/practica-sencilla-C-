using System;

namespace ConsoleApplication1
{
	class Juego
	{
        static int res;
        static void Main(string[] args)
		{
			int opcion = mostrar_menu_de_inicio();
			while (opcion == 1)
			{
				string[,] Tablero = generar_tablero();
                int puntaje = 0;
				string ubicacionTesoro = tesoro(Tablero);
				Boolean gano = false;
				while (!gano)
				{
					string intento;
					mostrar_tablero(Tablero);
					Console.WriteLine("que numero contiene el tesoro?");
					intento = Console.ReadLine();
					if (intento.Equals(ubicacionTesoro))
					{
						Console.WriteLine();
						Console.WriteLine("FELICIDADES,ENCONTRASTE EL TESORO");
						Console.WriteLine();
						Console.WriteLine("Tu puntaje fue: " + puntaje);
						Console.WriteLine();
						Console.WriteLine("quieres volver a jugar?");
						Console.WriteLine("1 = SI");
						Console.WriteLine("2 = NO");
						opcion = int.Parse(Console.ReadLine());
						gano = true;
					}
					else if(!validacion_t(Tablero, intento))
					{
						Console.WriteLine();
						Console.WriteLine("mala suerte el tesoro no estaba en esa casilla");
						Tablero = generar_nuevo_tablero(intento, Tablero);
						puntaje += preguntas();
                    }
                    else
                    {
                        Console.WriteLine("ingrese un numero que este en el tablero");
                    }
				}
			}
			Console.WriteLine("Juego terminado");
			Console.ReadLine();
		}
		public static void instrucciones()
		{
			Console.WriteLine();
			Console.WriteLine("hay un tablero lleno de numeros ");
			Console.WriteLine("y en uno de esos numeros estara el tesoro escondido");
			Console.WriteLine("debes ingresar un numero cualquiera que este en el tablero ");
			Console.WriteLine("si tienes suerte encontraras el tesosro, de lo contrario aparecera una pregunta");
			Console.WriteLine("dependiendo la dificultad de la pregunta ganaras mas o menos puntaje ");
			Console.WriteLine("Muy Dificil: 5 puntos");
			Console.WriteLine("Dificil: 3 puntos");
			Console.WriteLine("Nivel medio: 2 puntos");
			Console.WriteLine("Facil: 1 punto");
			Console.WriteLine();
            Console.WriteLine("el juego termina cuando encuentres el tesoro");
            Console.WriteLine();
            Console.WriteLine("Presione enter para regresar al menu");
			Console.WriteLine();
			Console.ReadKey();
		}

		public static int mostrar_menu_de_inicio()
		{
			int opcion = 4;
			while (opcion > 3)
			{
				Console.WriteLine("°BUSCA EL TESORO");
				Console.WriteLine("1. Comenzar a jugar");
				Console.WriteLine("2. Ver instrucciones");
				Console.WriteLine("Para salir digite otro numero");
                Console.WriteLine();
				opcion = int.Parse(Console.ReadLine());
				if (opcion == 1)
				{
					break;
				}
				if (opcion == 2)
				{
					instrucciones();
					opcion = 4;
				}
				else
				{
					Console.WriteLine();
					break;
				}
			}
			return opcion;
		}

		public static void mostrar_tablero(string[,] tablerito)
		{
			Console.WriteLine();
			Console.WriteLine("TABLERO DE JUEGO");
			Console.WriteLine();
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					Console.Write(" " + tablerito[i, j]);
				}
				Console.WriteLine();
			}
		}

		public static bool validacion_t(string[,] matriz, string random)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (random.Equals(matriz[i, j]))
					{
						return false;
					}
				}
			}
            return true;
		}

		public static string[,] generar_tablero()
		{
			Random r = new Random();
			string[,] tablero = new string[5, 5];
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					string random = Convert.ToString(r.Next(10, 99));
					while (!validacion_t(tablero, random))
					{
						random = Convert.ToString(r.Next(10, 99));
					}
					tablero[i, j] = random;
				}
			}
			return tablero;
		}

		public static string[,] generar_nuevo_tablero(string Equis, string[,] tablero)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (tablero[i, j].Equals(Equis))
					{
						tablero[i, j] = "X";
					}
				}
			}
			return tablero;
		}

		public static string tesoro(string[,] tablero)
		{
			Random r = new Random();
			int Fila = r.Next(5);
			int columna = r.Next(5);
			return tablero[Fila, columna];
		}

		public static int preguntas()
        { 
            string[,] pregunta = llenar_matriz_P();
            int[,] respuestas = llenar_solucion();
            string[,] opRespuesta = llenar_respuestas();
            int[] r = generar_numero();
            int[,] puntaje = llenar_puntaje();
            


            if (!pregunta[r[0], r[1]].Equals("x"))
                
            {
                Console.WriteLine(pregunta[r[0], r[1]]);
                Console.WriteLine(opRespuesta[r[0], r[1]]);
                res = int.Parse(Console.ReadLine());

                if (res == respuestas[r[0], r[1]])
                {
                    pregunta[r[0], r[1]] = "x";
                    Console.WriteLine("respuesta correcta +" + puntaje[r[0], r[1]] + " puntos");
                    return puntaje[r[0], r[1]];
                }
                else
                {
                    pregunta[r[0], r[1]] = "x";
                    Console.WriteLine("respuesta incorrecta");
                }
            }
            else
            {
                r = generar_numero();
                if (!pregunta[r[0], r[1]].Equals("x"))
                {
                    Console.WriteLine(pregunta[r[0], r[1]]);
                    Console.WriteLine(opRespuesta[r[0], r[1]]);
                    res = int.Parse(Console.ReadLine());

                    if (res == respuestas[r[0], r[1]])
                    {
                        pregunta[r[0], r[1]] = "x";
                        Console.WriteLine("respuesta correcta +"+puntaje[r[0], r[1]]+" puntos");
                        return puntaje[r[0], r[1]];
                    }
                    else
                    {
                        pregunta[r[0], r[1]] = "x";
                        Console.WriteLine("respuesta incorrecta");
                    }
                    Console.ReadKey();
                }

            }

            return 0;
			
			
		}

        static string[,] llenar_matriz_P()
        {
            string[,] matriz = new string[5, 4];
            matriz[0, 0] = "¿Cuándo se extinguieron los mamuts?";
            matriz[0, 1] = "¿Cuántos corazones tienen los pulpos?";
            matriz[0, 2] = "¿Qué enfermedad padecia Stephen Hawking?";
            matriz[0, 3] = "¿Cuál es el lugar más frío de la tierra?";
            matriz[1, 0] = "¿Cuál es el río más largo del mundo?";
            matriz[1, 1] = "¿Dónde originaron los juegos olímpicos?";
            matriz[1, 2] = "¿Qué cantidad hay de huesos en el cuerpo humano adulto?";
            matriz[1, 3] = "¿Cuál es el océano más grande?";
            matriz[2, 0] = "¿Cuál es el disco más vendido de la historia?";
            matriz[2, 1] = "¿Qué significa NBA?";
            matriz[2, 2] = "¿Cuál es el segundo país más grande del mundo?";
            matriz[2, 3] = "¿Qué país tiene forma de bota?";
            matriz[3, 0] = "A qué país pertenecen los cariocas?";
            matriz[3, 1] = "¿Cuál fue el primer metal que empleó el hombre?";
            matriz[3, 2] = "¿Cómo se llama la estación espacial rusa?";
            matriz[3, 3] = "¿Quién traicionó a Jesús?";
            matriz[4, 0] = "¿Cuántos años tiene un lustro?";
            matriz[4, 1] = "¿Cómo se llama el fundador de Facebook?";
            matriz[4, 2] = "¿Cuál es el animal que tiene mayor facilidad para repetir las frases y palabras que escucha?";
            matriz[4, 3] = "¿Cuál es el país con más camellos salvajes?";
            return matriz;
        }

        static int[,] llenar_solucion()
        {
            int[,] solucion = new int[5, 4];
            solucion[0, 0] = 1;
            solucion[0, 1] = 3;
            solucion[0, 2] = 2;
            solucion[0, 3] = 1;
            solucion[1, 0] = 3;
            solucion[1, 1] = 2;
            solucion[1, 2] = 1;
            solucion[1, 3] = 3;
            solucion[2, 0] = 2;
            solucion[2, 1] = 3;
            solucion[2, 2] = 1;
            solucion[2, 3] = 3;
            solucion[3, 0] = 3;
            solucion[3, 1] = 1;
            solucion[3, 2] = 3;
            solucion[3, 3] = 1;
            solucion[4, 0] = 2;
            solucion[4, 1] = 3;
            solucion[4, 2] = 1;
            solucion[4, 3] = 2;

            return solucion;
        }

        static string[,] llenar_respuestas()
        {
            string[,] respuesta = new string[5, 4];
            respuesta[0, 0] = "1)Hace 4000 años 2)hace 10000 años 3)hace 1200 años";
            respuesta[0, 1] = "1)Dos 2)cuatro 3)tres";
            respuesta[0, 2] = "1)Fiebre 2)Esclerosis lateral 3)Esclerosis multiple";
            respuesta[0, 3] = "1)Antartida 2)Polo norte 3)Bogota";
            respuesta[1, 0] = "1)Nilo 2)Medellin 3)Amazonas";
            respuesta[1, 1] = "1)Italia 2)Grecia 3)China";
            respuesta[1, 2] = "1)206 2)108 3)207";
            respuesta[1, 3] = "1)Indico 2)Atlantico 3)Pacifico";
            respuesta[2, 0] = "1)El condor Herido, DIomedes Diaz 2)Thriller, Michael Jackson 3)Back in Black, AC DC";
            respuesta[2, 1] = "1)National Baseball Association 2)Negros Bien Altos 3)National Basketball Association";
            respuesta[2, 2] = "1)Canada 2)China 3)Estados unidos";
            respuesta[2, 3] = "1)Dinamarca 2)Camerun 3)Italia";
            respuesta[3, 0] = "1)Uruguay 2)Canada 3)Brasil";
            respuesta[3, 1] = "1)Bronce 2)Hierro 3)Acero";
            respuesta[3, 2] = "1)MSR 2)MER 3)MIR";
            respuesta[3, 3] = "1)Judas 2)Jose 3)Santrich";
            respuesta[4, 0] = "1) 2)5 3)8";
            respuesta[4, 1] = "1)Uribe 2)jeff bezos 3)Mark Zuckerberg ";
            respuesta[4, 2] = "1)cuervo Corax 2)Loro Amazonico 3)Loro Orejiamarillo";
            respuesta[4, 3] = "1)Egipto 2)Australia 3)Emiratos arabes Unidos";

            return respuesta;
        }

        static int[,] llenar_puntaje()
        {
            int[,] puntaje = new int[5, 4];
            puntaje[0, 0] = 5;
            puntaje[0, 1] = 2;
            puntaje[0, 2] = 3;
            puntaje[0, 3] = 2;
            puntaje[1, 0] = 3;
            puntaje[1, 1] = 1;
            puntaje[1, 2] = 5;
            puntaje[1, 3] = 5;
            puntaje[2, 0] = 3;
            puntaje[2, 1] = 2;
            puntaje[2, 2] = 3;
            puntaje[2, 3] = 3;
            puntaje[3, 0] = 2;
            puntaje[3, 1] = 5;
            puntaje[3, 2] = 2;
            puntaje[3, 3] = 1;
            puntaje[4, 0] = 1;
            puntaje[4, 1] = 1;
            puntaje[4, 2] = 5;
            puntaje[4, 3] = 5;

            return puntaje;
        }

        static int[] generar_numero()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            int[] numero = new int[2];
            numero[0] = r1.Next(0, 5);
            numero[1] = r2.Next(0, 4);

            return numero;
        }
    }
}
