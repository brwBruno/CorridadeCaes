using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain
{
    public abstract class Mover
    {
        public Point localizacao;
        public Point Localizacao { get { return localizacao; } }
        protected Jogo jogo;

        public Mover(Jogo game, Point location)
        {
            this.jogo = game;
            this.localizacao = location;
        }

        public bool NearBy(Point locationToCheck, int distance)
        {
            if (Math.Abs(localizacao.X - locationToCheck.X) < distance && (Math.Abs(localizacao.Y - locationToCheck.Y) < distance))
                return true;
            else
                return false;
        }
        
        public bool NearBy(Point enemyLocation, Point targetLocation, int radius)
        {
            if (Math.Abs(enemyLocation.X - targetLocation.X) <= radius && (Math.Abs(enemyLocation.Y - targetLocation.Y) <= radius))
                return true;
            else
                return false;
        }

        public Point Move(Direcao direction, Rectangle boundaries, int moveInterval)
        {
            Point newLocaion = localizacao;
            switch (direction)
            {
                case Direcao.Up:
                    if (newLocaion.Y - moveInterval >= boundaries.Top)
                        newLocaion.Y -= moveInterval;
                    break;

                case Direcao.Down:
                    if (newLocaion.Y + moveInterval <= boundaries.Bottom)
                        newLocaion.Y += moveInterval;
                    break;

                case Direcao.Left:
                    if (newLocaion.X - moveInterval >= boundaries.Left)
                        newLocaion.X -= moveInterval;
                    break;

                case Direcao.Right:
                    if (newLocaion.X + moveInterval <= boundaries.Right)
                        newLocaion.X += moveInterval;
                    break;

                default: break;
            }

            return newLocaion;
        }
    }
}
