using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockchain_WhiteRabbit
{
    public class Titulo
    {
        private string sIdtitulo = string.Empty;
        private DateTime dtTimespan;

        public string IdTitulo 
        {
            set
            {
                sIdtitulo = value;
            }

            get
            {
                return sIdtitulo;
            }
        }
        public DateTime Timespan 
        {
            set { dtTimespan = value; }

            get { return dtTimespan; }
        }
        public string NombreAlumno { set; get; }
        public string Matricula { set; get; }
        public string Carrera { set; get; }


        /// <summary>
        /// Constructor
        /// </summary>
        public Titulo() { }

        public Titulo(string sNombre, string Matricula, string sCarrera) 
        {
            this.IdTitulo = DateTime.Now.Ticks.ToString().Substring(0, 6);
            this.Timespan = DateTime.Now;
        }
    }
}
