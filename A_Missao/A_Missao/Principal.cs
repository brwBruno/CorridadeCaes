using A_Missao.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Missao
{
    public partial class Principal : Form
    {
        private Jogo _game;
        private Random random = new Random();
        private bool equiped = false;

        public Principal()
        {
            InitializeComponent();

            _game = new Jogo(new Rectangle(78, 57, 420, 155));
            _game.NewLevel(random);

            UpdateCharacters();
        }

        private void UpdateCharacters()
        {
            pcbPlayer.Location = _game.Localizacaojogador;
            lblPlayerHitPoint.Text = _game.PontosdeVida.ToString();

            int enemiesShown = 0;
            foreach (Inimigo enemy in _game.inimigos)
            {
                if (enemy is Morcego)
                {
                    pcbBat.Location = enemy.Localizacao;
                    lblBatHitPoint.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        pcbBat.Visible = true;
                        lblBatHitPoint.Visible = true;
                        enemiesShown++;
                    }
                    else
                    {
                        pcbBat.Visible = false;
                        lblBatHitPoint.Visible = false;
                    }
                }
                else if (enemy is Fantasma)
                {
                    pcbGhost.Location = enemy.Localizacao;
                    lblGhostHitPoint.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        pcbGhost.Visible = true;
                        lblGhostHitPoint.Visible = true;
                        enemiesShown++;
                    }
                    else
                    {
                        pcbGhost.Visible = false;
                        lblGhostHitPoint.Visible = false;
                    }
                }
                else
                {
                    pcbZumbi.Location = enemy.Localizacao;
                    lblZumbiHitPoint.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        pcbZumbi.Visible = true;
                        lblZumbiHitPoint.Visible = true;
                        enemiesShown++;
                    }
                    else
                    {
                        pcbZumbi.Visible = false;
                        lblZumbiHitPoint.Visible = false;
                    }
                }
            }

            pcbSword.Visible = false;
            pcbBow.Visible = false;
            pcbRedPotion.Visible = false;
            pcbBluePotion.Visible = false;
            pcbMace.Visible = false;

            Control weaponControl = null;
            switch (_game.armanasala.Name)
            {
                case "Bow":
                    weaponControl = pcbBow;
                    break;

                case "Sword":
                    weaponControl = pcbSword;
                    break;

                case "Mace":
                    weaponControl = pcbMace;
                    break;

                case "Blue Potion":
                    weaponControl = pcbBluePotion;
                    break;

                case "Red Potion":
                    weaponControl = pcbRedPotion;
                    break;
            }
            weaponControl.Visible = true;

            weaponControl.Location = _game.armanasala.Localizacao;
            if (_game.armanasala.Pegou)
            {
                if (_game.armanasala.Name == "Sword")
                {
                    weaponControl.Visible = false;
                    pcbInvSword.Visible = true;
                }
                else if (_game.armanasala.Name == "Blue Potion")
                {
                    weaponControl.Visible = false;
                    if (_game.CheckPlayerINventory("Blue Potion"))
                        pcbInvBluePotion.Visible = true;
                    else
                        pcbInvBluePotion.Visible = false;
                }
                else if (_game.armanasala.Name == "Bow")
                {
                    weaponControl.Visible = false;
                    pcbInvBow.Visible = true;
                }
                else if (_game.armanasala.Name == "Red Potion")
                {
                    weaponControl.Visible = false;
                    if (_game.CheckPlayerINventory("Red Potion"))
                        pcbInvRedPotion.Visible = true;
                    else
                        pcbInvRedPotion.Visible = false;
                }
                else
                {
                    weaponControl.Visible = false;
                    pcbInvMace.Visible = true;
                }
            }
            else
                weaponControl.Visible = true;
            
            if (_game.PontosdeVida <= 0)
            {
                MessageBox.Show("Voce Morreu!");
                Application.Exit();
            }
            
            if (enemiesShown < 1)
            {
                MessageBox.Show("Voce derrotou todos os inimigos desse nivel!");
                _game.NewLevel(random);
                UpdateCharacters();
            }
        }
        
        private void DefineBorderStyle(string weaponName)
        {
            if (_game.CheckPlayerINventory("Bow") && weaponName == "Bow")
            {
                pcbInvBow.BorderStyle = BorderStyle.FixedSingle;
                pcbInvSword.BorderStyle = BorderStyle.None;
                pcbInvBluePotion.BorderStyle = BorderStyle.None;
                pcbInvRedPotion.BorderStyle = BorderStyle.None;
                pcbInvMace.BorderStyle = BorderStyle.None;
            }
            else if (_game.CheckPlayerINventory("Blue Potion") && weaponName == "Blue Potion")
            {
                pcbInvBow.BorderStyle = BorderStyle.None;
                pcbInvSword.BorderStyle = BorderStyle.None;
                pcbInvMace.BorderStyle = BorderStyle.None;
                pcbInvBluePotion.BorderStyle = BorderStyle.FixedSingle;
                pcbInvRedPotion.BorderStyle = BorderStyle.None;
            }
            else if (_game.CheckPlayerINventory("Sword") && weaponName == "Sword")
            {
                pcbInvBow.BorderStyle = BorderStyle.None;
                pcbInvSword.BorderStyle = BorderStyle.FixedSingle;
                pcbInvMace.BorderStyle = BorderStyle.None;
                pcbInvBluePotion.BorderStyle = BorderStyle.None;
                pcbInvRedPotion.BorderStyle = BorderStyle.None;
            }
            else if (_game.CheckPlayerINventory("Mace") && weaponName == "Mace")
            {
                pcbInvBow.BorderStyle = BorderStyle.None;
                pcbInvSword.BorderStyle = BorderStyle.None;
                pcbInvMace.BorderStyle = BorderStyle.FixedSingle;
                pcbInvBluePotion.BorderStyle = BorderStyle.None;
                pcbInvRedPotion.BorderStyle = BorderStyle.None;
            }
            else
            {
                pcbInvBow.BorderStyle = BorderStyle.None;
                pcbInvSword.BorderStyle = BorderStyle.None;
                pcbInvMace.BorderStyle = BorderStyle.None;
                pcbInvBluePotion.BorderStyle = BorderStyle.None;
                pcbInvRedPotion.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            _game.Move(Direcao.Up, random);
            UpdateCharacters();
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            _game.Move(Direcao.Right, random);
            UpdateCharacters();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            _game.Move(Direcao.Down, random);
            UpdateCharacters();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            _game.Move(Direcao.Left, random);
            UpdateCharacters();
        }

        private void btnAttackUp_Click(object sender, EventArgs e)
        {
            if (equiped)
            {
                _game.Attack(Direcao.Up, random);
                UpdateCharacters();
            }
        }

        private void btnAttackRight_Click(object sender, EventArgs e)
        {
            if (equiped)
            {
                _game.Attack(Direcao.Right, random);
                UpdateCharacters();
            }
        }

        private void btnAttackDown_Click(object sender, EventArgs e)
        {
            if (equiped)
            {
                _game.Attack(Direcao.Down, random);
                UpdateCharacters();
            }
        }

        private void btnAttackLeft_Click(object sender, EventArgs e)
        {
            if (equiped)
            {
                _game.Attack(Direcao.Left, random);
                UpdateCharacters();
            }
        }

        private void pcbInventory1_Click(object sender, EventArgs e)
        {
            _game.Equip("Sword");
            DefineBorderStyle("Sword");
            UpdateCharacters();
            equiped = true;
        }

        private void pcbInvBluePotion_Click(object sender, EventArgs e)
        {
            _game.Equip("Blue Potion");
            DefineBorderStyle("Blue Potion");
            UpdateCharacters();
            equiped = true;
        }

        private void pcbInvBow_Click(object sender, EventArgs e)
        {
            _game.Equip("Bow");
            DefineBorderStyle("Bow");
            UpdateCharacters();
            equiped = true;
        }

        private void pcbInvRedPotion_Click(object sender, EventArgs e)
        {
            _game.Equip("Red Potion");
            DefineBorderStyle("Red Potion");
            UpdateCharacters();
            equiped = true;
        }

        private void pcbInvMace_Click(object sender, EventArgs e)
        {
            _game.Equip("Mace");
            DefineBorderStyle("Mace");
            UpdateCharacters();
            equiped = true;
        }
    }
}
