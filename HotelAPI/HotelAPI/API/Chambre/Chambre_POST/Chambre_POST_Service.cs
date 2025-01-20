using HotelAPI.API.SQL;
using Npgsql;

namespace HotelAPI.API.Chambre.Chambre_POST;

public class ChambrePostService
{
    public static string ChambreAdd(ChambrePostData chambrePostData)
    {
        using (var connection = SqlConnection.GetConnection())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            string sqlCommande = ChambrePostQuery.QueryPostChambre;

            using (var command = new NpgsqlCommand(sqlCommande, connection))
            {
                command.Parameters.AddWithValue("@chambreID", chambrePostData.ChambreId);
                command.Parameters.AddWithValue("@type", chambrePostData.Type);
                
                try
                {
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return $"Chambre insérée avec succès: {result}";
                    }
                    else
                    {
                        return "Échec de l'insertion de la chambre.";
                    }
                }
                catch (Exception ex)
                {
                    return $"Erreur lors de l'insertion : {ex.Message}";
                }
            }
        }
    }
}