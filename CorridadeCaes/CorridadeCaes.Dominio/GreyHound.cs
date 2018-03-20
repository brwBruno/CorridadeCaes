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
        public int posicaoInicial;
        public int comprimentoCorrida;
        public PictureBox minhaCaixaFoto = null;
        public int localizacao = 0;
        public Random minhaRandon;

        public bool Correr()
        {
            minhaRandon = new Random();
            localizacao = minhaRandon.Next(1, 4);
            Point ponto = minhaCaixaFoto.Location;
            ponto.X = localizacao;
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

        public void PegaPosicaoInicial()
        {
            Point ponto = minhaCaixaFoto.Location;
            ponto.X = 22;
            minhaCaixaFoto.Location = ponto;
        }

    }
}
