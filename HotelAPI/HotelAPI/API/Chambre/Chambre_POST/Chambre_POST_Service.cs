public class Chambre_POST_Service
{
    private readonly Chambre_POST_Query _query;

    public Chambre_POST_Service(Chambre_POST_Query query)
    {
        _query = query;
    }

    public async Task CreateChambreAsync(Chambre chambre)
    {
        await _query.AddChambreAsync(chambre);
    }
}