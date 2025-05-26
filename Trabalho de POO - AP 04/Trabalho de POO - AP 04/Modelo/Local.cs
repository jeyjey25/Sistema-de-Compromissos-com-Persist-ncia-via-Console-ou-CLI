using System;

namespace CompromissosApp.Modelos
{
    public class Local
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }

        public Local(string nome, int capacidadeMaxima)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            CapacidadeMaxima = capacidadeMaxima;
        }

        public bool ValidarCapacidade(int quantidade)
        {
            return quantidade <= CapacidadeMaxima;
        }

        public override string ToString()
        {
            return $"Local: {Nome} (Capacidade: {CapacidadeMaxima})";
        }
    }
}