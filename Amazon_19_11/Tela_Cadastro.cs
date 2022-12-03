using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Amazon_19_11
{
    public partial class Tela_Cadastro : Form
    {
        cliente cli = new cliente();

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Condição para Travar e destravar o botão: "Cadastrar";
            if ((textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||
               textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" ||
               textBox8.Text == "" || textBox9.Text == ""))  
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        public Tela_Cadastro()
        {
            InitializeComponent();
        }

        private void Tela_Cadastro_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short; //codigo para converter o datetimepicker para o banco;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Codigo para armazenar os dados digitados nos atributos:
            cli.nome = (textBox1.Text);
            cli.email = (textBox2.Text);
            cli.senha = (textBox3.Text);
            cli.nome_usuario = (textBox4.Text);
            cli.cpf = (textBox5.Text);
            cli.endereco = (textBox6.Text);
            cli.telefone = (textBox7.Text);
            cli.email_recuperacao = (textBox8.Text);
            cli.cartao = (textBox9.Text);
            cli.data_nasc = (dateTimePicker1.Value);
            

            
            MySqlConnection conexaobd = new ("server=localhost; User Id=root; database=Amazon; password=''");// Conexão com o DB Amazon;
            MySqlCommand sqlQuery = new ("insert into Cliente_Amazon(id_cliente, nome, email, senha, nome_usuario, cpf, endereco, telefone, data_nasc, email_recuperacao, cartao) " +
                                                     "VALUES(" + cli.id + ", '" + cli.nome + "', '" + cli.email + "', '" 
                                                        + cli.senha + "', '" + cli.nome_usuario + "', '" + cli.cpf + "', '" + cli.endereco + "','" + cli.telefone + "','" 
                                                        + cli.data_nasc.ToString("yyyy/MM/dd") + "','" 
                                                        + cli.email_recuperacao + "','" + cli.cartao + "'  );", conexaobd); // inserção do Comando SQL;

            try //Try,Catch para possiveis erros no banco;
            {
                conexaobd.Open();// Abrir a conexão com Banco;
                sqlQuery.ExecuteNonQuery(); // Executa a instrução SQL; 
                MessageBox.Show("Cadastro realizado e armazenado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Quando for comprar um produto, você deverá inserir a Data de vencimento do Cartão e o seu CVV para validação!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro:" + erro, "Atenção!, ocorreu um erro!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            finally
            {
                conexaobd.Close();//fecha a conexão;
            }
           
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        public void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
