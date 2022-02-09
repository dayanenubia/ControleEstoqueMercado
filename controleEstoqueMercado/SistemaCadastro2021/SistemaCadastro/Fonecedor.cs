using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
	class Fornecedor
	{
        string cnpj, email, telefone, rua, numero, bairro, cidade, estado;

        public string CNPJ { get => cnpj; set => cnpj = value; }
        public string Email { get => email; set => email = value; }
         public string Telefone { get => telefone; set => telefone = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
