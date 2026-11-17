namespace Practica2
{
    internal class Program
    {
        static Random rnd = new Random(); // generador de aleatorios para colocar los obstáculos verticales
        const bool DEBUG = true; // para sacar información de depuración en el Renderizado
        const int ANCHO = 22, ALTO = 14, // tamaño del área de juego
        SEP_OBS = 6, // separación horizontal entre obstáculos
        HUECO = 7, // hueco de los obstáculos (en vertical)
        COL_BIRD = ANCHO / 3, // columna fija del pájaro
        IMPULSO = 3, // unidades de ascenso por aleteo
        DELTA = 300; // retardo entre frames (ms)
        static void Main()
        { // programa principal
            int[] suelo, techo;
            int fil, ascenso, frame, puntos;
            bool colision;


            Inicializa(out suelo, out techo, out fil, out ascenso, out frame, out puntos, out colision);
        }

        static void Inicializa(out int[] suelo, out int[] techo, out int fil, out int ascenso, out int frame, out int puntos, out bool colision)
        {
            fil = ALTO/2;
            ascenso = -1;
            frame = 0;
            puntos = 0;
            colision = false;

            suelo = new int[ANCHO];
            techo = new int[ANCHO];
            for (int i = 0; i<suelo.Length; i++)
            {
                suelo[i] = 0;
                techo [i] = ALTO-1;
            }
            //Console.Write(" " + suelo[1] + techo[1]);
        }

        void Render(int[] suelo, int[] techo, int fil, int frame, int puntos, bool colision)
        {
            RenderTecho(techo, frame);
        }
         static void RenderTecho(int[] techo, int frame)
        {
            int[] techoV = new int [ANCHO*2];       //Vector real de representación
            int j = 0;
            for (int i = 0; i < techoV.Length; i += 2) 
            {
                techoV[i] = techoV[i + 1] = techo[j];
                j++;
            }
            
            for (int i = 0; i < techoV.Length; i++)  //Cabio de origen de cordenadas
            {
                techoV[i] = ALTO - techoV[i];
            }

            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i =0; i < (ANCHO * 2); i++)
            { 
                for (int q = 0; q < techoV[i]; q++)
                {
                    Console.SetCursorPosition(i, q);
                    Console.Write(" ");

                }
            }
            Console.ResetColor();
        }
        static void RenderSuelo(int[] suelo, int frame)
        {
            int[] sueloV = new int[ANCHO * 2];       //Vector real de representación
            int j = 0;
            for (int i = 0; i < sueloV.Length; i += 2)
            {
                sueloV[i] = sueloV[i + 1] = suelo[j];
                j++;
            }

            for (int i = 0; i < sueloV.Length; i++)  //Cabio de origen de cordenadas
            {
                sueloV[i] = ALTO - sueloV[i];
            }

            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < (ANCHO * 2); i++)
            {
                for (int q = 0; q < sueloV[i]; q++)
                {
                    Console.SetCursorPosition(i, q);
                    Console.Write(" ");

                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(0, ALTO);

        }

    }
}
