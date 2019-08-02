using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Blockchain_WhiteRabbit
{
    class Blockchain : IBlockchain
    {        
        private List<Block> oCadena = null;

        #region Propieades publicas

        /// <summary>
        /// Representación de cadena de bloques
        /// </summary>
        public List<Block> Cadena
        {
            get
            {
                if (oCadena == null)
                    oCadena = new List<Block>();

                return oCadena;
            }
        }


        /// <summary>
        /// Nivel de dificultad del bloque
        /// </summary>
        public int Dificultad { set; get; }

        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public Blockchain()
        {
            this.Dificultad = 1;
            CrearBlockGenesis();
        }


        /// <summary>
        /// Constructor, recibe el grado de dificultad. Default 1
        /// </summary>
        public Blockchain(int iDificultad = 1)
        {
            this.Dificultad = iDificultad;
            CrearBlockGenesis();
        }

       
        /// <summary>
        /// Agrega un nuevo bloque a la cadena
        /// </summary>
        /// <param name="oBlock"></param>
        //public void AgregarBloque(Block oBlock)
        public void AgregarBloque(Titulo oTt)
        {
            Block oBlock = new Block();
            //La manera en como se cuentan los indices con "Count" me ahorra la suma
            oBlock.NoBlock = this.Cadena.Count;
            oBlock.HashAnterior = GetHashAnterior();
            oBlock.TituloUPT = oTt;

            string sTitulo = JsonConvert.SerializeObject(oBlock.TituloUPT);
            Tuple<int, string> oTuple = GenerarHash(oBlock.NoBlock, oBlock.Timespan, oBlock.HashAnterior, sTitulo);
            oBlock.Nonce = oTuple.Item1;
            oBlock.Hash = oTuple.Item2;

            this.Cadena.Add(oBlock);
        }


        #region Métodos privados

        /// <summary>
        /// Construye el bloque genesis (origen)
        /// </summary>
        private void CrearBlockGenesis()
        {
            Block oGenesis = new Block();
            oGenesis.NoBlock = 0;
            oGenesis.Nonce = 0;
            oGenesis.Hash = string.Empty;
            oGenesis.HashAnterior = string.Empty;
            oGenesis.TituloUPT = new Titulo()
            {
                NombreAlumno = "John Wick",
                Matricula = "14110230021",
                Carrera = "Ing. en software"
            };
            
            string sTitulo = JsonConvert.SerializeObject(oGenesis.TituloUPT);
            Tuple<int, string> oTuple = GenerarHash(oGenesis.NoBlock, oGenesis.Timespan, oGenesis.HashAnterior, sTitulo);
            oGenesis.Nonce = oTuple.Item1;
            oGenesis.Hash = oTuple.Item2;

            this.Cadena.Add(oGenesis);
        }


        /// <summary>
        /// Genera el hash del bloque
        /// </summary>
        /// <returns></returns>
        private Tuple<int, string> GenerarHash(int idBlock, DateTime dtBlock, string sHashAnt, string sTitulo)
        {
            string sHash = string.Empty;
            int iNonce = 0;

            switch(this.Dificultad)
            {
                case 1:

                    while (!sHash.StartsWith("0"))
                    {
                        string sEntrada = string.Format("{0}|{1}|{2}|{3}|{4}", idBlock,
                                          dtBlock.ToString("yyyy-MM-ddTHH:mm:ss"),
                                          iNonce, sHashAnt, sTitulo);

                        sHash = GetHashSha256(sEntrada);
                        iNonce++;
                    }

                    break;

                case 2:

                    while (!sHash.StartsWith("00"))
                    {
                        string sEntrada = string.Format("{0}|{1}|{2}|{3}|{4}", idBlock,
                                          dtBlock.ToString("yyyy-MM-ddTHH:mm:ss"),
                                          iNonce, sHashAnt, sTitulo);

                        sHash = GetHashSha256(sEntrada);
                        iNonce++;
                    }
                    
                    break;

                case 3:

                    while (!sHash.StartsWith("000"))
                    {
                        string sEntrada = string.Format("{0}|{1}|{2}|{3}|{4}", idBlock,
                                          dtBlock.ToString("yyyy-MM-ddTHH:mm:ss"),
                                          iNonce, sHashAnt, sTitulo);

                        sHash = GetHashSha256(sEntrada);
                        iNonce++;
                    }

                    break;
            }            

            return Tuple.Create(iNonce, sHash);
        }


        /// <summary>
        /// Genera el hash del dato recibido implementando la función de resumen SHA-256
        /// </summary>
        /// <param name="sDato">Dato a partir del que se genera el hash</param>
        /// <returns>string. Cadena base 64 correspondiente al hash</returns>
        private string GetHashSha256(string sDato)
        {
            byte[] yDato = Encoding.UTF8.GetBytes(sDato);
            using (SHA256 oSha256 = SHA256.Create("SHA256"))
            {
                byte[] yHash = oSha256.ComputeHash(yDato);
                return Convert.ToBase64String(yHash);
            }
        }


        /// <summary>
        /// Devuelve el hash del ultimo elemento en la cadena
        /// </summary>
        /// <returns>string. Hash</returns>
        private string GetHashAnterior()
        {
            return this.Cadena.Last().Hash;
        }


        #endregion


    }
}
