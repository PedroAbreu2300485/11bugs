using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decktacular
{
	class Model
	{
		public delegate void Notificar();
		public event Notificar DefinicoesCarregadas;
		public event Notificar NovoJogoCriado;

		public event Notificar EstadoAtualizado;
		public event Notificar JogoGravado;

		public event Notificar EstatisticasGravadas;
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
