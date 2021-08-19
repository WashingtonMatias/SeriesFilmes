using System;

namespace SeriesFilmes
{
	class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
		static void Main(string[] args)
		{
			Crud crud = new Crud();
			string opcaoUsuario = crud.ObterOpcaoUsuario();
			
			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						crud.ListarSeries();
						break;
					case "2":
						crud.InserirSerie();
						break;
					case "3":
						crud.AtualizarSerie();
						break;
					case "4":
						crud.ExcluirSerie();
						break;
					case "5":
						crud.VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = crud.ObterOpcaoUsuario();
			}

			Console.WriteLine("Sempre é um prazer oferecer conteúdo de séries e filmes, volte logo!!!!!");
			Console.ReadLine();
		}

	}

}
