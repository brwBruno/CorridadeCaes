using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain
{
    public abstract class Arma : Mover
    {
        private bool pegou;
        public bool Pegou { get { return pegou; } }
        public Point Localizacao { get { return localizacao; } }

        public Arma(Jogo game, Point location) : base(game, location)
        {
            this.jogo = game;
            this.localizacao = location;
            pegou = false;
        }

        public void PickedUpWeapon()
        {
            pegou = true;
        }

        public abstract string Name { get; }

        public abstract void Attack(Direcao direction, Random random);

        protected bool DamageEnemy(Direcao direction, int radius, int damage, Random random)
        {
            Point target = jogo.Localizacaojogador;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Inimigo enemy in jogo.inimigos)
                {
                    if (NearBy(enemy.Localizacao, target, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
