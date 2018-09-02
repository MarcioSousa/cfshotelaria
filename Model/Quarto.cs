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
        private DateTime dataOcupacao;
        private DateTime dataLimpexa;
        private List<Pedido> pedidos = new List<Pedido>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<Pagamento> pagamentos = new List<Pagamento>();

        public int Codigo { get => codigo; set => codigo = value; }
        public int Numero { get => numero; set => numero = value; }
        public double ValorDiaria { get => valorDiaria; set => valorDiaria = value; }
        public DateTime DataOcupacao { get => dataOcupacao; set => dataOcupacao = value; }
        public DateTime DataLimpexa { get => dataLimpexa; set => dataLimpexa = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public List<Pagamento> Pagamentos { get => pagamentos; set => pagamentos = value; }

        public Quarto(int codigo, int numero, double valorDiaria, DateTime dataOcupacao, DateTime dataLimpexa)
        {
            this.codigo = codigo;
            this.numero = numero;
            this.valorDiaria = valorDiaria;
            this.dataOcupacao = dataOcupacao;
            this.dataLimpexa = dataLimpexa;
        }

    }

}
