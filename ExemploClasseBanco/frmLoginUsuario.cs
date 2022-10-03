using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ExemploClasseBanco
{
    public partial class frmLoginUsuario : Form
    {
        public frmLoginUsuario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Teste de conscistência se preencheu Usuário e Senha
            //Preparar um sql para pesquisar usuário por email
            //Se encontrou o e-mail do usuário verificar se a senha está correta
            //Se senha correta abrir o menu entrar na aplicação, chamar menu
            //Senão mensagem de senha incorreta e voltar para redigitar
            string sql;
            try
            {
                sql = "select * from usuario ";
                sql += " where email = @1 ";
                List<object> param = new List<object>();
                param.Add(txtEmail.Text);
                NpgsqlDataReader dr = ConexaoBanco.selecionar(sql, param);
                if (dr.Read())
                {
                    if (dr["senha"].ToString() == txtSenha.Text)
                    {
                        string nomeUsuario = dr["nome"].ToString();
                        dr.Close();
                        frmPesquisarUsuario frm = new frmPesquisarUsuario(nomeUsuario);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Senha inválida, verifique!!",
                        "Login Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSenha.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Email inválido, verifique!!",
                        "Login Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao verificar o email/senha do usuário" +
                    "Mais detalhes: " + ex.Message, "Login Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnSair.Focus();
        }
    }
}
