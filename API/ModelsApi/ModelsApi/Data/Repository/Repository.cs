using Microsoft.EntityFrameworkCore;
using ModelsApi.Data;
using ModelsApi.Interfaces;
using ModelsApi.Models;


namespace ScholarShip.Data.Repository;

public class Repository : IRepository{
    
    private readonly ApplicationDbContext _Context;
    

    public Repository(ApplicationDbContext context)
    {
        _Context = context;

    }

    public List<Annonce> GetAnnonceData()
    {
        return _Context.Annonces.ToList();
    }
    
}