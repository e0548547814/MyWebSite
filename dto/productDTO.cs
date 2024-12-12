using Entity;
using System.ComponentModel.DataAnnotations;

namespace dto
{
    public record productDTO(int ProductId, string ProductName, decimal Price, int CategoryId, string Descriptions, Category Category)

    { }
}


