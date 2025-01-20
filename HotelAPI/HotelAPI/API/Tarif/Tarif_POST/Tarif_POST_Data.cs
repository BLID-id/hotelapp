using System.ComponentModel.DataAnnotations;

namespace HotelAPI.API.Tarif.Tarif_POST
{
    public class TarifPostData
    {
        [Required(ErrorMessage = "Le nom est requis.")]
        //TODO Default values
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prix est requis.")]
        //TODO Default values
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être un nombre positif.")]
        public decimal Prix { get; set; }
        
        //TODO Default values
        [MaxLength(1000, ErrorMessage = "Les commentaires ne doivent pas dépasser 1000 caractères.")]
        public string? Commentaires { get; set; }
    }
}