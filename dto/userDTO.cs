using System.ComponentModel.DataAnnotations;

namespace dto
{
    public record userDTO(string UserName , string? FirstName,string? LastName,
        List<orderDTO> Orders);
    public record RegisterUserDTO(string UserName, string? FirstName,
        string? LastName, string? Password);

}

