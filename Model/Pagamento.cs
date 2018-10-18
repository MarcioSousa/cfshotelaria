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
        private Aluguel aluguel;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public DateTime DataPagamento { get => dataPagamento; set => dataPagamento = value; }
        public double Valor { get => valor; set => valor = value; }
        public Aluguel Aluguel { get => aluguel; set => aluguel = value; }

        public Pagamento(int codigo, string tipo, DateTime dataPagamento, double valor, Aluguel aluguel)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.dataPagamento = dataPagamento;
            this.valor = valor;
            this.aluguel = aluguel;
        }

        public override bool Equals(object obj)
        {
            var pagamento = obj as Pagamento;
            return pagamento != null &&
                   Codigo == pagamento.Codigo;
        }

        public override int GetHashCode()
        {
            return 1745598366 + Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "\n=== PAGAMENTO ===" +
                "\nO pagamendo no valor de " + valor +
                "\nO tipo de pagamento: " + tipo +
                "\nCom a data: " + dataPagamento +
                "\nCom o código do pagamento: " + codigo +
                "\n";
        }
    }
}
