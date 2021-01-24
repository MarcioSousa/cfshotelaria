using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pagamento
    {
        private int? codigo;
        private int codigoAluguel;
        private string tipo;
        private DateTime dataPagamento;
        private double valor;

        public int? Codigo { get { return codigo; } set { codigo = value; } }
        public int CodigoAluguel { get { return codigoAluguel; } set { codigoAluguel = value; } }
        public string Tipo { get { return tipo; } set { tipo = value; } }
        public DateTime DataPagamento { get { return dataPagamento; } set { dataPagamento = value; } }
        public double Valor { get { return valor; } set { valor = value; } }

        public Pagamento(int? codigo)
        {
            this.codigo = codigo;
        }

        public Pagamento(int? codigo, string tipo, DateTime dataPagamento, double valor, int codigoAluguel)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.dataPagamento = dataPagamento;
            this.valor = valor;
            this.codigoAluguel = codigoAluguel;
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