using Microsoft.EntityFrameworkCore;

public class Chambre_GET_Query
{
    private readonly AppDbContext _context;

    public Chambre_GET_Query(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Chambre>> GetAllChambresAsync()
    {
        return await _context.Chambres.ToListAsync();
    }
}