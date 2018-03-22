using CorridadeCaes.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorridadeCaes
{
    public partial class Principal : Form
    {
        Random minhaRandon = new Random();
        GreyHound[] cao = new GreyHound[4];
        Guy[] cara = new Guy[3];

        public Principal()
        {
            InitializeComponent();
            InstaciaCara();
            IniciaText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InstaciaCara()
        {
            cara[0] = new Guy() { nome = "João", dinheiro = 50 };
            cara[1] = new Guy() { nome = "Beto", dinheiro = 50 };
            cara[2] = new Guy() { nome = "Alfredo", dinheiro = 50 };
        }

        private void InstanciaDog()
        {
            cao[0] = new GreyHound();
            cao[0].numero = 1;
            cao[0].posicaoInicial = ptbCachorro1.Location.X;
            cao[0].minhaCaixaFoto = ptbCachorro1;
            cao[0].comprimentoCorrida = ptbPista.Width;

            cao[1] = new GreyHound();
            cao[1].numero = 2;
            cao[1].posicaoInicial = ptbCachorro2.Location.X;
            cao[1].minhaCaixaFoto = ptbCachorro2;
            cao[1].comprimentoCorrida = ptbPista.Width;

            cao[2] = new GreyHound();
            cao[2].numero = 3;
            cao[2].posicaoInicial = ptbCachorro3.Location.X;
            cao[2].minhaCaixaFoto = ptbCachorro3;
            cao[2].comprimentoCorrida = ptbPista.Width;

            cao[3] = new GreyHound();
            cao[3].numero = 4;
            cao[3].posicaoInicial = ptbCachorro4.Location.X;
            cao[3].minhaCaixaFoto = ptbCachorro4;
            cao[3].comprimentoCorrida = ptbPista.Width;
        }

        private void IniciaText()
        {
            numAposta.Value = 5;
            numCao.Value = 1;
            lblValorMinimo.Text = "Aposta minima R$ 5";

            rbtGuy1.Text = cara[0].nome + " tem R$ " + cara[0].dinheiro;
            rbtGuy2.Text = cara[1].nome + " tem R$ " + cara[1].dinheiro;
            rbtGuy3.Text = cara[2].nome + " tem R$ " + cara[2].dinheiro;

            txtGuy1.Text = cara[0].nome + " ainda nao apostou";
            txtGuy2.Text = cara[1].nome + " ainda nao apostou";
            txtGuy3.Text = cara[2].nome + " ainda nao apostou";
        }

        private void Apostas()
        {
            if (rbtGuy1.Checked == true)
            {
                if (cara[0].ColocaBet(Convert.ToInt32(numAposta.Value), Convert.ToInt32(numCao.Value)))
                {
                    cara[0].AtualizarLabels();
                    txtGuy1.Text = cara[0].meuLabel.Text;
                }
                else
                {
                    MessageBox.Show("O apostador " + cara[0].nome + " nao tem dinheiro suficiente.", "Erro", MessageBoxButtons.OK);
                }
            }
            else if (rbtGuy2.Checked == true)
            {
                if (cara[1].ColocaBet(Convert.ToInt32(numAposta.Value), Convert.ToInt32(numCao.Value)))
                {
                    cara[1].AtualizarLabels();
                    txtGuy2.Text = cara[1].meuLabel.Text;
                }
                else
                {
                    MessageBox.Show("O apostador " + cara[1].nome + " nao tem dinheiro suficiente.", "Erro", MessageBoxButtons.OK);
                }
            }
            else if (rbtGuy3.Checked == true)
            {
                if (cara[2].ColocaBet(Convert.ToInt32(numAposta.Value), Convert.ToInt32(numCao.Value)))
                {
                    cara[2].AtualizarLabels();
                    txtGuy3.Text = cara[2].meuLabel.Text;
                }
                else
                {
                    MessageBox.Show("O apostador " + cara[2].nome + " nao tem dinheiro suficiente.", "Erro", MessageBoxButtons.OK);
                }
            }
        }

        private void DesabilitarRad()
        {
            rbtGuy1.Enabled = false;
            rbtGuy2.Enabled = false;
            rbtGuy3.Enabled = false;
        }

        private void HabilitarRad()
        {
            rbtGuy1.Enabled = true;
            rbtGuy2.Enabled = true;
            rbtGuy3.Enabled = true;
        }

        private void ControleBotaoA()
        {
            btnCorrida.Enabled = true;
            btnApostar.Enabled = false;
        }

        private void ControleBotaoB()
        {
            btnApostar.Enabled = true;
            btnCorrida.Enabled = false;
        }

        private void Recomecar()
        {
            for (int i = 0; i < 3; i++)
            {
                cara[i].AtualizarLabels();
            }

            rbtGuy1.Text = cara[0].meuRadioButton.Text;
            rbtGuy2.Text = cara[1].meuRadioButton.Text;
            rbtGuy2.Text = cara[2].meuRadioButton.Text;

            for (int i = 0; i < 4; i++)
            {
                cao[i].PegaPosicaoInicial();
            }
            ControleBotaoB();
            HabilitarRad();
        }

        private int Checado()
        {
            if (rbtGuy1.Checked == true)
            {
                return 1;
            }
            else if (rbtGuy2.Checked == true)
            {
                return 2;
            }
            else if (rbtGuy3.Checked == true)
            {
                rbtGuy1.Checked = true;
                return 3;
            }
            else
            {
                return 0;
            }
        }

        private void btnApostar_Click(object sender, EventArgs e)
        {
            Apostas();
            if (Checado() >= 3)
            {
                ControleBotaoA();
                DesabilitarRad();
            }
        }

        private void btnCorrida_Click(object sender, EventArgs e)
        {
            InstanciaDog();
            timer1.Enabled = true;
            timer1.Start();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void rbtGuy1_CheckedChanged(object sender, EventArgs e)
        {
            lblApostador.Text = cara[0].nome;
        }

        private void rbtGuy2_CheckedChanged(object sender, EventArgs e)
        {
            lblApostador.Text = cara[1].nome;
        }

        private void rbtGuy3_CheckedChanged(object sender, EventArgs e)
        {
            lblApostador.Text = cara[2].nome;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (cao[i].Correr(minhaRandon))
                {
                    timer1.Stop();
                    for (int j = 0; j < 3; j++)
                    {
                        cara[j].Recolhe(cao[i].numero);
                    }
                    MessageBox.Show("O cachorro vencedor foi o numero: " + cao[i].numero, "Vencedor", MessageBoxButtons.OK);
                    Recomecar();
                    IniciaText();
                    return;
                }
            }
        }
    }
}
