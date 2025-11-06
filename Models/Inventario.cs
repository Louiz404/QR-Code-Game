using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace QRcodeGame.Models
{
    public class ItemStack
    {
        public Item Item { get; set; }
        public int Quantidade { get; set; }
    }

    public class Inventario
    {
        // Lista de pilhas de itens
        public List<ItemStack> Items { get; set; } = new List<ItemStack>();

        // Quantidade máxima de slots (cada pilha conta como 1 slot)
        public int Capacidade { get; set; } = 30;
        public Jogador Jogador { get; set; }

        // Tenta adicionar uma quantidade do item. Retorna quantidade restante que não coube (0 = tudo encaixou).
        public int AddItem(Item item, int quantidade = 1)
        {
            if (item == null) throw new ArgumentNullException("O item não se encontra disponivel, ou não existe.", nameof(item));
            if (quantidade <= 0) return 0;
            if (Jogador == null) throw new InvalidOperationException("O inventário não está associado a um jogador.");
                          
            
            // Se empilhável, tenta colocar nas pilhas existentes
            if (item.Stackable)
            {
                var existe = Items.FirstOrDefault(s => s.Item.Id == item.Id && s.Quantidade < item.MaxStack);
                while (existe != null && quantidade > 0)
                {
                    var espaço = item.MaxStack - existe.Quantidade;
                    var toAdd = Math.Min(espaço, quantidade);
                    existe.Quantidade += toAdd;
                    quantidade -= toAdd;
                    existe = Items.FirstOrDefault(s => s.Item.Id == item.Id && s.Quantidade < item.MaxStack);
                }
            }

            // Enquanto houver quantidade e espaço de slots, cria novas pilhas
            while (quantidade > 0 && Items.Count < Capacidade)
            {
                var toCreate = item.Stackable ? Math.Min(item.MaxStack, quantidade) : 1;
                Items.Add(new ItemStack { Item = item, Quantidade = toCreate });
                quantidade -= toCreate;
            }

            // Retorna o que sobrou (não coube)
            return quantidade;
        }

        // Remove uma quantidade do item; retorna true se removeu tudo pedido (false se não havia quantidade suficiente)
        public bool RemoveItem(string itemId, int quantidade = 1)
        {
            if (string.IsNullOrWhiteSpace(itemId)) return false;
            if (quantidade <= 0) return true;

            var total = Items.Where(s => s.Item.Id == itemId).Sum(s => s.Quantidade);
            if (total < quantidade) return false;

            // Remove das pilhas começando pela primeira
            var stacks = Items.Where(s => s.Item.Id == itemId).ToList();
            foreach (var stack in stacks)
            {
                if (quantidade <= 0) break;
                if (stack.Quantidade <= quantidade)
                {
                    quantidade -= stack.Quantidade;
                    Items.Remove(stack);
                }
                else
                {
                    stack.Quantidade -= quantidade;
                    quantidade = 0;
                }
            }

            return true;
        }

        // Obtém a lista atual (cópia) de pilhas
        public List<ItemStack> GetItens() => Items.Select(s => new ItemStack { Item = s.Item, Quantidade = s.Quantidade }).ToList();

        // Salva o inventário em JSON no caminho informado
        public void Save(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(path, JsonSerializer.Serialize(this, options));
        }

        // Carrega um inventário do caminho; se não existir, retorna um inventário vazio
        public static Inventario Load(string path)
        {
            if (!File.Exists(path)) return new Inventario();
            var text = File.ReadAllText(path);
            try
            {
                return JsonSerializer.Deserialize<Inventario>(text) ?? new Inventario();
            }
            catch
            {
                // Em caso de erro de desserialização, retornamos inventário vazio (podemos logar/propagar conforme necessário)
                return new Inventario();
            }
        }
    }
}
