using System.ComponentModel.DataAnnotations;

namespace mysqlAPI.Model;

public class User
{
    [Required]
    public int id {get; set;}

    [Required]
    public string? Nome {get; set;}

    [Required]
    public int Idade {get; set;}
}