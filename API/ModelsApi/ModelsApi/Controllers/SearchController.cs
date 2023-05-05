using Microsoft.AspNetCore.Mvc;
using ModelsApi.Interfaces;
using ModelsApi.Interfaces;

namespace ModelsApi.Controllers;

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
        return new JsonResult(annonces);
    }
}