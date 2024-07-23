using System.ComponentModel.DataAnnotations;

namespace APIPLANETAS.Models
{
    public class Planets
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? RotationPeriod { get; set; }

        public int? OrbitalPeriod { get; set; }

        [Required]
        public string Diameter { get; set; }

        [Required]
        public string Climate { get; set; }

        [Required]
        public string Gravity { get; set; }

        [Required]
        public string Terrain { get; set; }

        public string? SurfaceWater { get; set; }

        [Required]
        public string Population { get; set; }
    }
}

