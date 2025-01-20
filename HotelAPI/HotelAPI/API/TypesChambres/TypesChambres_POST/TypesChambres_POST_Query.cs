namespace HotelAPI.API.TypesChambres.TypesChambres_POST
{
    public static class TypesChambresPostQuery
    {
        public const string QueryPostTypesChambres = "INSERT INTO types_chambres (nom, tarif, nombre_lits_simples, nombre_lits_doubles, capacite, commentaires) VALUES (@nom, @tarif, @nombre_lits_simples, @nombre_lits_doubles, @capacite, @commentaires) RETURNING *;";
    }
}