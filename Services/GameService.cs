using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRcodeGame.Models;

// Controla o estado do jogo, carrega save;

namespace QRcodeGame.Services
{
    public class SaveGameService
    {
        private const string SavePath = "savegame.JSON";
        public void SalvarJogo(GameData dados)
        {
            // Lógica para salvar dados
            string json = System.Text.Json.JsonSerializer.Serialize(dados);
            File.WriteAllText(SavePath, json);
        }
        public GameData CarregarJogo()
        {
            // Lógica para carregar dados
            if (!File.Exists(SavePath))
                return new GameData(); // Retorna dados padrão se não houver save

            string json = File.ReadAllText(SavePath);
            return System.Text.Json.JsonSerializer.Deserialize<GameData>(json);
        }
    }

    public class GameStateService
    {
        public GameState EstadoAtual { get; private set; } = GameState.Menu;

        public void IniciarJogo()
        {
            // Lógica para iniciar o jogo
            EstadoAtual = GameState.Jogando;
        }
        public void pausarJogo()
        {
            // Lógica para pausar o jogo
            EstadoAtual = GameState.Pausado;
        }
        public void GameOver()
        {
            // Lógica para encerrar o jogo
            EstadoAtual = GameState.GameOver;
        }
        public void VoltarAoMenu()
        {
            // Lógica para voltar ao menu
            EstadoAtual = GameState.Menu;
        }
        
    }

    public class GameData
    { /* dados do save */ 
        public string JogadorId { get; set; }    
        public int Nivel { get; set; }
        public int Pontuacao { get; set; }
        public List<string> PersonagensDesbloqueados { get; set; } = new List<string>();
        public List<string> ItensNoInventario { get; set; } = new List<string>();
    
    }
    public enum GameState { Menu, Jogando, Pausado, GameOver }
}