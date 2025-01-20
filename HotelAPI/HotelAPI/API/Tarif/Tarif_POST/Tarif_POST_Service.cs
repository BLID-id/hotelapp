using HotelAPI.API.SQL;
using Npgsql;

namespace HotelAPI.API.Tarif.Tarif_POST
{
    public static class TarifPostService
    {
        public static string TarifAdd(TarifPostData data)
        {
            using var connection = SqlConnection.GetConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var sqlcommand = TarifPostQuery.QueryPostTarif;
            
            using var command = new NpgsqlCommand(sqlcommand, connection);
            command.Parameters.AddWithValue("@nom", data.Nom);
            command.Parameters.AddWithValue("@prix", data.Prix);
            command.Parameters.AddWithValue("@commentaires", string.IsNullOrEmpty(data.Commentaires) ? "" : data.Commentaires);
            
            var result = command.ExecuteScalar();
            return result != null 
                ? $"Tarif insérée avec succès: {result}" 
                : $"Échec de l'insertion: {result}";
        }
    }
}

