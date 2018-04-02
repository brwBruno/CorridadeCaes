using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain.Weapons
{
    class RedPotion : Arma, IPoc
    {
        public bool Used { get; private set; }

        public RedPotion(Jogo game, Point location) : base(game, location)
        {
            Used = false;
        }

        public override string Name { get { return "Red Potion"; } }

        public override void Attack(Direcao direction, Random random)
        {
            if (Used == false)
            {
                jogo.IncreasePlayerHealth(10, random);
                Used = true;
            }
        }
    }
}
