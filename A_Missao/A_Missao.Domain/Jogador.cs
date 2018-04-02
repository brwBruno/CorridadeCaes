using A_Missao.Domain.Weapons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain
{
    public class Jogador : Mover
    {
        public Arma armaequipada;
        private int ponstosdeVida;
        public int PontosdeVida { get { return ponstosdeVida; } }

        public List<Arma> inventario = new List<Arma>();
        public List<string> Armas
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Arma weapon in inventario)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Jogador(Jogo game, Point location) : base(game, location)
        {
            ponstosdeVida = 10;   
        }

        public void Hit(int maxDamage, Random random)
        {
            ponstosdeVida -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            ponstosdeVida += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Arma weapon in inventario)
            {
                if (weapon.Name == weaponName)
                    armaequipada = weapon;
            }
        }

        public void Move(Direcao direction)
        {
            base.localizacao = Move(direction, jogo.Limites, 10);
        }

        public void Attack(Direcao direction, Random random)
        {
            armaequipada.Attack(direction, random);
            if (armaequipada is BluePotion)
                inventario.RemoveAll(inventory => inventory.Name == "Blue Potion");
            else if (armaequipada is RedPotion)
                inventario.RemoveAll(inventory => inventory.Name == "Red Potion");
        }
    }
}
