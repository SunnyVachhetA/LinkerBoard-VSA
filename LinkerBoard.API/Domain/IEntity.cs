using System.ComponentModel.DataAnnotations;

namespace LinkerBoard.API.Domain;

public abstract class BaseEntity<Tkey>
    where Tkey : notnull
{
    [Key]
    public Tkey Id { get; set; }
}