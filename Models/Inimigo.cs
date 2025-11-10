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
    
        public void ReceberDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }
}