﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Produto
    {
        private int codigo;
        private string nome;
        private double valor;
        private int qtdeatual;
        private List<Entrada> entradas = new List<Entrada>();
        private List<ItemPedido> itemPedidos = new List<ItemPedido>();

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public double Valor { get => valor; set => valor = value; }
        public int Qtdeatual { get => qtdeatual; set => qtdeatual = value; }
        public List<Entrada> Entradas { get => entradas; set => entradas = value; }
        public List<ItemPedido> ItemPedidos { get => itemPedidos; set => itemPedidos = value; }

        public Produto(int codigo, string nome, double valor, int qtdeatual)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.valor = valor;
            this.qtdeatual = qtdeatual;
        }

        public override bool Equals(object obj)
        {
            var produto = obj as Produto;
            return produto != null &&
                   Codigo == produto.Codigo;
        }

        public override int GetHashCode()
        {
            return 1745598366 + Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return " O codigo do produto é: " + codigo +
                "\nO nome do produto é: " + nome +
                "\nO valor do produto é: R$ " + valor +
                "\nA quantidade atual do produto é: " + qtdeatual.ToString();
        }
    }
}
