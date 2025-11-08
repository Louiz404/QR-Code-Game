// Controla o estado do jogo, carrega save;

namespace QRcodeGame.Services
{
    public class SaveGameService
    {
        public void SalvarJogo(GameData dados)
        {
            // Lógica para salvar dados
        }
        public GameData CarregarJogo()
        {
            // Lógica para carregar dados
            GameData dadosCarregados = new GameData();
            return dadosCarregados;
        }
    }

    public class GameStateService{
        public GameState EstadoAtual {get; private set;}

        public void pausar()
        {
            // Lógica para pausar o jogo
        }
        public void IniciarJogo()
        {
            // Lógica para iniciar o jogo
        }
    }

    public class GameData { /* dados do save */ }
    public enum GameState { Menu, Jogando, Pausado, GameOver}
}