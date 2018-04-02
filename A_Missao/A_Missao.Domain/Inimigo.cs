using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain
{
    public abstract class Inimigo : Mover
    {
        private const int NearPlayerDistance = 25;
        private int hitPoints;
        public int HitPoints { get { return hitPoints; } }
        private int powerDamage;
        public int PowerDamage { get { return powerDamage; } }
        public bool dead
        {
            get
            {
                if (hitPoints <= 0)
                    return true;
                else
                    return false;
            }
        }

        public Inimigo(Jogo game, Point location, int hitPoints, int powerDamage) : base(game, location)
        {
            this.hitPoints = hitPoints;
            this.powerDamage = powerDamage;
        }

        public abstract void Move(Random random);

        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        public bool NearPlayer()
        {
            return (NearBy(jogo.Localizacaojogador, NearPlayerDistance));
        }

        protected Direcao FindPlayerDirection(Point playerLocation)
        {
            Direcao directionToMove;

            if (playerLocation.X > localizacao.X + 10)
                directionToMove = Direcao.Right;
            else if (playerLocation.X < localizacao.X - 10)
                directionToMove = Direcao.Left;
            else if (playerLocation.Y < localizacao.Y - 10)
                directionToMove = Direcao.Up;
            else
                directionToMove = Direcao.Down;
            return directionToMove;
        }
    }
}
