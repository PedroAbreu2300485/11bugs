using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Decktacular.View;

namespace Decktacular
{
	class Controller
	{
		private Model model;
		private View view;

		public delegate void Notificar();

		public event Notificar CarregarDefinicoes;
		public event Notificar CriarNovoJogo;
		public event Carta CartaClicada;
		public event Carta CartaLargada;
		public event Notificar GravaJogo;
		public event Notificar AbreJogo;
		public event Notificar GravaEstatistica;

		public void IniciarPrograma()
		{
			view = new View();
			model = new Model();

			CarregarDefinicoes += model.CarregarDefinicoes;
			CriarNovoJogo += model.CriarNovoJogo;
			CartaClicada += model.CartaClicada;
			CartaLargada += model.CartaLargada;
			GravaJogo += model.GravaJogo;
			AbreJogo += model.AbreJogo;
			GravaEstatistica += model.GravaEstatistica;

			model.DefinicoesCarregadas += view.DefinicoesCarregadas;
			model.NovoJogoCriado += view.NovoJogoCriado;
			model.EstadoAtualizado += view.EstadoAtualizado;

			model.JogoGravado += JogoGravado;
			model.EstatisticasGravadas += EstatisticasGravadas;

			view.PedirDefinicoes += model.PedirDefinicoes; // Class
			
			view.CartaClicada += model.CartaClicada; // int
			view.CartaLargada += model.CartaLargada;
			
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
