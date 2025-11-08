// Lógica de combate, cálculo de dano;

namespace QRcodeGame.Services
{
    public class CalculoDano
    {
        public int DanoPersonagem(Personagem statsPersonagem) // Seu dano nos inimigos
        {
            int dadoFinal = statsPersonagem.Forca * 2;
            return dadoFinal;
        }
        public int DanoInimigo() // Dano dos inimigos em você
        {
            int dadoFinal = statsInimigo.Ataque * 5;
            return dadoFinal;
        }
    }
    public class Combat
    {
        private CalculoDano _calculadorDeDano = new CalculoDano();

        public void PlayerCombat(Personagem personagem, Inimigo inimigo)
        {
            int danoParaAplicar = _calculadorDeDano.CalcularDanoPersonagem(personagem);
            inimigo.ReceberDano(danoParaAplicar);
        }
    }
}