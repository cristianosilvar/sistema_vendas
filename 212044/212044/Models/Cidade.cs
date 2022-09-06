using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace _212044.Models
{
    internal class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }


        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("SELECT * FROM Cidades WHERE nome like @Nome " +
                                                                  "order by nome", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@Nome", nome = "%");
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
                Banco.Comando = new MySqlCommand("INSERT INTO Cidades (nome, uf) VALUES (@nome, @uf) ",
                                                                                        Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@uf", uf);

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
                Banco.Comando = new MySqlCommand("Update cidades set nome = @nome, uf = @uf where id = @id", Banco.Conexao);
                Banco.Comando = new MySqlCommand("update clientes set nome = @nome, idCidade = @idCidade, dataNasc = @dataNasc, renda = @renda, cpf = @cpf, foto = @foto, venda = @venda where id = @id)", Banco.Conexao);

                // Cria os parametros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@uf", uf);
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
                Banco.Comando = new MySqlCommand("delete from cidades where id = @id", Banco.Conexao);
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
    }
}
