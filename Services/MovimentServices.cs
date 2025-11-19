using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRcodeGame.Models;

// Toda a movimentação dos personagens e inimigos;
// integrar com o Models
// using QRcodeGame.Models


namespace QRcodeGame.Services
{
    public struct Vec3 // Estrutura para representar vetores 3D
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        public static Vec3 operator +(Vec3 a, Vec3 b)
            => new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);

        public static Vec3 operator *(Vec3 a, float f)
            => new Vec3(a.x * f, a.y * f, a.z * f);
    }
    public static class TimeSim // Simulação de tempo
    {
        public static float deltaTime = 1f / 60f; // simulação de 60 FPS
    }     
    
    // public class PersonagemMoviment
    // {
    //     private float velocidade = 5.0f; // Velocidade do personagem
    //     public void MovimentacaoPersonagem(Personagem objPersonagem, InputData input) // Sua movimentação, mobile
    //    {
            
    //         objPersonagem.posicao += input.direcao * velocidade * Time.deltaTime;
    //     }
    // }
    // public class EnemyIAService
    // {
    //     public void CerebroInimigo(Inimigo objInimigo, Personagem objPlayer) // IA dos inimigos
    //     {
    //         objInimigo.MoverPara(objPlayer.posicao);
    //     }
    // }


}