using System.ComponentModel.DataAnnotations;

namespace IORoute.Domain.Models.DTO
{
    public class RouteModelViewModel
    {
        [Required (ErrorMessage = "O campo {0} é obrigatório")]
        public string Origin { get; set; }

        [Required (ErrorMessage = "O campo {0} é obrigatório")]
        public string Destination { get; set; }
    }
}