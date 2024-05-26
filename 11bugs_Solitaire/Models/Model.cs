using _11bugs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Text.Json;
using _11bugs.Views;

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

        private Settings configuracoes;

        public Model()
        {
			timer = new System.Timers.Timer(3000);
			timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
			timer.Enabled = true;
		}

		private void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			EstadoAtualizado?.Invoke(new Piles(true));
		}

		// Carregar definicoes
		internal void CarregarDefinicoes()
        {
            Console.WriteLine("Carrega definicoes");

            try
            {
                string filePath = "configuracoes.json"; // Caminho do arquivo de configuração
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    configuracoes = JsonSerializer.Deserialize<Configuracoes>(jsonString);
                    Console.WriteLine("Definições carregadas com sucesso.");

                    // Notifica os subscritores de que as definições foram carregadas
                    DefinicoesCarregadas?.Invoke();
                }
                else
                {
                    Console.WriteLine("Arquivo de definições não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar definições: {ex.Message}");
            }
        }

        internal void CriarNovoJogo(Piles piles)
        {
            Console.WriteLine("Cria novo jogo");

            // Inicializa o estado do tabuleiro
            piles = new Piles(false); // Passa false para inicializar o jogo em seu estado inicial padrão
            Console.WriteLine("Novo jogo inicializado.");

            // Notifica os subscritores de que um novo jogo foi criado
            NovoJogoCriado?.Invoke();

            // Atualiza o estado do tabuleiro para os subscritores
            EstadoAtualizado?.Invoke(piles);
        }

        internal void CartaClicada(Piles piles, List<(Cards card, bool isSelected)> cartas, Cards card)
        {
            // card contem a carta que foi cicada/largada
            Console.WriteLine($"Carta clicada: {card}");

            // Atualiza o estado do jogo com a carta clicada
            // Verificar se a carta pode ser selecionada
            var cartaSelecionada = cartas.FirstOrDefault(c => c.card == card);

            if (cartaSelecionada.card != null && cartaSelecionada.isSelected == false)
            {
                // Atualizar o estado da carta para indicar que foi selecionada
                cartaSelecionada.isSelected = true;
                Console.WriteLine($"Carta {card} foi selecionada.");

                // Atualizar o estado do tabuleiro conforme necessário
                // Exemplo: realizar alguma ação específica com a carta selecionada
                // ...
            }
            else
            {
                Console.WriteLine($"Carta {card} não pode ser selecionada.");
            }

            // Adicionar qualquer lógica adicional de atualização do tabuleiro aqui
            // ...

            // Notifica os subscritores da atualização do estado do jogo
            EstadoAtualizado?.Invoke(piles);

        }

        internal void CartaLargada(Piles piles, List<(Cards card, bool isSelected)> cartas, Cards card)
        {
            // Implementação da lógica de largar uma carta
            Console.WriteLine($"Carta a ser largada: {card}");
            var cartaSelecionada = cartas.FirstOrDefault(c => c.card == card);

            if (cartaSelecionada.card != null && cartaSelecionada.isSelected == true)
            {
                // Atualizar o estado da carta para indicar que foi largada
                cartaSelecionada.isSelected = false;
                Console.WriteLine($"Carta {card} foi largada.");

                // Atualizar o estado do tabuleiro conforme necessário
            }
            else
            {
                Console.WriteLine($"Carta {card} não pode ser selecionada.");
            }
        }

        internal void GravaJogo(Piles piles)
        {
            Console.WriteLine("A gravar jogo...");
            try
            {
                string jsonString = JsonSerializer.Serialize(piles);
                File.WriteAllText("jogo_salvo.json", jsonString);
                Console.WriteLine("Jogo gravado com sucesso.");
                JogoGravado?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar o jogo: {ex.Message}");
            }
        }

        internal void AbreJogo(Piles piles)
        {
            Console.WriteLine("A abrir jogo...");
            try
            {
                if (File.Exists("jogo_salvo.json"))
                {
                    string jsonString = File.ReadAllText("jogo_salvo.json");
                    piles = JsonSerializer.Deserialize<Piles>(jsonString);
                    Console.WriteLine("Jogo aberto com sucesso.");
                    EstadoAtualizado?.Invoke(piles);
                }
                else
                {
                    Console.WriteLine("Nenhum jogo salvo encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao abrir o jogo: {ex.Message}");
            }
        }

        internal void GravaEstatistica()
        {
            Console.WriteLine("A gravar estatísticas...");
            try
            {
                // Serializa as estatísticas para um arquivo JSON
                //string jsonString = JsonSerializer.Serialize(estatisticas);
                //File.WriteAllText("estatisticas.json", jsonString);
                Console.WriteLine("Estatísticas gravadas com sucesso.");
                EstatisticasGravadas?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar as estatísticas: {ex.Message}");
            }
        }

        internal void PedirDefinicoes(ref string asDefinicoes)
        {
            try
            {
                // Lê as definições do arquivo "definicoes.txt"
                if (File.Exists("definicoes.txt"))
                {
                    asDefinicoes = File.ReadAllText("definicoes.txt");
                    Console.WriteLine("Definições carregadas com sucesso.");
                }
                else
                {
                    Console.WriteLine("Arquivo de definições não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar as definições: {ex.Message}");
            }
        }
    }
}
