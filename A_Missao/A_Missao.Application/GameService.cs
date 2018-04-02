//using A_Missao.Domain;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace A_Missao.Application
//{
//    public class GameService : MoverService
//    {
//        Game _game = new Game();
//        PlayerService _playerService = new PlayerService();
//        EnemyService _enemyService = new EnemyService();

//        public void Move(Direction direction, Random random)
//        {
//            _playerService.Move(direction);
//            foreach (Enemy _enemy in _game.enemies)
//                _enemyService.Move(random);

//            if (_enemyService.NearPlayer())
//                _enemyService.HitPlayer();
//        }

//        public void Equip(string weapon)
//        {
//            _playerService.Equip(weapon);
//        }

//        public bool CheckPlayerINventory(string weapon)
//        {
//            return _playerService.Contains(weapon);
//        }

//        public void HitPlayer(int maxDamage, Random random)
//        {
//            _playerService.Hit(maxDamage, random);
//        }

//        public void IncreasePlayerHealth(int health, Random random)
//        {
//            _playerService.IncreaseHealth(health, random);
//        }

//        public void Attack(Direction direction, Random random)
//        {
//            _playerService.Attack(direction, random);
//            foreach (Enemy _enemy in _game.enemies)
//                _enemyService.Move(random);
//        }

//        private Point GetRandomLocation(Random random)
//        {
//            return new Point(_game._boundaries.Left + random.Next(_game._boundaries.Right / 10 - _game._boundaries.Left / 10) * 10,
//                _game._boundaries.Top + random.Next(_game._boundaries.Bottom / 10 - _game._boundaries.Top / 10) * 10);
//        }

//        public void NewLevel(Random random)
//        {
//            _game.level++;
//            switch (_game.level)
//            {
//                case 1:
//                    _game.enemies = new List<Enemy>();
//                    _game.enemies.Add(new Bat(this, GetRandomLocation(random));
//                    _game._weaponInRoom = new Sword(this, GetRandomLocation(random));
//                    break;
//            }
//        }
//    }
//}
