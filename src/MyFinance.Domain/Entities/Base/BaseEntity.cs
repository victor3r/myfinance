
using System.ComponentModel.DataAnnotations;

namespace MyFinance.Domain.Entities.Base;

public class BaseEntity
{
    [Key]
    public int? Id { get; set; }
}
