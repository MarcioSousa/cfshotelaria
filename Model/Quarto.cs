using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Quarto
    {
        private int codigo;
        private int numero;
        private double valorDiaria;
        private Nullable<DateTime> dataOcupacao;
        private Nullable<DateTime> dataLimpexa;
        private List<Pedido> pedidos = new List<Pedido>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<Pagamento> pagamentos = new List<Pagamento>();

        public int Codigo { get => codigo; set => codigo = value; }
        public int Numero { get => numero; set => numero = value; }
        public double ValorDiaria { get => valorDiaria; set => valorDiaria = value; }
        public Nullable<DateTime> DataOcupacao { get => dataOcupacao; set => dataOcupacao = value; }
        public Nullable<DateTime> DataLimpexa { get => dataLimpexa; set => dataLimpexa = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public List<Pagamento> Pagamentos { get => pagamentos; set => pagamentos = value; }

        public Quarto(int codigo, int numero, double valorDiaria)
        {
            this.codigo = codigo;
            this.numero = numero;
            this.valorDiaria = valorDiaria;
        }

        public override bool Equals(object obj)
        {
            var quarto = obj as Quarto;
            return quarto != null &&
                   Codigo == quarto.Codigo;
        }

        public override int GetHashCode()
        {
            return 1745598366 + Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "O quarto " + codigo +
                " tem " + clientes.Count.ToString() + " clientes " +
                " e recebeu " + pagamentos.Count.ToString() + " pagamentos.";
        }
    }

}
