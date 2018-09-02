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
        private Quarto quarto;

        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public List<ItemPedido> ItemPedidos { get => itemPedidos; set => itemPedidos = value; }
        public Quarto Quarto { get => quarto; set => quarto = value; }

        public Pedido(int codigo, DateTime dataPedido, List<ItemPedido> itemPedidos, Quarto quarto)
        {
            this.codigo = codigo;
            this.dataPedido = dataPedido;
            this.itemPedidos = itemPedidos;
            this.quarto = quarto;
        }

    }
}
