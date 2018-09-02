using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pagamento
    {
        private int codigo;
        private string tipo;
        private DateTime dataPagamento;
        private double valor;
        private Quarto quarto;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public DateTime DataPagamento { get => dataPagamento; set => dataPagamento = value; }
        public double Valor { get => valor; set => valor = value; }
        public Quarto Quarto { get => quarto; set => quarto = value; }

        public Pagamento(int codigo, string tipo, DateTime dataPagamento, double valor, Quarto quarto)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.dataPagamento = dataPagamento;
            this.valor = valor;
            this.quarto = quarto;
        }
    }
}
