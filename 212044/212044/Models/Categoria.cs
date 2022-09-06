using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _212044.Models
{
    class Categoria
    {
        public int Id { get; set; }
        public string categoria { get; set; }


        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("SELECT * FROM categorias where categoria like @categoria" +
                    " order by categoria", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria + "%");
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
                Banco.Comando = new MySqlCommand("insert into categorias (categoria) values (@categoria)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
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
                Banco.Comando = new MySqlCommand("Update categorias set categoria = @categoria where id = @id", Banco.Conexao);
                // Cria os parametros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
                Banco.Comando.Parameters.AddWithValue("@id", Id);
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
                Banco.Comando = new MySqlCommand("delete from categorias where id = @id", Banco.Conexao);
                // Cria os parametros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@id", Id);
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
    }
}
