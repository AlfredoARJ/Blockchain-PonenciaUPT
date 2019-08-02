using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockchain_WhiteRabbit
{
    interface IBlockchain
    {
        List<Block> Cadena { get; }
        int Dificultad { set; get; }
        void AgregarBloque(Titulo oBlock);
    }
}
