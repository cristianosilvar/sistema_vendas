using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace _212044.Models
{
    public class Vendadet
    {
        public int Id { get; set; }
        public int  idVendacab { get; set; }
        public int idProduto { get; set; }
        public double qtde { get; set; }
        public double valorUnitario { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("insert into vendadet (idVendacab, idProduto, qtde, valorUnitario)" +
                                                "values (@idVendacab,@idProduto, @qtde, @valorUnitario)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@idVendacab", idVendacab);
                Banco.Comando.Parameters.AddWithValue("@idProduto", idProduto);
                Banco.Comando.Parameters.AddWithValue("@qtde", qtde);
                Banco.Comando.Parameters.AddWithValue("@valorUnitario", valorUnitario);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
