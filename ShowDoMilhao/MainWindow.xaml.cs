using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowDoMilhao
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public Jogador Jogador;
        public List<Pergunta> Perguntas;
        public int IDPerguntaAtual;

        public MainWindow()
        {
            Perguntas = new List<Pergunta>();
            InitializeComponent();
            IDPerguntaAtual = 0;

            var pergunta1 = new Pergunta
            {
                Enunciado = "Quem fez os gols da final da copa do mundo 2002?",
                Resposta1 = "Ronaldo",
                Resposta2 = "Rivaldo",
                Resposta3 = "Carlinhos Bala",
                Resposta4 = "Dutra",
                Resposta5 = "Juninho Pernambucano",
                RespostaCorreta = 1
            };

            var pergunta2 = new Pergunta
            {
                Enunciado = "Ano da indepedência do Brasil?",
                Resposta1 = "1823",
                Resposta2 = "1898",
                Resposta3 = "1822",
                Resposta4 = "1889",
                Resposta5 = "2000",
                RespostaCorreta = 3
            };

            var pergunta3 = new Pergunta
            {
                Enunciado = "Qual clube tem mais champions league?",
                Resposta1 = "Manchester United",
                Resposta2 = "Barcelona",
                Resposta3 = "Milan",
                Resposta4 = "Real Madrid",
                Resposta5 = "Liverpool",
                RespostaCorreta = 4
            };

            var pergunta4 = new Pergunta
            {
                Enunciado = "Qual clube não tem mundial?",
                Resposta1 = "Palmeiras",
                Resposta2 = "Corinthians",
                Resposta3 = "Internacional",
                Resposta4 = "São Paulo",
                Resposta5 = "Flamengo",
                RespostaCorreta = 1
            };

            var pergunta5 = new Pergunta
            {
                Enunciado = "Melhor jogador do mundo 2007?",
                Resposta1 = "Ronaldo",
                Resposta2 = "Beckham",
                Resposta3 = "Seedorf",
                Resposta4 = "Borja",
                Resposta5 = "Kaká",
                RespostaCorreta = 5
            };

            var pergunta6 = new Pergunta
            {
                Enunciado = "Único clube a ser bicampeão da champions na era moderna?",
                Resposta1 = "Real Madrid",
                Resposta2 = "Barcelona",
                Resposta3 = "Milan",
                Resposta4 = "Bayern",
                Resposta5 = "Liverpool",
                RespostaCorreta = 1
            };

            var pergunta7 = new Pergunta
            {
                Enunciado = "Campeão da copa do brasil 2008?",
                Resposta1 = "Corinthians",
                Resposta2 = "Flamengo",
                Resposta3 = "Palmeiras",
                Resposta4 = "Sport",
                Resposta5 = "Curitiba",
                RespostaCorreta = 4
            };

            var pergunta8 = new Pergunta
            {
                Enunciado = "Jogador conhecido como 'O Bruxo'?",
                Resposta1 = "Edmundo",
                Resposta2 = "Ronaldinho",
                Resposta3 = "Adriano",
                Resposta4 = "Neymar",
                Resposta5 = "Ronaldo",
                RespostaCorreta = 2
            };

            var pergunta9 = new Pergunta
            {
                Enunciado = "Clube brasileiro com mais titulos mundiais?",
                Resposta1 = "Flamengo",
                Resposta2 = "Corinthians",
                Resposta3 = "Internacional",
                Resposta4 = "Cruzeiro",
                Resposta5 = "São Paulo",
                RespostaCorreta = 5
            };

            var pergunta10 = new Pergunta
            {
                Enunciado = "Ano do golpe republicano?",
                Resposta1 = "1889",
                Resposta2 = "1826",
                Resposta3 = "1898",
                Resposta4 = "1857",
                Resposta5 = "1841",
                RespostaCorreta = 1
            };

            Perguntas.Add(pergunta1);
            Perguntas.Add(pergunta2);
            Perguntas.Add(pergunta3);
            Perguntas.Add(pergunta4);
            Perguntas.Add(pergunta5);
            Perguntas.Add(pergunta6);
            Perguntas.Add(pergunta7);
            Perguntas.Add(pergunta8);
            Perguntas.Add(pergunta9);
            Perguntas.Add(pergunta10);
        }

        private void MostrarPergunta(Pergunta pergunta)
        {
            LabelPontuacao.Content = "Pontuação " + Jogador.Pontuacao;
            TextBlockEnunciado.Text = pergunta.Enunciado;
            RadioButtonResposta1.Content = pergunta.Resposta1;
            RadioButtonResposta2.Content = pergunta.Resposta2;
            RadioButtonResposta3.Content = pergunta.Resposta3;
            RadioButtonResposta4.Content = pergunta.Resposta4;
            RadioButtonResposta5.Content = pergunta.Resposta5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nome = TextBoxNomeJogador.Text;
            this.Jogador = new Jogador(nome, 0);
            GridTelaAbertura.Visibility = Visibility.Hidden;
            GridTelaPergunta.Visibility = Visibility.Visible;

            LabelNomeJogador.Content = 
                this.Jogador.Nome 
                + " jogando";

            MostrarPergunta(Perguntas[0]);

            Console.WriteLine(this.Jogador.Nome);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Checar se a resposta está correta
            var perguntaAtual = Perguntas[IDPerguntaAtual];
            var respostaPergunta = perguntaAtual.RespostaCorreta;

            int respostaSelecionada = 0;

            if(RadioButtonResposta1.IsChecked.Value) respostaSelecionada = 1;
            else if(RadioButtonResposta2.IsChecked.Value) respostaSelecionada = 2;
            else if(RadioButtonResposta3.IsChecked.Value) respostaSelecionada = 3;
            else if(RadioButtonResposta4.IsChecked.Value) respostaSelecionada = 4;
            else if(RadioButtonResposta5.IsChecked.Value) respostaSelecionada = 5;        

            if(respostaSelecionada == respostaPergunta)
            {
                Jogador.Pontuacao = Jogador.Pontuacao + 10;
            }
            else
            {
                MostrarFinal();
            }

            IDPerguntaAtual = IDPerguntaAtual + 1;

            if(IDPerguntaAtual < Perguntas.Count)
            {
                MostrarPergunta(Perguntas[IDPerguntaAtual]);
            }
            else
            {
                MostrarFinal();
            }
        }

        private void MostrarFinal()
        {
            GridTelaPergunta.Visibility = Visibility.Hidden;
            GridTelaFinal.Visibility = Visibility.Visible;

            TextBlockFinal.Text =
                "O jogo acabou!\n A sua pontuação foi: " +
                Jogador.Pontuacao +
                " pontos!";
        }
    }

    public class Pergunta
    {
        public string Enunciado;
        public string Resposta1;
        public string Resposta2;
        public string Resposta3;
        public string Resposta4;
        public string Resposta5;
        public string Resposta6;
        public string Resposta7;
        public string Resposta8;
        public string Resposta9;
        public string Resposta10;
        public int RespostaCorreta;
    }
}
