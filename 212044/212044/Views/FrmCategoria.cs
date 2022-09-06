using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _212044.Models;

namespace _212044.Views
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }
       
        Categoria ca;

        void limpaControles()
        {
                txtcategoria.Clear();
                txtConsultar.Clear();
        }

        void carregarGrid(string pesquisa)
        {
                ca = new Categoria()
                {
                    categoria = pesquisa
                };
                dgvCategoria.DataSource = ca.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
                if (txtcategoria.Text == String.Empty) return;

                ca = new Categoria()
                {
                    categoria = txtcategoria.Text,

                };
                ca.Incluir();

                limpaControles();
                carregarGrid("");
        }

        private void FmrCategoria_Load(object sender, EventArgs e)
        {
                limpaControles();
                carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty) return;
            ca = new Categoria()
            {
                Id = int.Parse(txtId.Text),
                categoria = txtcategoria.Text,
            };
            ca.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty) return;

            if (MessageBox.Show("Deseja realmente excluir ?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                ca = new Categoria()
                {
                    Id = int.Parse(txtId.Text),

                };
                ca.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.RowCount > 0)
            {
                txtId.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
                txtcategoria.Text = dgvCategoria.CurrentRow.Cells["categoria"].Value.ToString();

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtConsultar.Text);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }
    }
}
