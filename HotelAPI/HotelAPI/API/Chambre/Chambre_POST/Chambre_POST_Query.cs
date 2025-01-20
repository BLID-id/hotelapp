namespace HotelAPI.API.Chambre.Chambre_POST
{
    public class ChambrePostQuery
    {
        public static string QueryPostChambre = "INSERT INTO chambres (chambreId, type_id, commentaires) VALUES ($1, $2, $3) RETURNING *;";
    }
}

