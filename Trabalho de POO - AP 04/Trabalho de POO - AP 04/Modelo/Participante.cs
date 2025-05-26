using System;
using System.Collections.Generic;
using System.Linq;

namespace CompromissosApp.Modelos
{
    public class Participante
    {
        public string NomeCompleto { get; set; }
        public List<Compromisso> Compromissos { get; set; } = new List<Compromisso>();

        public Participante(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto ?? throw new ArgumentNullException(nameof(nomeCompleto));
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso != null && !Compromissos.Contains(compromisso))
            {
                Compromissos.Add(compromisso);
            }
        }

        public override string ToString()
        {
            return $"Participante: {NomeCompleto}";
        }
    }
}