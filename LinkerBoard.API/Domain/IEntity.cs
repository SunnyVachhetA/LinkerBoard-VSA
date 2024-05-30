using System.ComponentModel.DataAnnotations;

namespace LinkerBoard.API.Domain;

internal abstract class BaseEntity<Tkey>
    where Tkey : notnull
{
    [Key]
    public Tkey Id { get; set; }
}