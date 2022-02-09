using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SistemaCadastro
{
    class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=;database=estoque");
        public string mensagem;

    //----------------------------------------
        public DataTable listaProdutos()
        {
            MySqlCommand cmd = new MySqlCommand("lista_produtos", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        } // fim do lista_produto

        public bool insereProduto(Produto b)
        {
            MySqlCommand cmd = new MySqlCommand("inserir_produtos", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", b.Nome);
            cmd.Parameters.AddWithValue("quantEstoque", b.QuantEstoque);
            cmd.Parameters.AddWithValue("marca", b.Marca);
            cmd.Parameters.AddWithValue("secao", b.Secao);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim insereProduto

        public bool deletaProduto(int codP)
        {
            MySqlCommand cmd = new MySqlCommand("deleta_produto", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codP", codP);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim deletaProduto

        public bool alteraProduto(Produto b, int codP)
        {
            MySqlCommand cmd = new MySqlCommand("altera_produto", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codP", codP);
            cmd.Parameters.AddWithValue("nome", b.Nome);
            cmd.Parameters.AddWithValue("quantEstoque", b.QuantEstoque);
            cmd.Parameters.AddWithValue("marca", b.Marca);
            cmd.Parameters.AddWithValue("secao", b.Secao);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim alteraBanda

        //--------------------------------------------------------------------------

        public DataTable listaFornecedores()
        {
            MySqlCommand cmd = new MySqlCommand("lista_fornecedores", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        } // fim do lista_fornecedores

        public bool insereFornecedor(Fornecedor f)
        {
            MySqlCommand cmd = new MySqlCommand("inserir_fornecedores", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CNPJ", f.CNPJ);
            cmd.Parameters.AddWithValue("Email", f.Email);
            cmd.Parameters.AddWithValue("Telefone", f.Telefone);
            cmd.Parameters.AddWithValue("Rua", f.Rua);
            cmd.Parameters.AddWithValue("Numero", f.Numero);
            cmd.Parameters.AddWithValue("Bairro", f.Bairro);
            cmd.Parameters.AddWithValue("Cidade", f.Cidade);
            cmd.Parameters.AddWithValue("Estado", f.Estado);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim insereProduto

        public bool alteraFornecedor(Fornecedor f, int codF)
        {
            MySqlCommand cmd = new MySqlCommand("altera_fornecedor", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codF", codF);
            cmd.Parameters.AddWithValue("CNPJ", f.CNPJ);
            cmd.Parameters.AddWithValue("Email", f.Email);
            cmd.Parameters.AddWithValue("Telefone", f.Telefone);
            cmd.Parameters.AddWithValue("Rua", f.Rua);
            cmd.Parameters.AddWithValue("Numero", f.Numero);
            cmd.Parameters.AddWithValue("Bairro", f.Bairro);
            cmd.Parameters.AddWithValue("Cidade", f.Cidade);
            cmd.Parameters.AddWithValue("Estado", f.Estado);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim alteraBanda

        public bool deletaFornecedor(int codF)
        {
            MySqlCommand cmd = new MySqlCommand("deleta_fornecedor", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codF", codF);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim deletaProduto

        //--------------------------------------------------------------------------------FORNECEDOR ^^^^^^

        public DataTable listaFornece()
        {
            MySqlCommand cmd = new MySqlCommand("lista_fornece", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        } // fim do lista_produto

        public bool insereFornece(Fornece c)
        {
            MySqlCommand cmd = new MySqlCommand("inserir_fornece", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codF", c.CodF);
            cmd.Parameters.AddWithValue("codP", c.CodP);
            cmd.Parameters.AddWithValue("Data", c.Data);
            cmd.Parameters.AddWithValue("QuantCompra", c.QuantCompra);
            cmd.Parameters.AddWithValue("ValorCompra", c.ValorCompra);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim insereProduto

        public bool alteraFornece(Fornece c, int codC)
        {
            MySqlCommand cmd = new MySqlCommand("altera_fornece", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codC", codC);
            cmd.Parameters.AddWithValue("codF", c.CodF);
            cmd.Parameters.AddWithValue("codP", c.CodP);
            cmd.Parameters.AddWithValue("Data", c.Data);
            cmd.Parameters.AddWithValue("QuantCompra", c.QuantCompra);
            cmd.Parameters.AddWithValue("ValorCompra", c.ValorCompra);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim alteraBanda

        public bool deletaFornece(int codC)
        {
            MySqlCommand cmd = new MySqlCommand("deleta_fornece", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codC", codC);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim deletaProduto

    }
}
