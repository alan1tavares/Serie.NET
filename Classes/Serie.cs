using DIO.Series.Enum;
using System;

namespace DIO.Series.Classes
{
  public class Serie : EntidadeBase
  {
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }

    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Gênero: " + this.Genero + Environment.NewLine;
      retorno += "Titulo: " + this.Genero + Environment.NewLine;
      retorno += "Descrição: " + this.Genero + Environment.NewLine;
      retorno += "Ano de Inicio: " + this.Genero + Environment.NewLine;
      return retorno;
    }

    public string retornaTitulo()
    {
        return this.Titulo;
    }

    public int retornaId()
    {
        return this.Id;
    }

  }
}