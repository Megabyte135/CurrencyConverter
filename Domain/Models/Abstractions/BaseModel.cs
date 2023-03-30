using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Abstractions;

public abstract class BaseModel
{
    public required int Id { get; init; }
}