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
    public partial class FrmMarca : Form
    {
        Marca m;

        public FrmMarca()
        {
            InitializeComponent();
        }
        private void Frmmarcas_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        void limpaControles()
        {
            txtmarca.Clear();
            txtConsultar.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            m = new Marca()
            {
                marca = pesquisa
            };
            dgvMarcas.DataSource = m.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtmarca.Text == String.Empty) return;

            m = new Marca()
            {
                marca = txtmarca.Text,

            };
            m.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                txtId.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                txtmarca.Text = dgvMarcas.CurrentRow.Cells["marca"].Value.ToString();
            }
        }
        
        private void FmrMarca_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty) return;
            m = new Marca()
            {
                Id = int.Parse(txtId.Text),
                marca = txtmarca.Text,
            };
            m.Alterar();

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
                m = new Marca()
                {
                    Id = int.Parse(txtId.Text),

                };
                m.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtConsultar.Text);
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }
    }
}
