using _11bugs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace _11bugs.Model
{
    //Descrição da Classe:
    class Model
    {
		private System.Timers.Timer timer;

		public delegate void Notificar();
        public delegate void AtualizacoesEstado(Piles board);
        public event Notificar DefinicoesCarregadas;
        public event Notificar NovoJogoCriado;

        public event AtualizacoesEstado EstadoAtualizado;
        public event Notificar JogoGravado;

        public event Notificar EstatisticasGravadas;

        public Model()
        {
			timer = new System.Timers.Timer(6000);
			timer.Elapsed += OnTimedEvent;
			timer.AutoReset = false; // Garante que o evento ocorra apenas uma vez
			timer.Enabled = true;
		}

		private void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			EstadoAtualizado?.Invoke(new Piles(1));
		}

		// Carregar definicoes
		internal void CarregarDefinicoes()
        {
            Console.WriteLine("Carrega definicoes");
            DefinicoesCarregadas?.Invoke();
        }

        internal void CriarNovoJogo()
        {
            Console.WriteLine("Cria novo jogo");
        }

        internal void CartaClicada(int numCarta)
        {

        }

        internal void CartaLargada(int numCarta)
        {
            throw new NotImplementedException();
        }

        internal void GravaJogo()
        {
            throw new NotImplementedException();
        }

        internal void AbreJogo()
        {
            throw new NotImplementedException();
        }

        internal void GravaEstatistica()
        {
            throw new NotImplementedException();
        }

        internal void PedirDefinicoes(ref string asDefinicoes)
        {
            throw new NotImplementedException();
        }
    }
}
