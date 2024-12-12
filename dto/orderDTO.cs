using Entity;
using System.ComponentModel.DataAnnotations;

namespace dto
{
    public record orderDTO(int OrderId,DateTime OrderDate, int OrderSum, int UserId, User User)
    { }
}
