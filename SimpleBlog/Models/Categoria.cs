using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models;
public class Categoria
{
    public int Id { get; set; }

    [Required] //é tipo o not null do banco
    [StringLength(30)]
    public string Nome { get; set; }

    public Categoria() {}

    public Categoria(int id, string nome) 
    {
        Id = id;
        Nome = nome;
    }

}

