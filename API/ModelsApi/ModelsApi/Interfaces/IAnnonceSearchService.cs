using ModelsApi.Models;

namespace ModelsApi.Interfaces;

public interface IAnnonceSearchService
{
    public List<Annonce> SearchAnnonces(string Keyword);
    
}