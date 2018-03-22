using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorridadeCaes.Dominio
{
    public class Guy
    {
        public string nome;
        public Bet minhaBet = new Bet();
        public int dinheiro;
        public RadioButton meuRadioButton;
        public Label meuLabel;

        public void AtualizarLabels()
        {
            meuRadioButton = new RadioButton();
            meuLabel = new Label();

            meuRadioButton.Text = nome + "tem" + dinheiro;
            meuLabel.Text = minhaBet.PegaDescricao();
        }

        public void LimparBet()
        {
            minhaBet.montante = 0;
        }

        public bool ColocaBet(int _valorAposta, int _cachorro)
        {
            if (dinheiro >= _valorAposta)
            {
                minhaBet.apostador = this;
                minhaBet.montante = _valorAposta;
                minhaBet.cachorro = _cachorro;
                return true;
            }
            return false;
        }

        public void Recolhe(int _cachorroVencedor)
        {
            dinheiro += minhaBet.Pagamento(_cachorroVencedor);
            LimparBet();
        }
    }
}
