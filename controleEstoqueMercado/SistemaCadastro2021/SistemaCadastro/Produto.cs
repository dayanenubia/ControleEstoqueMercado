using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    class Produto
    {
        string nome, quantEstoque, marca, secao;

        public string Nome { get => nome; set => nome = value; }
        public string QuantEstoque { get => quantEstoque; set => quantEstoque = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Secao { get => secao; set => secao = value; }
    }
}
