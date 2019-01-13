using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pedido
    {
        private int codigo;
        private DateTime dataPedido;
        private double valor;
        private int qtde;
        private Aluguel aluguel;
        private Produto produto;
       
        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public double Valor { get => valor; set => valor = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public Aluguel Aluguel { get => aluguel; set => aluguel = value; }
        public Produto Produto { get => produto; set => produto = value; }

        public Pedido(int codigo, DateTime dataPedido, int qtde, double valor, Aluguel aluguel, Produto produto)
        {
            this.codigo = codigo;
            this.dataPedido = dataPedido;
            this.qtde = qtde;
            this.valor = valor;
            this.aluguel = aluguel;
            this.produto = produto;
        }

        public override bool Equals(object obj)
        {
            var pedido = obj as Pedido;
            return pedido != null &&
                   Codigo == pedido.Codigo;
        }

        public override int GetHashCode()
        {
            return 1745598366 + Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "\n=== PEDIDO ===" +
                "\nO pedido de número " + codigo +
                "\nfoi feito no dia: " + dataPedido +
                "\nEsse é para o aluguel: " + aluguel;
        }

    }
}
