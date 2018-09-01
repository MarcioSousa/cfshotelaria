using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Entrada
    {
        private int codigo;
        private DateTime dataEntrada;
        private DateTime dataVencimento;
        private int qtde;

        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public DateTime DataVencimento { get => dataVencimento; set => dataVencimento = value; }
        public int Qtde { get => qtde; set => qtde = value; }

        public Entrada(int codigo, DateTime dataEntrada, DateTime dataVencimento, int qtde)
        {
            Codigo = codigo;
            DataEntrada = dataEntrada;
            DataVencimento = dataVencimento;
            Qtde = qtde;
        }
    }
}
