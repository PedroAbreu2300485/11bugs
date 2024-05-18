using System;
using System.Threading;
using _11bugs.View;

namespace _11bugs.Controller
{
	class Controller
    {
        private Model.Model model;
        private View.View view;

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
            view = new View.View();
            model = new Model.Model();

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

            // Para testes
            Thread.Sleep(1000);
            CarregarDefinicoes();  // para testes na view
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
