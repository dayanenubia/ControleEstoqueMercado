using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idAlterar;
        public Sistema()
        {
            InitializeComponent();
            
        }
        
       
        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastraProduto.Height;
            marcador.Top = btnCadastraProduto.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        void listaDGProdutos()
        {
            ConectaBanco con = new ConectaBanco();
            dgProdutos.DataSource = con.listaProdutos();
            lblMensagem.Text = con.mensagem;
        }

        void listaDGFornecedores()
        {
            ConectaBanco con = new ConectaBanco();
            dgFornecedor.DataSource = con.listaFornecedores();
            lblMensagem.Text = con.mensagem;
        }

        void listaDGFornece()
        {
            ConectaBanco con = new ConectaBanco();
            dgCompra.DataSource = con.listaFornece();
            lblMensagem.Text = con.mensagem;
        }


        private void Sistema_Load(object sender, EventArgs e)
        {
            listaDGProdutos();
            listaDGFornecedores();
            listaDGFornece();
        }

        void limpaCampos()
        {
            txtnome.Clear();
            txtquantEstoque.Clear();
            txtmarca.Clear();
            txtsecao.Clear();
        }


        private void BtnConfirmaCadastro_Click_1(object sender, EventArgs e)
        {
            Produto b = new Produto();
            b.Nome = txtnome.Text;
            b.QuantEstoque = txtquantEstoque.Text;
            b.Marca = txtmarca.Text;
            b.Secao = txtsecao.Text;
            ConectaBanco con = new ConectaBanco();
            bool r = con.insereProduto(b);
            if (r == true)
            {
                MessageBox.Show("Dados inseridos com sucesso:)!");
                listaDGProdutos();
                limpaCampos();
                txtnome.Focus();
            }
            else
                MessageBox.Show(con.mensagem);
        }

        private void dgBandas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dgProdutos.DataSource as DataTable).DefaultView.RowFilter = string.Format("nome like '{0}%'", textBusca.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dgProdutos.DataSource as DataTable).DefaultView.RowFilter = string.Format("secao like '{0}%'", textbuscas.Text);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            (dgProdutos.DataSource as DataTable).DefaultView.RowFilter = string.Format("marca like '{0}%'", textbuscam.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int linha = dgProdutos.CurrentRow.Index;
            int id = Convert.ToInt32(dgProdutos.Rows[linha].Cells["codP"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?", "Remove Produto", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaProduto(id);
                if (retorno == true)
                {
                    MessageBox.Show("Produto excluida com sucesso!");
                    listaDGProdutos();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");
        }

        private void tabAterar_Click(object sender, EventArgs e)
        {

        }

        private void tabBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgProdutos.CurrentRow.Index;
            idAlterar = Convert.ToInt32(dgProdutos.Rows[linha].Cells["codP"].Value.ToString());
            textAlteraNome.Text = dgProdutos.Rows[linha].Cells["nome"].Value.ToString();
            textAlteraQuant.Text = dgProdutos.Rows[linha].Cells["quantEstoque"].Value.ToString();
            textAlteraMarca.Text = dgProdutos.Rows[linha].Cells["marca"].Value.ToString();
            textAlteraSecao.Text = dgProdutos.Rows[linha].Cells["secao"].Value.ToString();
            tabControl1.SelectedTab = tabAlterar;
        }

        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            Produto b = new Produto();
            b.Nome = textAlteraNome.Text;
            b.QuantEstoque= textAlteraQuant.Text;
            b.Marca = textAlteraMarca.Text;
            b.Secao = textAlteraSecao.Text;
            ConectaBanco con = new ConectaBanco();
            bool ret = con.alteraProduto(b, idAlterar);
            if (ret == true)
            {
                MessageBox.Show("Produto alterado com sucesso!");
                listaDGProdutos();
                tabControl1.SelectedTab = tabBuscar;
            }// fim if true
            else
                MessageBox.Show(con.mensagem);
        }

        private void btnFecharS_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //------------------------------------------------------------------------------------ PRODUTO ^^^^

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastraFornecedor_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastraFornecedor.Height;
            marcador.Top = btnCadastraFornecedor.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[3];
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCompra.Height;
            marcador.Top = btnCompra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[6];
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void txtCNPJ_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        void limpaCamposFornecedor()
        {
            txtCNPJ.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
        }

        void limpaCamposCompras()
        {
            txtCNPJc.Clear();
            txtCodProduto.Clear();
            txtData.Clear();
            txtQuant.Clear();
            txtValor.Clear();
        }
                                
        private void btnCadastraF_Click(object sender, EventArgs e)
        {
            
            Fornecedor f = new Fornecedor();
            f.CNPJ = txtCNPJ.Text;
            f.Email = txtEmail.Text;
            f.Telefone = txtTelefone.Text;
            f.Rua = txtRua.Text;
            f.Numero = txtNumero.Text;
            f.Bairro = txtBairro.Text;
            f.Cidade = txtCidade.Text;
            f.Estado = txtEstado.Text;
            ConectaBanco con = new ConectaBanco();
            bool r = con.insereFornecedor(f);
            if (r == true)
            {
                MessageBox.Show("Dados inseridos com sucesso:)!");
                listaDGFornecedores();
                limpaCamposFornecedor();
                txtCNPJ.Focus();
            }
            else
                MessageBox.Show(con.mensagem);
        }

        private void btnAlteraF_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveF_Click(object sender, EventArgs e)
        {
            int linha = dgFornecedor.CurrentRow.Index;
            int id = Convert.ToInt32(dgFornecedor.Rows[linha].Cells["codF"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?", "Remove Fornecedor", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaFornecedor(id);
                if (retorno == true)
                {
                    MessageBox.Show("Produto excluida com sucesso!");
                    listaDGFornecedores();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
        }

        private void btnAlterarF_Click(object sender, EventArgs e)
        {
            int linha = dgFornecedor.CurrentRow.Index;
            idAlterar = Convert.ToInt32(dgFornecedor.Rows[linha].Cells["codF"].Value.ToString());
            txtAlteraCNPJf.Text = dgFornecedor.Rows[linha].Cells["CNPJ"].Value.ToString();
            txtAlteraEmail.Text = dgFornecedor.Rows[linha].Cells["Email"].Value.ToString();
            txtAlteraTelefone.Text = dgFornecedor.Rows[linha].Cells["Telefone"].Value.ToString();
            txtAlteraRua.Text = dgFornecedor.Rows[linha].Cells["Rua"].Value.ToString();
            txtAlteraNumero.Text = dgFornecedor.Rows[linha].Cells["Numero"].Value.ToString();
            txtAlteraBairro.Text = dgFornecedor.Rows[linha].Cells["Bairro"].Value.ToString();
            txtAlteraCidade.Text = dgFornecedor.Rows[linha].Cells["Cidade"].Value.ToString();
            txtAlteraEstado.Text = dgFornecedor.Rows[linha].Cells["Estado"].Value.ToString();
            tabControl1.SelectedTab = TabAF;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void btnAlteraF_Click_1(object sender, EventArgs e)
        {
            Fornecedor f = new Fornecedor();
            f.CNPJ = txtAlteraCNPJf.Text;
            f.Email = txtAlteraEmail.Text;
            f.Telefone = txtAlteraTelefone.Text;
            f.Rua = txtAlteraRua.Text;
            f.Numero = txtAlteraNumero.Text;
            f.Bairro = txtAlteraBairro.Text;
            f.Cidade = txtAlteraCidade.Text;
            f.Estado = txtAlteraEstado.Text;
            ConectaBanco con = new ConectaBanco();
            bool ret = con.alteraFornecedor(f, idAlterar);
            if (ret == true)
            {
                MessageBox.Show("Produto alterado com sucesso!");
                listaDGFornecedores();
                tabControl1.SelectedTab = TabBF;
            }// fim if true
            else
                MessageBox.Show(con.mensagem);
        }

        
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void txtAlteraEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAlteraNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCCadastroF_Click(object sender, EventArgs e)
        {
            Fornece c = new Fornece();
            c.CodF = txtCNPJc.Text;
            c.CodP = txtCodProduto.Text;
            c.Data = txtData.Text;
            c.QuantCompra = txtQuant.Text;
            c.ValorCompra = txtValor.Text;
            ConectaBanco con = new ConectaBanco();
            bool r = con.insereFornece(c);
            if (r == true)
            {
                MessageBox.Show("Dados inseridos com sucesso:)!");
                listaDGFornece();
                limpaCamposCompras();
                txtCNPJc.Focus();
            }
            else
                MessageBox.Show(con.mensagem);
        }

        private void btnAlteraC_Click(object sender, EventArgs e)
        {
            int linha = dgCompra.CurrentRow.Index;
            idAlterar = Convert.ToInt32(dgCompra.Rows[linha].Cells["codC"].Value.ToString());
            txtAlteraCNPJ.Text = dgCompra.Rows[linha].Cells["codF"].Value.ToString();
            txtAlteraCodP.Text = dgCompra.Rows[linha].Cells["codP"].Value.ToString();
            txtAlteraData.Text = dgCompra.Rows[linha].Cells["data"].Value.ToString();
            txtAlteraQuant.Text = dgCompra.Rows[linha].Cells["QuantCompra"].Value.ToString();
            txtAlteraValorC.Text = dgCompra.Rows[linha].Cells["ValorCompra"].Value.ToString();
            tabControl1.SelectedTab = tabAlteraC;
        }

        private void btnAlterarC_Click(object sender, EventArgs e)
        {
            Fornece c = new Fornece();
            c.CodF = txtAlteraCNPJ.Text;
            c.CodP = txtAlteraCodP.Text;
            c.Data = txtAlteraData.Text;
            c.QuantCompra = txtAlteraQuant.Text;
            c.ValorCompra = txtAlteraValorC.Text;
            ConectaBanco con = new ConectaBanco();
            bool ret = con.alteraFornece(c, idAlterar);
            if (ret == true)
            {
                MessageBox.Show("Produto alterado com sucesso!");
                listaDGFornece();
                tabControl1.SelectedTab = tabBuscarC;
            }// fim if true
            else
                MessageBox.Show(con.mensagem);
        }

        private void btnRemoveC_Click(object sender, EventArgs e)
        {
            int linha = dgCompra.CurrentRow.Index;
            int id = Convert.ToInt32(dgCompra.Rows[linha].Cells["codC"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?", "Remove Produto", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaFornece(id);
                if (retorno == true)
                {
                    MessageBox.Show("Produto excluida com sucesso!");
                    listaDGFornece();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");
        }

        private void dgCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabBuscarC_Click(object sender, EventArgs e)
        {

        }

        private void tabAlteraC_Click(object sender, EventArgs e)
        {

        }

        private void TabBF_Click(object sender, EventArgs e)
        {

        }

        private void TabAF_Click(object sender, EventArgs e)
        {

        }

        private void textbuscam_Click(object sender, EventArgs e)
        {

        }
        /* busca compras*/
        private void txtBuscaCNPJ_TextChanged(object sender, EventArgs e)
        {
            (dgCompra.DataSource as DataTable).DefaultView.RowFilter = string.Format("codF like '{0}%'", txtBuscaCNPJ.Text);
        }

        private void txtBuscaData_TextChanged(object sender, EventArgs e)
        {
            (dgCompra.DataSource as DataTable).DefaultView.RowFilter = string.Format("data like '{0}%'", txtBuscaData.Text);
        }

        private void txtBuscaValor_TextChanged(object sender, EventArgs e)
        {
            (dgCompra.DataSource as DataTable).DefaultView.RowFilter = string.Format("valorCompra like '{0}%'", txtBuscaValor.Text);
        }
        /* busca fonercedor*/

        private void txtBuscaC_TextChanged(object sender, EventArgs e)
        {
            (dgFornecedor.DataSource as DataTable).DefaultView.RowFilter = string.Format("cnpj like '{0}%'", txtBuscaC.Text);
        }

        private void txtBuscaEmail_TextChanged(object sender, EventArgs e)
        {
            (dgFornecedor.DataSource as DataTable).DefaultView.RowFilter = string.Format("email like '{0}%'", txtBuscaEmail.Text);
        }

        private void txtBuscaEstado_TextChanged(object sender, EventArgs e)
        {
            (dgFornecedor.DataSource as DataTable).DefaultView.RowFilter = string.Format("estado like '{0}%'", txtBuscaEstado.Text);
        }

        
    }
}
