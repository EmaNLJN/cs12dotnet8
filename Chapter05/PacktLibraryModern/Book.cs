using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared;

/*
  required es una caracteristica reciente, agregada en c# 11, actua como una suerte variable que va a ser asignada
  en momentos de instanciacion del objecto. Tambien puede ser util como un invariante.
  para inicializar los atributos con el modificador required, se necesita de un decorators provisto por
  la libreria code analisys
*/
public class Book
{
  public required string? Isbn;
  public required string? Title;
  public string? Author;
  public int PageCount;

  public Book() {}

  [SetsRequiredMembers]
  public Book(string? isbn, string? title)
  {
    Isbn = isbn;
    Title = title;
  }
}