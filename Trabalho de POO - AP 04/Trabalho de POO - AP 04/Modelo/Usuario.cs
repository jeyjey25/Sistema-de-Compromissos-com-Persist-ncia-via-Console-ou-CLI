using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CompromissosApp.Modelos
{
    public class Usuario
    {
        public string NomeCompleto { get; set; }
        private List<Compromisso> _compromissos = new List<Compromisso>();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

        public Usuario(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto ?? throw new ArgumentNullException(nameof(nomeCompleto));
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
            {
                throw new ArgumentNullException(nameof(compromisso));
            }

            _compromissos.Add(compromisso);
        }

        public override string ToString()
        {
            return $"Usuário: {NomeCompleto}";
        }
    }
}