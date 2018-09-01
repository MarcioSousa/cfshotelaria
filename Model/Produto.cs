using System;
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
        List<Entrada> entradas = new List<Entrada>();

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public double Valor { get => valor; set => valor = value; }
        public int Qtdeatual { get => qtdeatual; set => qtdeatual = value; }
        public List<Entrada> Entradas { get => entradas; set => entradas = value; }

        public Produto(int codigo, string nome, double valor, int qtdeatual)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.valor = valor;
            this.qtdeatual = qtdeatual;
        }
    }
}
