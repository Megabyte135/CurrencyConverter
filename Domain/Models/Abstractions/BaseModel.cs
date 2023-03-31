using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Abstractions;

public abstract class BaseModel
{
    [Required] public int Id { get; init; }
}