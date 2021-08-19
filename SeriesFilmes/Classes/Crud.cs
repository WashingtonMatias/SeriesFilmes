using System;


namespace SeriesFilmes
{
    public class Crud
    {
		static SerieRepositorio repositorio = new SerieRepositorio();
		public void ExcluirSerie()
		{
			Console.Write("Digite o id da série ou filme: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

		public void VisualizarSerie()
		{
			Console.Write("Digite o id da série ou filme: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		public void AtualizarSerie()
		{
			Console.Write("Digite o id da série ou filme: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série ou filme: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			Console.Clear();
			Console.WriteLine(Environment.NewLine + "****Série cadastrada com sucesso!!!****" + Environment.NewLine);
			Console.WriteLine("Titulo {0} - Genero {1} - Ano {2}", entradaTitulo, (Genero)entradaGenero, entradaAno + Environment.NewLine);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
		public void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.Clear();
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();
				Console.Clear();
				Console.WriteLine("****Lista de séries/filme cadastrada****" + Environment.NewLine);
				
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		public void InserirSerie()
		{
			Console.WriteLine("Inserir nova série ou filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série ou filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série ou filme: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			Console.Clear();
			Console.WriteLine(Environment.NewLine + "****Série/filme cadastrada com sucesso!!!****" + Environment.NewLine);
			Console.WriteLine("Titulo {0} - Genero {1} - Ano {2}", entradaTitulo, (Genero)entradaGenero, entradaAno + Environment.NewLine);
			repositorio.Insere(novaSerie);
		}

		public string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("******Séries incriveis so enconta aqui!!!!!******" + Environment.NewLine);
			Console.WriteLine("Informe a opção desejada:" + Environment.NewLine);

			Console.WriteLine("1- Listar séries ou filme");
			Console.WriteLine("2- Inserir nova série ou filme");
			Console.WriteLine("3- Atualizar série ou filme");
			Console.WriteLine("4- Excluir série ou filme");
			Console.WriteLine("5- Visualizar série ou filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

	}
}
