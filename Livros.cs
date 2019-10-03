using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Livros
    {
        private List<Livro> acervo = new List<Livro>();
        public void adicionar(Livro livro)
        {
            acervo.Add(livro);
        }
        public Livro pesquisar(Livro livro)
        {
            foreach(Livro livroAdicionado in acervo)
            {
                if(livroAdicionado.Isbn == livro.Isbn)
                {
                    return livroAdicionado;
                }
            }
            return null;
        }
    }
}
