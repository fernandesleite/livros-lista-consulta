using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Emprestimo
    {
        #region Atributos
        private DateTime dtEmprestimo = DateTime.MinValue;
        private DateTime dtDevolucao = DateTime.MinValue;
        #endregion
        public Emprestimo(DateTime dtEmprestimo)
        {
            this.dtEmprestimo = dtEmprestimo;
        }
        #region Propriedades
        public DateTime DtEmprestimo
        {
            get { return dtEmprestimo; }
            set { dtEmprestimo = value; }
        }
        public DateTime DtDevolucao
        {
            get { return dtDevolucao; }
            set { dtDevolucao = value; }
        }
        #endregion
    }
}
