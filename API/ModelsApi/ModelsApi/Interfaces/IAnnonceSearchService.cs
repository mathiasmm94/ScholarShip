using ModelsApi.Models;

namespace ModelsApi.Interfaces;

public interface IAnnonceSearchService
{
    List<Annonce> SearchAnnonces(string Keyword);
}