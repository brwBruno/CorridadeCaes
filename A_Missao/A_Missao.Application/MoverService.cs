//using A_Missao.Domain;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace A_Missao.Application
//{
//    public abstract class MoverService
//    {
//        Game _game = new Game();
//        Mover _mover = new Mover(_game, location);

//        public bool NearBy(Point locationToCheck, int distance)
//        {
//            if (Math.Abs(_mover._location.X - locationToCheck.X) < distance && (Math.Abs(_mover._location.Y - locationToCheck.Y) < distance))
//                return true;
//            else
//                return false;
//        }

//        public Point Move(Direction direction, Rectangle boundaries)
//        {
//            Point newLocaion = _mover._location;
//            switch (direction)
//            {
//                case Direction.Up:
//                    if (newLocaion.Y - _mover.moveInterval >= boundaries.Top)
//                        newLocaion.Y -= _mover.moveInterval;
//                    break;

//                case Direction.Down:
//                    if (newLocaion.Y + _mover.moveInterval <= boundaries.Bottom)
//                        newLocaion.Y += _mover.moveInterval;
//                    break;

//                case Direction.Left:
//                    if (newLocaion.X - _mover.moveInterval >= boundaries.Left)
//                        newLocaion.X -= _mover.moveInterval;
//                    break;

//                case Direction.Right:
//                    if (newLocaion.X + _mover.moveInterval <= boundaries.Right)
//                        newLocaion.X += _mover.moveInterval;
//                    break;

//                default: break;
//            }

//            return newLocaion;
//        }
//    }
//}
