using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Quarto
    {
        private int numero;
        private double valorDiaria;
        private string localidade;

        public int Numero { get => numero; set => numero = value; }
        public double ValorDiaria { get => valorDiaria; set => valorDiaria = value; }
        public string Localidade { get => localidade; set => localidade = value; }

        public Quarto(int numero)
        {
            this.Numero = numero;
        }

        public Quarto(int numero, double valorDiaria, string localidade)
        {
            this.numero = numero;
            this.valorDiaria = valorDiaria;
            this.Localidade = localidade;
        }

        public override bool Equals(object obj)
        {
            var quarto = obj as Quarto;
            return quarto != null &&
                   numero == quarto.numero;
        }

        public override int GetHashCode()
        {
            return -456087787 + numero.GetHashCode();
        }

        public override string ToString()
        {
            return numero.ToString();
        }

        //public override string ToString()
        //{
        //    return "\n=== QUARTO ===" +
        //        "\nO número do quarto é: " + numero +
        //        "\nO valor da diária desse quarto é: " + valorDiaria +
        //        "\nA localidade do Quarto: " + Localidade;
        //}
    }
}