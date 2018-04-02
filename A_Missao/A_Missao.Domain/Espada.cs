using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain.Weapons
{
    class Sword : Arma
    {
        public Sword(Jogo game, Point location) : base(game, location)
        {
        }

        public override string Name { get { return "Sword"; } }

        public override void Attack(Direcao direction, Random random)
        {
            DamageEnemy(direction, 25, 3, random);
        }
    }
}
