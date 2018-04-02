using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain.Weapons
{
    class Mace : Arma
    {
        public Mace(Jogo game, Point location) : base(game, location)
        {
        }

        public override string Name { get { return "Mace"; } }

        public override void Attack(Direcao direction, Random random)
        {
            DamageEnemy(direction, 35, 6, random);
        }
    }
}
