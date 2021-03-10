/*
  TODO
    Desafio, fazer a parte do filme
*/

using System;
using DIO.Series.Classes;
using DIO.Series.Enums;

namespace DIO.Series
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListaSerie();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizaSerie();
            break;
          case "4":
            ExcluiSerie();
            break;
          case "5":
            VisualizaSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static void VisualizaSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);
      Console.WriteLine(serie);
    }

    private static void ExcluiSerie()
    {
      /*
        TODO:
          Colocar uma confirmação para evitar que o usuário exclua sem querer.
          Sugestão, deseja mesmo excluir essa série #####
      */
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);
    }

    private static void AtualizaSerie()
    {
      Console.Write("Digite o id da serie: ");
      int indiceSerie = int.Parse(Console.ReadLine());
      var atualizaSerie = GetSerieAAprtirDaEntradaDoUsuario(indiceSerie);
      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");
      var novaSerie = GetSerieAAprtirDaEntradaDoUsuario(repositorio.ProximoId());
      repositorio.Insere(novaSerie);
    }

    private static Serie GetSerieAAprtirDaEntradaDoUsuario(int indiceSerie)
    {
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Dgite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o titulo da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano de incício da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      return new Serie(
        id: indiceSerie,
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao
      );
    }

    private static void ListaSerie()
    {
      Console.WriteLine("Lista de séries");
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        Console.WriteLine(
          "#ID {0}: - {1} - {2}",
          serie.retornaId(),
          serie.retornaTitulo(),
          (excluido ? "*Excluído*" : "")
        );
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção Desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Insierir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Exluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
