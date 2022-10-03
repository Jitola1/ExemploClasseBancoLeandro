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
    public partial class frmPesquisarUsuario : Form
    {
        public frmPesquisarUsuario(string nomeUsuario)
        {
            InitializeComponent();
            lblUsuario.Text ="Olá " +nomeUsuario;
        }

        private void frmPesquisarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from usuario ";
                sql += " order by nome ";

                dgvPesquisa.DataSource = ConexaoBanco.selecionarDataTable(sql);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao acessar os usuarios" +
                    "Mais detalhes: " + ex.Message, "Pesquisa Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
