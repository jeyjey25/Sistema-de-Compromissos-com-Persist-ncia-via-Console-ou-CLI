using System;

namespace CompromissosApp.Modelos
{
    public class Anotacao
    {
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }

        public Anotacao(string texto)
        {
            Texto = texto ?? throw new ArgumentNullException(nameof(texto));
            DataCriacao = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Anotação: {Texto} (Criada em: {DataCriacao})";
        }
    }
}