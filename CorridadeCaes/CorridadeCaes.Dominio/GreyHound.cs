using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorridadeCaes.Dominio
{
    public class GreyHound
    {
        public int numero;
        public int posicaoInicial;
        public int comprimentoCorrida;
        public PictureBox minhaCaixaFoto;
        public int localizacao;

        public bool Correr(Random minhaRandom)
        {
            localizacao = Randomico(minhaRandom);
            Point ponto = minhaCaixaFoto.Location;
            ponto.X += localizacao;
            minhaCaixaFoto.Location = ponto;
            if (minhaCaixaFoto.Location.X >= 542)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Randomico(Random minhaRandon)
        {
            return minhaRandon.Next(5);
        }

        public void PegaPosicaoInicial()
        {
            Point ponto = minhaCaixaFoto.Location;
            ponto.X = 22;
            minhaCaixaFoto.Location = ponto;
        }

    }
}
