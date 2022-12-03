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
    public partial class Tela_Alterar : Form
    {
        private void Tela_Cadastro2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }
        public Tela_Alterar()
        {
            InitializeComponent();
        }
        cliente cli = new cliente();
        public void button1_Click(object sender, EventArgs e)
        {
            // Abrir Conexão
            cli.id = (int.Parse(txtbox.Text));     
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


                       
            MySqlConnection conexao = new MySqlConnection("server=localhost; User Id=root; database=Amazon; password=''"); // Conexão - Server: porta / DB
            MySqlCommand sqlQuery = new MySqlCommand("UPDATE Cliente_Amazon SET nome = '" + cli.nome + "', email = '" + cli.email + "', senha = '"
                                                        + cli.senha + "', nome_usuario = '" + cli.nome_usuario + "', cpf = '" + cli.cpf + "', endereco = '" + cli.endereco + "', telefone = '" + cli.telefone + "', data_nasc = '"
                                                        + cli.data_nasc.ToString("yyyy/MM/dd") + "', email_recuperacao = '"
                                                        + cli.email_recuperacao + "', cartao = '" + cli.cartao +
                                                     "' WHERE id_cliente = " + cli.id, conexao); // Instr. SQL

            conexao.Open(); // Abrir Conexão

            var resp = MessageBox.Show("Deseja realizar a alteração?", "Alterar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                sqlQuery.ExecuteNonQuery(); // Executa a instrução SQL; 
                MessageBox.Show("Dados alterados!", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conexao.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Condição para Travar e destravar o botão: "Alterar!";
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

        private void txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
