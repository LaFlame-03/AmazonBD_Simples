using System;

namespace Amazon_19_11
{
    //Derick felipe cesar RGM:11221103618
    //ProfºAdilson_Atividade M2: 19/11

    public class cliente //criação da classe "cliente"
    {
        //atributos da classe:
        public int id;
        public string nome;
        public string email;
        public string senha;
        public string nome_usuario;
        public string cpf;
        public string endereco;
        public string telefone;
        public string email_recuperacao;
        public string cartao;
        public DateTime data_nasc;

        public cliente()
        {
            //difinição dos valores dos atributos

            this.id = 0;
            this.nome = "";
            this.email = "";
            this.senha = "";
            this.nome_usuario = "";
            this.cpf = "";
            this.endereco = "";
            this.telefone = "";
            this.email_recuperacao = "";
            this.cartao = "";
            

        }
    }

    
    
}
