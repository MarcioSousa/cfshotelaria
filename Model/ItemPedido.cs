﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemPedido
    {
        private int codigo;
        private int qtde;
        private double valor;
        private Produto produto;
        private Pedido pedido;

        public int Codigo { get => codigo; set => codigo = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }
        public Produto Produto { get => produto; set => produto = value; }
        public Pedido Pedido { get => pedido; set => pedido = value; }

        public ItemPedido(int codigo, int qtde, double valor, Produto produto, Pedido pedido)
        {
            this.codigo = codigo;
            this.qtde = qtde;
            this.valor = valor;
            this.produto = produto;
            this.pedido = pedido;
        }

        public override bool Equals(object obj)
        {
            var pedido = obj as ItemPedido;
            return pedido != null &&
                   Codigo == pedido.Codigo;
        }

        public override int GetHashCode()
        {
            return 1745598366 + Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "\n=== ITEM PEDIDO ===" +
                "\nO item de pedido com o código " + codigo +
                "\nProduto: " + produto +
                "\npediu " + qtde +
                "\nquantidades do produto: " + produto +
                "\nno valor de: R$ " + valor.ToString("F2") +
                "\ncom o pedido de número: " + pedido +
                "\n\n";
        }
    }
}
