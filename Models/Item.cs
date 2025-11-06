using System;

namespace QRcodeGame.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Pode ser empilhável?
        public bool Stackable { get; set; } = true;

        // Tamanho máximo da pilha (quando Stackable == true)
        public int MaxStack { get; set; } = 99;
    }
}
