using System.ComponentModel.DataAnnotations;

namespace GraphQLAPI.Models;

public class AddSuperpower
{
    [Required(ErrorMessage = "Please specify a name for the Superpower")]
    public string? SuperPower { get; set; }
    public string? Description { get; set; }
   
}