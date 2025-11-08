// Toda a movimentação dos personagens e inimigos;
// integrar com o Models
// using QRcodeGame.Models


namespace QRcodeGame.Services
{
    public class PersonagemMoviment
    {
        public void MovimentacaoPersonagem(Personagem objPersonagem, InputData input) // Sua movimentação, mobile
        {
            objPersonagem.posicao += input.direcao * velocidade * Time.deltaTime;
        }
    }
    public class EnemyIAService
    {
        public void CerebroInimigo(Inimigo objInimigo, Personagem objPlayer) // IA dos inimigos
        {
           objInimigo.MoverPara(objPlaye.posicao);
        }
    }
    

}