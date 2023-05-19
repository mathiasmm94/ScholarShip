using Microsoft.AspNetCore.Mvc;
using ModelsApi.Interfaces;
using ModelsApi.Models;

namespace ModelsApi.Controllers;


[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly IAnnonceSearchService _annonceSearchService;

    public SearchController(IAnnonceSearchService annonceSearchService)
    {
        _annonceSearchService = annonceSearchService;
    }

    [HttpGet("{Keyword}")]
    public async Task<List<Annonce>> SearchAnnonces(string Keyword)
    {
        
        return _annonceSearchService.SearchAnnonces(Keyword);  
    }
}