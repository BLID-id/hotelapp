using System.ComponentModel.DataAnnotations;

namespace HotelAPI.API.Chambre.Chambre_POST
{
    public class ChambrePostData
    {
        [Required]
        public int ChambreId { get; set; } 

        [Required]
        public int Type { get; set; } 

        //TODO Default values
        [MaxLength(1000, ErrorMessage = "Les commentaires ne peuvent pas dépasser 1000 caractères.")]
        public string? Commentaires { get; set; }
    }
}

