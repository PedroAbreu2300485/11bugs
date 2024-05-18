using _11bugs.Common;
using _11bugs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11bugs.View
{
    public delegate void Carta(int numCarta);
    class View
    {
        Game1 game;
        Board board;

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
            board = new Board();

            game = new Game1(board);
            game.Run();
        }

        internal void DefinicoesCarregadas()
        {
            Console.WriteLine("Definicoes carregadaas");
        }

        internal void NovoJogoCriado()
        {
            Console.WriteLine("NovoJogoCriado");
        }

        internal void EstadoAtualizado()
        {
            Console.WriteLine("Estado atualizado");
        }
    }
}
