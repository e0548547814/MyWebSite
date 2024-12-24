using Entity;
using System.ComponentModel.DataAnnotations;

namespace dto
{
    public record orderDTO(DateTime? OrderDate, int? OrderSum,
         string? UserUserName, List<orderItemsDTO> OrderItems);
public record addOrderDTO(DateTime OrderDate, double OrderSum,
    int? UserId, List<orderItemsDTO> OrderItems);

}
