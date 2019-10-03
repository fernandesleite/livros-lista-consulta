using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Livro
    {
        #region Atributos
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;
        #endregion

        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public string Editora
        {
            get { return editora; }
            set { editora = value; }
        }
        public List<Exemplar> Exemplares
        {
            get { return exemplares; }
            set { exemplares = value; }
        }

        #region Construtores
        public Livro(int isbn, string titulo, string autor, string editora, List<Exemplar> exemplares)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = exemplares;
        }
        public Livro(int isbn)
        {
            this.isbn = isbn;
        }
        #endregion

        #region Metodos
        public void adicionarExemplar(Exemplar exemplar)
        {
            exemplar.Tombo = exemplares.Count + 1;
            exemplares.Add(exemplar);
        }
        public int qtdeExemplares()
        {
            return exemplares.Count;
        }
        public int qtdeDisponiveis()
        {
            int qtdDisponiveis = 0;
            foreach(Exemplar exemplar in exemplares)
            {
                if (exemplar.disponivel())
                {
                    qtdDisponiveis++;
                }
            }
            return qtdDisponiveis;
        }
        public int qtdeEmprestimos()
        {
            int qtdeEmprestimosTotal = 0;
            foreach(Exemplar exemplar in exemplares)
            {
                qtdeEmprestimosTotal += exemplar.qtdeEmprestimos();
            }
            return qtdeEmprestimosTotal;
        }
        public double percDisponibilidade()
        {
            return (qtdeDisponiveis()/(double)qtdeExemplares()) * 100;
        } 
        #endregion
    }
}
