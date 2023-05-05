using ModelsApi.Models;

namespace ModelsApi.Interfaces;

public interface IRepository
{
    public List<Annonce> GetAnnonceData();


}