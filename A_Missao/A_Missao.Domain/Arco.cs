using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain.Weapons
{
    class Bow : Arma
    {
        public Bow(Jogo game, Point location) : base(game, location)
        {
        }

        public override string Name { get { return "Bow"; } }

        public override void Attack(Direcao direction, Random random)
        {
            DamageEnemy(direction, 80, 1, random);
        }
    }
}
