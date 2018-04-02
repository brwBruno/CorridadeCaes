using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain
{
    public class Zumbi : Inimigo
    {
        private int aux;

        public Zumbi(Jogo game, Point location) : base(game, location, 10, 4)
        {
        }

        public override void Move(Random random)
        {
            aux = (int)FindPlayerDirection(jogo.Localizacaojogador);
            base.localizacao = Move((Direcao)random.Next(aux, 4), jogo.Limites, 15);
        }
    }
}
