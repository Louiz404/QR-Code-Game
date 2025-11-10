using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRcodeGame.Models;
// Lógica de combate, cálculo de dano;

namespace QRcodeGame.Services
{
    public class CalculoDano
    {
        public int CalcularDanoPersonagem(Personagem personagem) // Seu dano nos inimigos
        {
            // int dadoFinal = statsPersonagem.Forca * 2;
            // return dadoFinal;
            return personagem.Ataque * 5 + personagem.Forca;
        }
        public int CalcularDanoInimigo(Inimigo inimigo) // Dano dos inimigos em você
        {
            // int dadoFinal = statsInimigo.Ataque * 5;
            // return dadoFinal;
            return inimigo.Ataque * 3;
        }
    }
    public class Combate
    {
        private CalculoDano _calculador = new CalculoDano();

        public void PlayerCombat(Personagem personagem, Inimigo inimigo)
        {
            int dano = _calculador.CalcularDanoPersonagem(personagem);
            inimigo.ReceberDano(dano);
        }
        public void EnemyCombat(Inimigo inimigo, Personagem personagem)
        {
            int dano = _calculador.CalcularDanoInimigo(inimigo);
            personagem.ReceberDano(dano);
        }
    }
}