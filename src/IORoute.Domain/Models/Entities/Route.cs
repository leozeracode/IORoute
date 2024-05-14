namespace IORoute.Domain.Models.Entities
{
    public class Route : Entity
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Cost { get; set; }
    }
}
