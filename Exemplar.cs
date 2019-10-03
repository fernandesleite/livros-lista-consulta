using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Exemplar
    {
        #region Atributos
        private int tombo;
        private List<Emprestimo> emprestimos = new List<Emprestimo>(); 
        #endregion

        public int Tombo
        {
            get { return tombo; }
            set { tombo = value; }
        }
        public List<Emprestimo> Emprestimos
        {
            get { return emprestimos; }
            set { emprestimos = value; }
        }
        #region Metodos
        public bool emprestar()
        {
            if (disponivel())
            {
                emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }           
            return false;
        }
        public bool devolver()
        {
            if (!disponivel())
            {
                emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }
        public bool disponivel()
        {
            if(emprestimos.Count != 0 && emprestimos.Last().DtDevolucao == DateTime.MinValue)
            {
                return false;
            }
            return true;
        }
        public int qtdeEmprestimos()
        {
            return emprestimos.Count;
        } 
        #endregion
    }
}
