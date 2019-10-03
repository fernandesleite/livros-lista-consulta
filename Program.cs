using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Program
    {
        static Livros acervo = new Livros();
        static void Main(string[] args)
        {
            int opcaoEscolhida = 0;
            do
            {
                mostrarMenu();
                opcaoEscolhida = int.Parse(Console.ReadLine());
                if(opcaoEscolhida > 6)
                {
                    Console.WriteLine("Opcao invalida!");
                }
                Console.WriteLine("");
                try
                {
                    switch (opcaoEscolhida)
                    {
                        case 0:
                            break;
                        case 1:
                            adicionarLivro();
                            break;
                        case 2:
                            pesquisaSintetica();
                            break;
                        case 3:
                            pesquisaAnalitica();
                            break;
                        case 4:
                            adicionarExemplar();
                            break;
                        case 5:
                            registrarEmprestimo();
                            break;
                        case 6:
                            registrarDevolucao();
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("ERRO: {0}", e.Message);
                }           
                Console.WriteLine("");
            }
            while (opcaoEscolhida != 0);
        }
        #region Metodos
        private static void mostrarMenu()
        {
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar Livro");
            Console.WriteLine("2. Pesquisar Livro (sintético)");
            Console.WriteLine("3. Pesquisar Livro (analítico)");
            Console.WriteLine("4. Adicionar exemplar");
            Console.WriteLine("5. Registrar empréstimo");
            Console.WriteLine("6. Registrar devolução");
            Console.Write("Opção: ");
        }
        private static void adicionarLivro()
        {
            Console.Write("Digite o ISBN: ");
            int isbnNovo = int.Parse(Console.ReadLine());
            Console.Write("Digite o Titulo: ");
            string tituloNovo = Console.ReadLine();
            Console.Write("Digite o Autor: ");
            string autorNovo = Console.ReadLine();
            Console.Write("Digite o Editora: ");
            string editoraNovo = Console.ReadLine();
            List<Exemplar> exemplaresNovo = new List<Exemplar>();
            acervo.adicionar(new Livro(isbnNovo, tituloNovo, autorNovo, editoraNovo, exemplaresNovo));
        }
        private static Livro pesquisa()
        {
            Console.Write("Digite o ISBN: ");
            int isbnPesquisa = int.Parse(Console.ReadLine());
            Livro livroPesquisado = acervo.pesquisar(new Livro(isbnPesquisa));
            if(livroPesquisado == null)
            {
                Console.WriteLine("Livro nao existe no acervo");
                return null;
            }
            else
            {
                return livroPesquisado;
            }
        }
        private static Livro pesquisaSintetica()
        {
            Livro livroPesquisado = pesquisa();
            Console.WriteLine("----- {0} ----- por {1} - {2}", livroPesquisado.Titulo, livroPesquisado.Autor, livroPesquisado.Editora);
            Console.WriteLine("Total Exemplares: {0}", livroPesquisado.qtdeExemplares());
            Console.WriteLine("Total Exemplares Disponíveis: {0}", livroPesquisado.qtdeDisponiveis());
            Console.WriteLine("Total Emprestimos: {0}", livroPesquisado.qtdeEmprestimos());
            Console.WriteLine("Percentual de disponibilidade: {0}%", livroPesquisado.percDisponibilidade());
            return livroPesquisado;
        }
        private static void pesquisaAnalitica()
        {
            Livro livroPesquisado = pesquisaSintetica();
            Console.WriteLine("Emprestimos: ");
            Console.WriteLine("-----------------------------------");
            foreach (Exemplar exemplar in livroPesquisado.Exemplares)
            {
                Console.WriteLine("Exemplar n.{0}", exemplar.Tombo);
                foreach (Emprestimo emprestimo in exemplar.Emprestimos)
                {
                    Console.WriteLine("Emprestimo: {0}", emprestimo.DtEmprestimo);
                    if(emprestimo.DtDevolucao == DateTime.MinValue)
                    {
                        Console.WriteLine("Em emprestimo");
                    }
                    else
                    {
                        Console.WriteLine("Devolvido: {0}", emprestimo.DtDevolucao);
                    }
                }
            }            
        }
        private static void adicionarExemplar()
        {
            Livro livroParaExemplar = pesquisa();
            livroParaExemplar.adicionarExemplar(new Exemplar());
            Console.WriteLine("Exemplar adicionado ao livro: {0}", livroParaExemplar.Titulo);
        }
        private static void registrarEmprestimo()
        {
            Livro livroParaEmprestar = pesquisa();
                for (int i = 0; i < livroParaEmprestar.qtdeExemplares(); i++)
                {
                    if (livroParaEmprestar.Exemplares[i].emprestar())
                    {
                        Console.WriteLine("Exemplar {0}/{1} Emprestado!", i + 1, livroParaEmprestar.qtdeExemplares());
                        break;
                    }
                }
        }
        private static void registrarDevolucao()
        {
            Livro livroParaDevolver = pesquisa();
            for (int i = 0; i < livroParaDevolver.qtdeExemplares(); i++)
            {
                if (livroParaDevolver.Exemplares[i].devolver())
                {
                    Console.WriteLine("Exemplar Devolvido!, Disponíveis: {0}", livroParaDevolver.qtdeExemplares());
                    break;
                }
            }
        } 
        #endregion
    }
}
