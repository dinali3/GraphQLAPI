namespace GraphQLAPI.Models;
using System.ComponentModel.DataAnnotations;

public class UpdateSuperpower
{
    [Key]
    public Guid Id { get; set; }
    public string? SuperPower { get; set; }
    public string? Description { get; set; }
   
}
