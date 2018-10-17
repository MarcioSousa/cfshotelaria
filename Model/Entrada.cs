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
        private Produto produto;

        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public DateTime DataVencimento { get => dataVencimento; set => dataVencimento = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public Produto Produto { get => produto; set => produto = value; }

        public Entrada(int codigo, DateTime dataEntrada, DateTime dataVencimento, int qtde, Produto produto)
        {
            this.codigo = codigo;
            this.dataEntrada = dataEntrada;
            this.dataVencimento = dataVencimento;
            this.qtde = qtde;
            this.produto = produto;
        }

        public override bool Equals(object obj)
        {
            var entrada = obj as Entrada;
            return entrada != null &&
                   Codigo == entrada.Codigo;
        }

        public override int GetHashCode()
        {
            return 1745598366 + Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "\n=== ENTRADA ===" +
                "\nA entrada de código: " + codigo +
                "\nProduto: " + produto.Nome +
                "\nA entrada do produto foi em: " + dataEntrada +
                "\nA data de vencimento é de: " + dataVencimento +
                "\nA quantidade que foi estocado é de: " + qtde +
                "\n" + produto;
        }
    }

}
