using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace motiv.Models
{
    public class AbonentRequest
    {
        public int Id { get; set; }

        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        [MaxLength(12)]
        public string Number { get; set; }
        public string Reason { get; set; }
        public Direction Direction { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public enum Direction
    {
        Офис,
        КонтактЦентр
    }
}
