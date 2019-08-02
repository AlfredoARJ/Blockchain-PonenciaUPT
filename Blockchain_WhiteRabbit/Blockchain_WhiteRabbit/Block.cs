using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockchain_WhiteRabbit
{
    public class Block
    {
        private DateTime dtTimespan;

        public int NoBlock { set; get; }
        public DateTime Timespan 
        {
            set { dtTimespan = value; }
            get { return dtTimespan; }
        }
        public int Nonce { set; get; }
        public string Hash { set; get; }
        public string HashAnterior { set; get; }
        public Titulo TituloUPT { set; get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Block() 
        {
            this.Timespan = DateTime.Now;
        }

    }
}
