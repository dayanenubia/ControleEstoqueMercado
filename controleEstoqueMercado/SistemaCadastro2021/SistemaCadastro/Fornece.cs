using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    class Fornece
    {
        string codF, codP, data, quantCompra, valorCompra;

        public string CodF { get => codF; set => codF = value; }
        public string CodP { get => codP; set => codP = value; }
        public string Data { get => data; set => data = value; }
        public string QuantCompra { get => quantCompra; set => quantCompra = value; }
        public string ValorCompra { get => valorCompra; set => valorCompra = value; }
    }
}