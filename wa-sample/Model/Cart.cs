using System.ComponentModel.DataAnnotations;

namespace wa_sample.Model;

public class Cart
{
    [Key]
    public int Id {get;set;}

    [Required (ErrorMessage ="Name is required")]
    public string? Name {get;set;}
}