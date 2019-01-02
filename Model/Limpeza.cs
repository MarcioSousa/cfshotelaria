using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Limpeza
    {
        private int? codigo;
        private DateTime dataLimpeza;
        private Quarto quarto;

        public int? Codigo { get => codigo; set => codigo = value; }
        public DateTime DataLimpeza { get => dataLimpeza; set => dataLimpeza = value; }
        public Quarto Quarto { get => quarto; set => quarto = value; }

        public Limpeza(int? codigo, DateTime dataLimpeza, Quarto quarto)
        {
            this.Codigo = codigo;
            this.DataLimpeza = dataLimpeza;
            this.Quarto = quarto;
        }

        public override bool Equals(object obj)
        {
            var limpeza = obj as Limpeza;
            return limpeza != null &&
                   codigo == limpeza.codigo;
        }

        public override int GetHashCode()
        {
            return -1967093634 + codigo.GetHashCode();
        }

        public override string ToString()
        {
            return "\n=== Limpeza ===" +
                "\nCodigo da limpeza foi " + codigo +
                "\nA datada limpeza foi " + dataLimpeza +
                "\n" + quarto +
                "\n\n";
        }

    }
}
