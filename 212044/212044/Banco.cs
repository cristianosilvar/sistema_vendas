using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _212044
{
    public class Banco
    {
        // Conexão com MySql
        public static MySqlConnection Conexao;
        // Intruções SQL a serem  executadas
        public static MySqlCommand Comando;
        // Inserir daddos em um dataTable
        public static MySqlDataAdapter Adaptador;
        // Ligar o banco em controles com a propriedade ...
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                //Estabelece os parâmetros para a conexão com o Banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;" +
                    "" +
                    "pwd=etecjau");
                //Abre a conexão com o banco de dados
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                //Fecha a conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                // chama a função p abrir a conexão com o banco
                AbrirConexao();

                // Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas;", Conexao);
                // Executa a Query no MySQl
                Comando.ExecuteNonQuery();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " +
                                            "(id integer auto_increment primary key, " +
                                            "nome char(40), " +
                                            "uf char(02))", Conexao);

                Comando.ExecuteNonQuery();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS marcas" +
                                           "(id integer auto_increment primary key, " +
                                           "marca char(20))", Conexao);
                Comando.ExecuteNonQuery();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS categorias" +
                                           "(id integer auto_increment primary key, " +
                                           "categoria char(30))", Conexao);
                Comando.ExecuteNonQuery();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes" +
                                           "(id integer auto_increment primary key, " +
                                           "nome char(40)," +
                                           "idCidade integer," +
                                           "dataNasc date," +
                                           "renda decimal(10,2)," +
                                           "cpf char(14)," +
                                           "foto varchar(100)," +
                                           "venda boolean)", Conexao);
                Comando.ExecuteNonQuery();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Produtos" +
                                            "(id integer auto_increment primary key, " +
                                            "descricao char(40)," +
                                            "idCategoria integer," +
                                            "idMarca integer," +
                                            "estoque decimal(10,3)," +
                                            "valorVenda decimal(10, 2)," +
                                            "foto varchar(100))", Conexao);
                Comando.ExecuteNonQuery();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaCab" +
                            "(id integer auto_increment primary key, " +
                            "idCliente int, " +
                            "data date, " +
                            "total decimal(10, 2))", Conexao);
                Comando.ExecuteNonQuery();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaDet" +
                            "(id integer auto_increment primary key, " +
                            "idVendaCab int," +
                            "idProduto int," +
                            "qtde decimal(10,3)," +
                            "valorUnitario decimal(10, 2))", Conexao);
                Comando.ExecuteNonQuery();


                // Fechar 
                FecharConexao();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
