using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Aluguel
    {
        private int codigo;
        private double valor;
        private DateTime dataChegada;
        private DateTime? dataSaida;
        private List<Cliente> clientes = new List<Cliente>();
        private List<Pedido> pedidos = new List<Pedido>();
        private List<Pagamento> pagamentos = new List<Pagamento>();
        private Quarto quarto;

        public int Codigo { get => codigo; set => codigo = value; }
        public double Valor { get => valor; set => valor = value; }
        public DateTime DataChegada { get => dataChegada; set => dataChegada = value; }
        public DateTime? DataSaida { get => dataSaida; set => dataSaida = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
        public List<Pagamento> Pagamentos { get => pagamentos; set => pagamentos = value; }
        public Quarto Quarto { get => quarto; set => quarto = value; }

        public Aluguel(int codigo, double valor, DateTime dataChegada, Quarto quarto)
        {
            this.codigo = codigo;
            this.Valor = valor;
            this.DataChegada = dataChegada;
            this.quarto = quarto;
        }

        public Aluguel()
        {
        }

        public override bool Equals(object obj)
        {
            var aluguel = obj as Aluguel;
            return aluguel != null &&
                   codigo == aluguel.codigo;
        }

        public override int GetHashCode()
        {
            return -1967093634 + codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "\nO codigo do aluguel: " + codigo +
                "\n com o valor de: " + valor +
                "\n A data de chegada: " + dataChegada +
                "\n A data de saída: " + DataSaida +
                "\n" + quarto;
        }
    }
}