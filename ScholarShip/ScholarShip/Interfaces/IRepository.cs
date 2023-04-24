using ScholarShip.Models;

namespace ScholarShip.Interfaces;

public interface IRepository
{
    public List<Annonce> GetAnnonceData();
}