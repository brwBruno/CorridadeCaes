//using A_Missao.Domain;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace A_Missao.Application
//{
//    public class PlayerService : MoverService
//    {
//        Player _player = new Player();

//        public void Move()
//        {
//            _player. = Move(direction, )
//        }

//        public void Equip(string weaponName)
//        {
//            foreach (Weapon weapon in _player.inventory)
//            {
//                if (weapon.name == weaponName)
//                    _player.equippedWeapon = weapon;
//            }
//        }

//        public void Hit(int maxDamage, Random random)
//        {
//            _player.hitPoints -= random.Next(1, maxDamage);
//        }

//        public void IncreaseHealth(int health, Random random)
//        {
//            _player.hitPoints += random.Next(1, health);
//        }

//        public void Attack(Direction direction, Random random)
//        {
//            //_player.
//        }

//        public bool Contains(string weapon)
//        {
//            return _player.weapons.Contains(weapon);
//        }
//    }
//}
