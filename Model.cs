﻿using System;
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

		internal void CarregarDefinicoes()
		{
			Console.WriteLine("Crrega definicoes");
		}

		internal void CriarNovoJogo()
		{
			throw new NotImplementedException();
		}

		internal void CartaClicada(int numCarta)
		{
			throw new NotImplementedException();
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
