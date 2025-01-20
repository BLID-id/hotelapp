using System.ComponentModel.DataAnnotations;

namespace HotelAPI.API.TypesChambres.TypesChambres_POST
{
    public class TypesChambresPostData
    {
        [Required]
        //TODO Default values
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        public required string Nom { get; set; }

        [Required]
        //TODO Default values
        [Range(0, double.MaxValue, ErrorMessage = "Le tarif doit être un nombre positif.")]
        public required decimal Tarif { get; set; }

        [Required]
        //TODO Default values
        [Range(0, 9, ErrorMessage = "Le nombre de lits simples doit être un entier positif inférieur à 10.")]
        public required short NombreLitsSimples { get; set; }

        [Required]
        //TODO Default values
        [Range(0, 9, ErrorMessage = "Le nombre de lits doubles doit être un entier positif inférieur à 10.")]
        public required short NombreLitsDoubles { get; set; }

        [Required]
        //TODO Default values
        [Range(1, short.MaxValue, ErrorMessage = "La capacité doit être au moins 1.")]
        public required short Capacite { get; set; }

        [MaxLength(1000, ErrorMessage = "Les commentaires ne peuvent pas dépasser 1000 caractères.")]
        public string? Commentaires { get; set; } = string.Empty;
    }
}