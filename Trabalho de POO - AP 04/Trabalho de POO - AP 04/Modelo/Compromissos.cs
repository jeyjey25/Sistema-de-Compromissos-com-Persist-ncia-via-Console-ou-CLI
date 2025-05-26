using System;
using System.Collections.Generic;
using System.Linq;

namespace CompromissosApp.Modelos
{
    public class Compromisso
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }
        public Local Local { get; set; }
        public List<Participante> Participantes { get; set; } = new List<Participante>();
        public List<Anotacao> Anotacoes { get; set; } = new List<Anotacao>();

        public Compromisso(DateTime dataHora, string descricao, Usuario usuario, Local local)
        {
            DataHora = dataHora;
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            Local = local ?? throw new ArgumentNullException(nameof(local));

            //Validação
            if (DataHora <= DateTime.Now)
            {
                throw new ArgumentException("A data e hora do compromisso devem estar no futuro.");
            }
            if (string.IsNullOrWhiteSpace(Descricao))
            {
                throw new ArgumentException("A descrição do compromisso é obrigatória.");
            }
        }

        public void AdicionarParticipante(Participante participante)
        {
            if (participante != null && !Participantes.Contains(participante))
            {
                Participantes.Add(participante);
                participante.AdicionarCompromisso(this);
            }
        }

        public void AdicionarAnotacao(string texto)
        {
            Anotacoes.Add(new Anotacao(texto));
        }

        public override string ToString()
        {
            return $"Compromisso: {Descricao} em {DataHora} no local {Local?.Nome} com {Participantes.Count} participantes.";
        }
    }
}