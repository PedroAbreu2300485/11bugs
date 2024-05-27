using System;
using System.Threading;
using _11bugs.View;
using _11bugs.Common;
using static _11bugs.View.View;

namespace _11bugs.Controller
{
	class Controller
	{
		private Model.Model model;
		private View.View view;

		public delegate void Notificar();

		public event Notificar CarregarDefinicoes;
		public event Notificar CriarNovoJogo;
		public event CardType CartaClicada;
		public event Carta CartaLargada;
		public event Notificar GravaJogo;
		public event Notificar AbreJogo;
		public event Notificar GravaEstatistica;

        public Controller(View.View view)
        {
			this.view = view;
			model = new Model.Model();

			CarregarDefinicoes += model.CarregarDefinicoes;
			//CriarNovoJogo += model.CriarNovoJogo;
			//CartaClicada += model.CartaClicada;
			//CartaLargada += model.CartaLargada;
			//GravaJogo += model.GravaJogo;
			//AbreJogo += model.AbreJogo;
			GravaEstatistica += model.GravaEstatistica;

			model.DefinicoesCarregadas += view.DefinicoesCarregadas;
			model.NovoJogoCriado += view.NovoJogoCriado;
			model.EstadoAtualizado += view.EstadoAtualizado;

			model.JogoGravado += JogoGravado;
			model.EstatisticasGravadas += EstatisticasGravadas;

			view.PedirDefinicoes += model.PedirDefinicoes; 

			//view.CartaClicada += model.CartaClicada;
			//view.CartaLargada += model.CartaLargada;

			view.InterfaceDesenhada += InterfaceDesenhada;
			view.NovoJogoDesenhado += NovoJogoDesenhado;
			view.UserClicouNovoJogo += UserClicouNovoJogo;
			view.UserClicouGravarJogo += UserClicouGravarJogo;
			view.UserClicouAbrirJogo += UserClicouAbrirJogo;
			view.UserClicouSair += UserClicouSair;

			view.UserAlterouAsDefinicoes += UserAlterouAsDefinicoes;

		}

		private void UserAlterouAsDefinicoes()
		{
			throw new NotImplementedException();
		}

		private void UserClicouSair()
		{
			throw new NotImplementedException();
		}

		private void UserClicouAbrirJogo()
		{
			throw new NotImplementedException();
		}

		private void UserClicouGravarJogo()
		{
			throw new NotImplementedException();
		}

		private void UserClicouNovoJogo()
		{
			throw new NotImplementedException();
		}

		private void NovoJogoDesenhado()
		{
			throw new NotImplementedException();
		}

		private void InterfaceDesenhada()
		{
			throw new NotImplementedException();
		}

		private void EstatisticasGravadas()
		{
			throw new NotImplementedException();
		}

		private void JogoGravado()
		{
			throw new NotImplementedException();
		}
	}
}
