using Microsoft.EntityFrameworkCore;
using ModelsApi.Data;
using ScholarShip.Interfaces;
using ScholarShip.Models;


namespace ScholarShip.Data.Repository;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _Context;

    public Repository(ApplicationDbContext context)
    {
        _Context = context;
    }

    public List<Annonce> GetAnnonceData()
    {
        return _Context.Annonces.ToList();
    }


    
    
    /*public IEnumerable<Annonce> search(string Keyword)
    {
        var annonceSearch = await _Context.Annonces
            .Where(x => x.Titel.Contains(Keyword) || x.Beskrivelse.Contains(Keyword))
            .ToListAsync();
        return annonceSearch;
    }*/
}