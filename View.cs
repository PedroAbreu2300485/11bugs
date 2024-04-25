using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decktacular
{
	public delegate void Carta(int numCarta);
	class View
	{
		public delegate void PedeDefinicoes(ref string asDefinicoes);
		public event PedeDefinicoes PedirDefinicoes;

		public event Carta CartaClicada;
		public event Carta CartaLargada;

		public delegate void Notificar();
		public event Notificar InterfaceDesenhada;
		public event Notificar NovoJogoDesenhado;
		public event Notificar UserClicouNovoJogo;
		public event Notificar UserClicouGravarJogo;
		public event Notificar UserClicouAbrirJogo;
		public event Notificar UserClicouSair;

		public event Notificar UserAlterouAsDefinicoes;


		public View()
        {
        }

		internal void DefinicoesCarregadas()
		{
			Console.WriteLine("Definicoes carregadaas");
		}

		internal void NovoJogoCriado()
		{
			throw new NotImplementedException();
		}

		internal void EstadoAtualizado()
		{
			throw new NotImplementedException();
		}
	}
}
