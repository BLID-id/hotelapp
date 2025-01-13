using Microsoft.EntityFrameworkCore;

public class Chambre_POST_Query
{
    private readonly AppDbContext _context;

    public Chambre_POST_Query(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddChambreAsync(Chambre chambre)
    {
        await _context.Chambres.AddAsync(chambre);
        await _context.SaveChangesAsync();
    }
}