using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain.Weapons
{
    class BluePotion : Arma, IPoc
    {
        public bool Used { get; private set; }

        public BluePotion(Jogo game, Point location) : base(game, location)
        {
            Used = false;
        }

        public override string Name { get { return "Blue Potion"; } }

        public override void Attack(Direcao direction, Random random)
        {
            if (Used == false)
            {
                jogo.IncreasePlayerHealth(5, random);
                Used = true;
            }
        }
    }
}
