using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRcodeGame.Models
{
    public class Inimigo
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        // public Vector3 posicao;

        // public void MoverPara(Vector3 alvo)
        // {
        //     posicao = Vector3.MoveTowards(posicao, alvo, 3f * Time.deltaTime);
        // }

        public void ReceberDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }

        public void Curar(int quantidade)
        {
            Vida += quantidade;
        }

        public bool EstaVivo()
        {
            return Vida > 0;
        }
    
    }
}