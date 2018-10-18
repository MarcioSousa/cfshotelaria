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
        private List<ItemPedido> itemPedidos = new List<ItemPedido>();
        private Aluguel aluguel;

        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public List<ItemPedido> ItemPedidos { get => itemPedidos; set => itemPedidos = value; }
        public Aluguel Aluguel { get => aluguel; set => aluguel = value; }

        public Pedido(int codigo, DateTime dataPedido, Aluguel aluguel)
        {
            this.codigo = codigo;
            this.dataPedido = dataPedido;
            this.aluguel = aluguel;
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
