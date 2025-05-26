using System;
using System.Collections.Generic;
using CompromissosApp.Modelos;
using CompromissosApp.Persistencia;
using System.Linq;

namespace CompromissosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioCompromissos repositorio = new RepositorioCompromissos();
            List<Usuario> usuarios = repositorio.CarregarDados();

            if (usuarios == null || usuarios.Count == 0)
            {
                Console.WriteLine("Bem-vindo! Qual o seu nome?");
                string nomeUsuario = Console.ReadLine();
                Usuario usuario = new Usuario(nomeUsuario);
                usuarios = new List<Usuario> { usuario };
                Console.WriteLine($"Olá, {usuario.NomeCompleto}!");
            }
            else
            {
                Console.WriteLine($"Bem-vindo de volta, {usuarios[0].NomeCompleto}!");
            }

            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("\nOpções:");
                Console.WriteLine("1. Listar Compromissos");
                Console.WriteLine("2. Adicionar Compromisso");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarCompromissos(usuarios[0]);
                        break;
                    case "2":
                        AdicionarCompromisso(usuarios[0], repositorio);
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }

            repositorio.SalvarDados(usuarios);
            Console.WriteLine("Dados salvos. Saindo...");
        }

        static void ListarCompromissos(Usuario usuario)
        {
            Console.WriteLine($"\nCompromissos de {usuario.NomeCompleto}:");
            if (usuario.Compromissos.Count == 0)
            {
                Console.WriteLine("Nenhum compromisso encontrado.");
            }
            else
            {
                foreach (var compromisso in usuario.Compromissos)
                {
                    Console.WriteLine(compromisso);
                }
            }
        }

        static void AdicionarCompromisso(Usuario usuario, RepositorioCompromissos repositorio)
        {
            Console.Write("Data e hora do compromisso (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataHora))
            {
                Console.WriteLine("Formato de data/hora inválido.");
                return;
            }

            Console.Write("Descrição do compromisso: ");
            string descricao = Console.ReadLine();

            Console.Write("Nome do local: ");
            string nomeLocal = Console.ReadLine();

            Console.Write("Capacidade do local: ");
            if (!int.TryParse(Console.ReadLine(), out int capacidadeLocal))
            {
                Console.WriteLine("Capacidade inválida.");
                return;
            }

            Local local = new Local(nomeLocal, capacidadeLocal);

            try
            {
                Compromisso compromisso = new Compromisso(dataHora, descricao, usuario, local);
                usuario.AdicionarCompromisso(compromisso);
                Console.WriteLine("Compromisso adicionado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao adicionar compromisso: {ex.Message}");
            }
        }
    }
}
