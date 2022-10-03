using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploClasseBanco
{
    public partial class frmCadastroUsuario : Form
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Testes de conscistências no campo
            //Preparar um sql com parâmetros
            //Chamar método Executar da classe ConexaoBanco
            string sql;
            try
            {
                sql = "insert into usuario (nome, email, senha) ";
                sql += " values(@1, @2, @3) ";
                List<object> param = new List<object>();
                param.Add(txtNome.Text);
                param.Add(txtEmail.Text);
                param.Add(txtSenha.Text);

                ConexaoBanco.executar(sql, param);
                MessageBox.Show("Dados do Usuario salvo com sucesso", 
                    "Cadastro Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o cadastro do usuário" +
                    " Mais detalhes: " + ex.Message, "Cadastro Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmLoginUsuario frmLogin = new frmLoginUsuario();
            frmLogin.ShowDialog();
        }
    }
}
