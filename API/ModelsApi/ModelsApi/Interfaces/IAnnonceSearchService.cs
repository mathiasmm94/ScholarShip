using ScholarShip.Models;

namespace ScholarShip.Interfaces;

public interface IAnnonceSearchService
{
    List<Annonce> SearchAnnonces(string Keyword);
}