namespace UserApp
{
    public class Usuario
    {
        public string Nome { get; set;}
        public int Idade { get; set;}

        public Usuario(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}