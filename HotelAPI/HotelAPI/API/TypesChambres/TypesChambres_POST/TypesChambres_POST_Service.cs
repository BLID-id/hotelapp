using Npgsql;
using HotelAPI.API.SQL;


namespace HotelAPI.API.TypesChambres.TypesChambres_POST
{
    public static class TypesChambresPostService
    {
        public static string ChambresTypesAdd(TypesChambresPostData data)
        {
            using var connection = SqlConnection.GetConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var sqlCommande = TypesChambresPostQuery.QueryPostTypesChambres;

            using var command = new NpgsqlCommand(sqlCommande, connection);
            command.Parameters.AddWithValue("@nom", data.Nom);
            command.Parameters.AddWithValue("@tarif", data.Tarif);
            command.Parameters.AddWithValue("@nombre_lits_simples", data.NombreLitsSimples);
            command.Parameters.AddWithValue("@nombre_lits_doubles", data.NombreLitsDoubles);
            command.Parameters.AddWithValue("@capacite", data.Capacite);
            command.Parameters.AddWithValue("@commentaires", string.IsNullOrEmpty(data.Commentaires) ? "" : data.Commentaires);

            var result = command.ExecuteScalar();
            return result != null 
                ? $"Chambre insérée avec succès: {result}" 
                : $"Échec de l'insertion: {result}";
        }
    }
}
