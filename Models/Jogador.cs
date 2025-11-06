using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRcodeGame.Models
{
    public class Jogador
    {
        public string PlayerId { get; set; }
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public DateTime DataCadastro { get; set; }
        // Inventário do jogador
        public Inventario Inventario { get; set; } = new Inventario();

        // Conveniências
        public int AdicionarItemAoInventario(Item item, int quantidade = 1)
        {
            return Inventario.AddItem(item, quantidade);
        }

        public bool RemoverItemDoInventario(string itemId, int quantidade = 1)
        {
            return Inventario.RemoveItem(itemId, quantidade);
        }
    }
}