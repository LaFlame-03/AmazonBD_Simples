using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Amazon_19_11
{
    public partial class Splash : Form
    {
        Tela_Cadastro cadastro = new Tela_Cadastro();//instancia da tela de cadastro;
        Tela_Consulta consulta = new Tela_Consulta();//instancia da tela de consulta;

        public Splash()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cadastro.ShowDialog();    //mostrar tela de cadastro ao clicar em "Cadastrar!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consulta.ShowDialog();  //mostrar tela de consulta ao clicar em "Gerenciar Contas";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "https://www.amazon.com.br/"); //link para o site da Amazon ao clicar em sua logo.
        }
    }
}