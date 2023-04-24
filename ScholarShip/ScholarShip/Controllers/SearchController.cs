using Microsoft.AspNetCore.Mvc;
using ScholarShip.Interfaces;

namespace ScholarShip.Controllers;

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
    public IActionResult SearchAnnonces(string Keyword)
    {
        var annonces = _annonceSearchService.SearchAnnonces(Keyword);
        return Ok(annonces);
    }
}