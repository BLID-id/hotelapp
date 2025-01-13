public class Chambre_GET_Service
{
    private readonly Chambre_GET_Query _query;

    public Chambre_GET_Service(Chambre_GET_Query query)
    {
        _query = query;
    }

    public async Task<IEnumerable<Chambre>> GetAllChambresAsync()
    {
        return await _query.GetAllChambresAsync();
    }
}