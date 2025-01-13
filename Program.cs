using System;
using System.Collections.Generic;

namespace UserApp
{
    class Program
    {
        static List<Usuario> usuarios = new List<Usuario>();

        static void Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar usuário");
                Console.WriteLine("2 - Listar usuários");
                Console.WriteLine("3 - Sair");
                Console.Write("Opção: ");
                int escolha = Convert.ToInt32(Console.ReadLine());

                if (escolha == 1)
                {
                    CadastrarUsuarios();
                }
                else if (escolha == 2)
                {
                    ListarUsuarios();
                }
                else if (escolha == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Escolha Inválida");               
                }
            }
        }  

        static void CadastrarUsuarios()
        {
            Console.Write("Digite o nome do Usuário: ");
            var nome = Console.ReadLine();

            Console.Write("Digite a idade do usuário: ");
            var idade = Convert.ToInt32(Console.ReadLine());

            usuarios.Add(new Usuario(nome, idade));
            Console.Clear();
        }

        static void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("Usuários Cadastrados:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Nome: {usuario.Nome}, Idade: {usuario.Idade}");
            }
        }  
    }
}
