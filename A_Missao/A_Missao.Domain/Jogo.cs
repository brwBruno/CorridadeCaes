using A_Missao.Domain.Weapons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Missao.Domain
{
    public class Jogo
    {
        public List<Inimigo> inimigos;
        public Arma armanasala;

        private Jogador jogador;
        public Point Localizacaojogador { get { return jogador.Localizacao; } }
        public int PontosdeVida { get { return jogador.PontosdeVida; } }
        public List<string> ArmasJoagador { get { return jogador.Armas; } }

        private int nivel = 0;
        public int Nivel { get { return nivel; } }

        private Rectangle limites;
        public Rectangle Limites { get { return limites; } }

        public Jogo(Rectangle boundaries)
        {
            this.limites = boundaries;
            jogador = new Jogador(this, new Point(boundaries.Left + 10, boundaries.Top + 70));
        }
        
        public void Move(Direcao direction, Random random)
        {
            IPoc potion;

            jogador.Move(direction);
            if (jogador.NearBy(armanasala.Localizacao, 12))
            {
                if (armanasala is IPoc)
                {
                    potion = armanasala as IPoc;
                    if (!potion.Used)
                    {
                        armanasala.PickedUpWeapon();
                        jogador.inventario.Add(armanasala);
                    }
                }
                else
                {
                    armanasala.PickedUpWeapon();
                    jogador.inventario.Add(armanasala);
                }
            }

            foreach (Inimigo enemy in inimigos)
            {
                if (enemy.HitPoints > 0)
                    enemy.Move(random);

                if (enemy.NearPlayer() && enemy.HitPoints > 0)
                    HitPlayer(enemy.PowerDamage, random);
            }
        }

        public void Equip(string weaponName)
        {
            jogador.Equip(weaponName);
        }

        public bool CheckPlayerINventory(string weaponName)
        {
            return jogador.Armas.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            jogador.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            jogador.IncreaseHealth(health, random);
        }

        public void Attack(Direcao direction, Random random)
        {
            jogador.Attack(direction, random);
            foreach (Inimigo enemy in inimigos)
                enemy.Move(random);
        }

        private Point GetRandomLocation(Random random)
        {
            return new Point(limites.Left + random.Next(limites.Right / 10 - limites.Left / 10) * 10,
                limites.Top + random.Next(limites.Bottom / 10 - limites.Top / 10) * 10);
        }

        public void NewLevel(Random random)
        {
            nivel++;
            switch (nivel)
            {
                case 1:
                    inimigos = new List<Inimigo>();
                    inimigos.Add(new Morcego(this, GetRandomLocation(random)));
                    armanasala = new Sword(this, GetRandomLocation(random));
                    break;

                case 2:
                    inimigos = new List<Inimigo>();
                    inimigos.Add(new Fantasma(this, GetRandomLocation(random)));
                    armanasala = new BluePotion(this, GetRandomLocation(random));
                    break;

                case 3:
                    inimigos = new List<Inimigo>();
                    inimigos.Add(new Zumbi(this, GetRandomLocation(random)));
                    armanasala = new Bow(this, GetRandomLocation(random));
                    break;

                case 4:
                    inimigos = new List<Inimigo>();
                    inimigos.Add(new Morcego(this, GetRandomLocation(random)));
                    inimigos.Add(new Fantasma(this, GetRandomLocation(random)));
                    if (!armanasala.Pegou)
                        armanasala = new Bow(this, GetRandomLocation(random));
                    else
                    {
                        if (!(armanasala is BluePotion))
                            armanasala = new BluePotion(this, GetRandomLocation(random));
                    }
                    break;

                case 5:
                    inimigos = new List<Inimigo>();
                    inimigos.Add(new Morcego(this, GetRandomLocation(random)));
                    inimigos.Add(new Zumbi(this, GetRandomLocation(random)));
                    armanasala = new RedPotion(this, GetRandomLocation(random));
                    break;

                case 6:
                    inimigos = new List<Inimigo>();
                    inimigos.Add(new Morcego(this, GetRandomLocation(random)));
                    inimigos.Add(new Fantasma(this, GetRandomLocation(random)));
                    armanasala = new Mace(this, GetRandomLocation(random));
                    break;

                case 7:
                    inimigos = new List<Inimigo>();
                    inimigos.Add(new Morcego(this, GetRandomLocation(random)));
                    inimigos.Add(new Fantasma(this, GetRandomLocation(random)));
                    inimigos.Add(new Zumbi(this, GetRandomLocation(random)));
                    if (!armanasala.Pegou)
                        armanasala = new Mace(this, GetRandomLocation(random));
                    else
                    {
                        if (!(armanasala is RedPotion))
                            armanasala = new RedPotion(this, GetRandomLocation(random));
                    }
                    break;

                case 8:
                    //Application.Exit();
                    break;
            }
        }
    }
}
