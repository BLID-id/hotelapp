using System.ComponentModel.DataAnnotations;

namespace HotelAPI.API.Chambre.Chambre_POST
{
    public class ChambrePostData
    {
        [Required]
        public int ChambreId { get; set; } 

        [Required]
        public int Type { get; set; } 

        [MaxLength(500)]
        public string? Commentaires { get; set; }
    }
}

