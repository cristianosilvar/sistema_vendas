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
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public int idCategoria { get; set; }
        public int idMarca { get; set; }
        public double estoque { get; set; }
        public double valorVenda { get; set; }
        public string foto { get; set; }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("SELECT p.*,ca.categoria, m.marca " +
                    "FROM produtos p inner join Categorias ca on (p.idCategoria = ca.id) " +
                    "inner join Marcas m on (p.idMarca = m.id)" +
                    "where p.descricao like @descricao order by p.descricao", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();
                return Banco.datTabela;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("insert into produtos (descricao, idCategoria, idMarca, estoque, valorVenda, foto)" +
                                                "values (@descricao, @idCategoria, @idMarca, @estoque, @valorVenda, @foto)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.Comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();
                // Alimenta o metodo command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("update produtos set descricao = @descricao, idCategoria = @idCategoria, idMarca = @idMarca, " +
                    "estoque = @estoque, valorRenda = @valorRenda, foto = @foto where id = @id", Banco.Conexao);
                // Cria os parametros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.Comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                // Executa o COmando, no MYQL, tem a função do raio do workbench
                Banco.Comando.ExecuteNonQuery();
                // 
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {

            try
            {
                Banco.AbrirConexao();
                // Alimenta o metodo command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("delete from produtos where id = @id", Banco.Conexao);
                // Cria os parametros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@id", id);
                // Executa o COmando, no MYQL, tem a função do raio do workbench
                Banco.Comando.ExecuteNonQuery();
                // 
                Banco.FecharConexao();
            }


            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void atualizaEstoque(double qtde)
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("update produtos set estoque = estoque - @qtde where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@qtde", qtde);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
