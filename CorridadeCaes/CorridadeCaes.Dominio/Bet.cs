using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridadeCaes.Dominio
{
    public class Bet
    {
        public int montante;
        public int cachorro;
        public Guy apostador;


        public string PegaDescricao()
        {
            if (apostador != null)
            {
                string descricao = apostador.nome + " aposta R$" + montante + " no cachorro numero : " + cachorro;
                return descricao;
            }
            else
            {
                string descricao = apostador.nome + " ainda nao apostou";
                return descricao;
            }
        }

        public int Pagamento(int cachorroVencedor)
        {
            if (cachorroVencedor == cachorro)
            {
                return (montante + montante);
            }
            else
            {
                return -montante;
            }
        }
    }
}
