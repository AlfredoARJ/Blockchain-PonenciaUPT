using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Blockchain_WhiteRabbit
{
    class Program
    {
        private static Blockchain oBlockchain = null;


        static void Main(string[] args)
        {
            Console.WriteLine("Presiona una ENTER para comenzar...");
            Console.ReadLine();

            try
            {
                Console.WriteLine("Inicializa la cadena con dificultad por default 1");
                oBlockchain = new Blockchain();

                Console.WriteLine("Verifiquemos el genesis");
                ImprimirBloque();

                //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                Console.WriteLine("Vamos a agregar un bloque");
                Titulo oTt = new Titulo("Alfredo Albiter", "11223344455", "Ing. en Software");
                oBlockchain.AgregarBloque(oTt);

                Console.WriteLine("El bloque se agregó a la cadena");
                ImprimirBloque();

                //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                Console.WriteLine("Vamos a agregar un bloque más");
                Titulo oTt_2 = new Titulo("Fernando", "11223344455", "Ing. en Software");
                oBlockchain.AgregarBloque(oTt_2);

                Console.WriteLine("El bloque se agregó a la cadena");
                ImprimirBloque();

                //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                Console.WriteLine("Vamos a agregar otro más subiendo la dificultad del bloque a dos!");
                oBlockchain.Dificultad = 2;
                Titulo oTt_3 = new Titulo("Goyo", "0001112229999", "Ing. en Software");
                oBlockchain.AgregarBloque(oTt_3);

                Console.WriteLine("Ya se creo con dificultad 2");
                ImprimirBloque();

                //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                Console.WriteLine("Vamos a agregar otro más subiendo la dificultad del bloque a tres!");
                oBlockchain.Dificultad = 3;
                Titulo oTt_4 = new Titulo("Cap. america", "0099999", "Lic. Industrial");
                oBlockchain.AgregarBloque(oTt_4);

                Console.WriteLine("Ya se creo con dificultad 3");
                ImprimirBloque();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ErrorChain: {0} - {1}", ex.Message, ex.StackTrace));
            }

            Console.WriteLine("Presiona una ENTER para termianr...");
            Console.ReadLine();
        }


        private static void ImprimirBloque()
        {
            Block oBlock = oBlockchain.Cadena.Last();
            Console.WriteLine(JsonConvert.SerializeObject(oBlock));            
            Console.WriteLine();
        }
    }
}
