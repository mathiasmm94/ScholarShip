using ScholarShip.Interfaces;

namespace ScholarShip.Models.Services;

public class AnnonceSearchService : IAnnonceSearchService
{
    private readonly IRepository _Repository;

    public AnnonceSearchService(IRepository Repository)
    {
        _Repository = Repository;
    }
    public List<Annonce> SearchAnnonces(string Keyword)
    {
        var SearchAnnonce = _Repository.GetAnnonceData();
        
        return SearchAnnonce
            .Where(x => x.Titel.Contains(Keyword)).ToList();
    }
}