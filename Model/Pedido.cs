using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pedido
    {
        private int? codigo;
        private int codigoAluguel;
        private int codigoProduto;
        private string nomeProduto;
        private DateTime dataPedido;
        private double valor;
        private int qtde;
       
        public int? Codigo { get => codigo; set => codigo = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public int CodigoAluguel { get => codigoAluguel; set => codigoAluguel = value; }
        public int CodigoProduto { get => codigoProduto; set => codigoProduto = value; }
        public double Valor { get => valor; set => valor = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }

        public Pedido(int? codigo)
        {
            this.codigo = codigo;
        }

        public Pedido(int? codigo, DateTime dataPedido, int qtde, double valor, int codigoAluguel, int codigoProduto)
        {
            this.codigo = codigo;
            this.dataPedido = dataPedido;
            this.qtde = qtde;
            this.valor = valor;
            this.codigoAluguel = codigoAluguel;
            this.codigoProduto = codigoProduto;
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
                "\nfoi feito no dia: " + dataPedido;
        }

    }
}
