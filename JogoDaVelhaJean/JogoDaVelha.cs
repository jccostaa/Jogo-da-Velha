using System;

namespace JogoDaVelhaJean
{
    public class JogoDaVelha
    {
        private bool fimDeJogo;
        private char[] posicao;
        private char vez;
        private int quantidadePreenchida;


        public JogoDaVelha()
        {
            fimDeJogo = false;
            posicao = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            vez = 'X';
            quantidadePreenchida = 0;
        }

        public void Iniciar()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDoJogo();
                MudarVez();
            }
        }


        private void VerificarFimDoJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if(VitoriaDiagonal() || VitoriaHorizontal() || VitoriaVertical())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo! {vez} ganhou!");
                return;
            }

            if(quantidadePreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo, Empate!");
            }
        }

        private bool VitoriaHorizontal()
        {
            bool vitorialinha1 = (posicao[0] == posicao[1] && posicao[1] == posicao[2]);
            bool vitorialinha2 = (posicao[3] == posicao[4] && posicao[4] == posicao[5]);
            bool vitorialinha3 = (posicao[6] == posicao[7] && posicao[7] == posicao[8]);

            return vitorialinha1 || vitorialinha2 || vitorialinha3;

        }

        private bool VitoriaVertical()
        {
            bool vitoriacoluna1 = (posicao[0] == posicao[3] && posicao[3] == posicao[6]);
            bool vitoriacoluna2 = (posicao[1] == posicao[4] && posicao[4] == posicao[7]);
            bool vitoriacoluna3 = (posicao[2] == posicao[5] && posicao[5] == posicao[8]);

            return vitoriacoluna1 || vitoriacoluna2 || vitoriacoluna3;
        }

        private bool VitoriaDiagonal()
        {
            bool vitoriadiagonal1 = (posicao[0] == posicao[4] && posicao[4] == posicao[8]);
            bool vitoriadiagonal2 = (posicao[2] == posicao[4] && posicao[4] == posicao[6]);

            return vitoriadiagonal1 || vitoriadiagonal2;
        }

        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"Vez de {vez}, escolha uma posição disponivel");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaDoUsuario(posicaoEscolhida))
            {
                Console.WriteLine("Jogada invalida, escolha um numero de 1 a 9 que esteja disponivel");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            posicao[indice] = vez;
            quantidadePreenchida++;
        }

        private bool ValidarEscolhaDoUsuario(int posicaoEscolhida)
        {
            try
            {
                int indice = posicaoEscolhida - 1;
                return (posicao[indice] != 'O' && posicaoEscolhida != 'X' && posicao[indice] != 'X' && posicaoEscolhida != 'O');
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Inválido!");
                return false;
            }
        }
        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }
        private void MudarVez()
        {
            if (vez == 'X')
                vez = 'O';
            else 
                vez = 'X';
        }

        private string ObterTabela()
        {
            return $"__{posicao[0]}__|__{posicao[1]}__|__{posicao[2]}__\n" +
                   $"__{posicao[3]}__|__{posicao[4]}__|__{posicao[5]}__\n" +
                   $"  {posicao[6]}  |  {posicao[7]}  |  {posicao[8]}  \n\n"; 
        }
        
    }
}
