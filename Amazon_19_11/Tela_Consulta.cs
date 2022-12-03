using System;
using MySql.Data.MySqlClient;

namespace Amazon_19_11
{
    public partial class Tela_Consulta : Form
    {
        public Tela_Consulta()
        {
            InitializeComponent();
        }
        
        Tela_Alterar telaCad = new Tela_Alterar(); //instancia da tela de alteração;
        cliente cli = new cliente(); //instancia da classe: Cliente;

        private void button1_Click_1(object sender, EventArgs e)
        {
            // exibir + comando clear para limpar os dados do DataGrid ao clicar novamente;
            dataGridView1.Rows.Clear();

            // database
            MySqlConnection conexao = new MySqlConnection("server=localhost; User Id=root; database=Amazon; password=''"); // Conexão com o DB Amazon;
            MySqlCommand sqlQuery = new MySqlCommand("SELECT * FROM Cliente_Amazon", conexao); // inserção do Comando SQL;

            try
            {
                conexao.Open(); // Abrir a conexão com Banco;
                MySqlDataReader dateReader = sqlQuery.ExecuteReader(); // realiza a leitura no banco;

                while (dateReader.Read())
                {
                    
                    object[] registro = new object[dateReader.FieldCount];

                    // Cabeçalho do DataGridView;
                    if (dataGridView1.Rows.Count == 0)
                    {
                        for (int i = 0; i < dateReader.FieldCount; i++)
                        {
                            dataGridView1.Columns.Add(dateReader.GetName(i), dateReader.GetName(i));
                            
                        }
                    }

                    // Tras o registro para o dataGridView;
                    for (int i = 0; i < dateReader.FieldCount; i++)
                    {
                        registro[i] = dateReader.GetValue(i); // Monta o registro do banco;
                    }
                    dataGridView1.Rows.Add(registro); // Adiciona uma linha;
                    
                }
            }
            catch (Exception erro) //exceção para coletar possiveis erros;
            {
                MessageBox.Show("Erro:" + erro, "Erro, atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close(); //fecha a conexão com o banco.
            }

        }

        private void button3_Click(object sender, EventArgs e) //Botão de deletar conta do banco;
        {
            //Database
            MySqlConnection conexao = new MySqlConnection("server=localhost; User Id=root; database=Amazon; password=''"); // Conexão com o DB Amazon;
            MySqlCommand sqlQuery = new MySqlCommand("DELETE FROM cliente_amazon WHERE id_cliente = " + int.Parse(textBox1.Text), conexao);// inserção do Comando SQL;
            conexao.Open(); // Abrir a conexão com Banco;

            var resp = MessageBox.Show("Id da conta: " + textBox1.Text + "\n\nDeseja realmente excluir a conta?", "EXCLUIR?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                sqlQuery.ExecuteNonQuery(); // Executa a instrução SQL; 
                MessageBox.Show("Dados excluidos!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conexao.Close(); //fecha a conexão
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           telaCad.ShowDialog(); //comando para abrir a tela de alteração;
             
        }
    
       
        private void button4_Click(object sender, EventArgs e)
        {

            //Database
            MySqlConnection conexao = new MySqlConnection("server=localhost; User Id=root; database=Amazon; password=''"); // Conexão com o DB Amazon;
            MySqlCommand sqlQuery = new MySqlCommand("SELECT * FROM cliente_amazon WHERE nome like '" + textBox2.Text + "%'", conexao); // inserção do Comando SQL;

            conexao.Open(); // Abrir a conexão com Banco;
            MySqlDataReader dataReader = sqlQuery.ExecuteReader(); // Executa a instrução SQL;            
            dataReader.Read();

            String Dados_Usuario;
            if (dataReader.HasRows) // se tiver dados:
            {
                                Dados_Usuario = "Id:" + dataReader.GetValue(0) + //id_cliente
                                                "\nNome: " + dataReader.GetValue(1) +    //nome
                                                "\nEmail: " + dataReader.GetValue(2) +  //email
                                                "\nSenha:" + dataReader.GetValue(3) +    //senha
                                                "\nUsuário:" + dataReader.GetValue(4) +  //nome_usuario
                                                "\nCPF:" + dataReader.GetValue(5) +     //cpf
                                                "\nEndereco:" + dataReader.GetValue(6) +  //endereco
                                                "\nTelefone:" + dataReader.GetValue(7) +  //telefone
                                                "\nData de Nascimento:" + dataReader.GetValue(8) +   //data_nasc
                                                "\nEmail de Recuperação:" + dataReader.GetValue(9) +  //email_recuperacao
                                                "\ncartao:" + dataReader.GetValue(10);   //cartao de crédito
                                                               
                MessageBox.Show(Dados_Usuario, "Exibir dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario não localizado!", "Exibir dados cadastrados:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conexao.Close(); // fecha a Conexão      
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Tela_Consulta_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

