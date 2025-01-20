namespace HotelAPI.API.Tarif.Tarif_POST
{
    public static class TarifPostQuery
    {
        public const string QueryPostTarif = "INSERT INTO tarifs (nom, prix, commentaires) VALUES (@nom, @prix, @commentaires) RETURNING *;";
    }
}

