using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRcodeGame.Models
{
    public enum RaridadeTipo
{
    Comum,
    Raro,
    Epico,
    Lendario
}
    public class Personagem
    {
        public string PersonagemId { get; set; }
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public string HabilidadeEspecial { get; set; }
        public string Descricao { get; set; }
        public string ImagemId { get; set; }
        public RaridadeTipo Raridade { get; set; }
    }
}