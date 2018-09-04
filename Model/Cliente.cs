using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cliente
    {
        private int codigo;
        private string nome;
        private string rg;
        private string cpf;
        private string contato;
        private Quarto quarto;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Contato { get => contato; set => contato = value; }
        public Quarto Quarto { get => quarto; set => quarto = value; }

        public Cliente(int codigo, string nome, string rg, string cpf, string contato)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.rg = rg;
            this.cpf = cpf;
            this.contato = contato;
        }

        public override bool Equals(object obj)
        {
            var cliente = obj as Cliente;
            return cliente != null &&
                   Codigo == cliente.Codigo;
        }

        public override int GetHashCode()
        {
            return 1745598366 + Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "Cliente: " + nome +
                " está no quarto: " + quarto.Numero.ToString();
        }
    }
}
