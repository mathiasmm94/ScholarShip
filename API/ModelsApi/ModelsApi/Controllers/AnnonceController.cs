using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsApi.Data;
using ModelsApi.Models;
using ModelsApi.Models.DTOs;

namespace ModelsApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AnnoncesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnnoncesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Annonces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Annonce>>> GetAnnonces()
        {
            if (_context.Annonces == null)
            {
               
                return NotFound();
            }  
            return await _context.Annonces.ToListAsync();
        }

        // GET: api/Annonces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Annonce>> GetAnnonce(int id)
        {
            if (_context.Annonces == null)
            {
                return NotFound();
            }
            var annonce = await _context.Annonces.FindAsync(id);

            if (annonce == null)
            {
                return NotFound();
            }

            return annonce;
        }

        // PUT: api/Annonces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnonce(int id, AnnonceDTO annonceforPut)
        {
            //if (id != annonceforPut.AnnonceId)
            //{
            //    return BadRequest();
            //}
            Annonce annonce2 = new Annonce
            {
                AnnonceId=id,
                Beskrivelse=annonceforPut.Beskrivelse,
                BilledeSti=annonceforPut.BilledeSti,
                EfManagerId=annonceforPut.EfManagerId,
                Stand = annonceforPut.Stand,
                Studieretning=annonceforPut.Studieretning,
                Titel = annonceforPut.Titel,
                Price = annonceforPut.Price,
                Kategori = annonceforPut.Kategori,
                ChatId = annonceforPut.ChatId
            };

            _context.Entry(annonce2).State = EntityState.Modified;
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnonceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Annonces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Annonce>> PostAnnonce(AnnonceDTO annonce)
        {
            if (_context.Annonces == null)
            {
                return Problem("Entity set 'DBcontext.Annonces'  is null.");
            }
            Annonce annonce1 = new Annonce {
            AnnonceId=annonce.AnnonceId,
            Beskrivelse=annonce.Beskrivelse,
            BilledeSti=annonce.BilledeSti,
            EfManagerId=annonce.EfManagerId,
            Stand = annonce.Stand,
            Studieretning=annonce.Studieretning,
            Titel = annonce.Titel,
            Price = annonce.Price,
            Kategori = annonce.Kategori,
            ChatId = annonce.ChatId,
            NumberOfWeeks=annonce.NumberOfWeeks,
            CheckBoxValue=annonce.CheckBoxValue           
            };
            

            _context.Annonces.Add(annonce1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnnonce", new { id = annonce1.AnnonceId }, annonce1);
        }

        // DELETE: api/Annonces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnonce(int id)
        {
            if (_context.Annonces == null)
            {
                return NotFound();
            }
            var annonce = await _context.Annonces.FindAsync(id);
            if (annonce == null)
            {
                return NotFound();
            }

            _context.Annonces.Remove(annonce);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnnonceExists(int id)
        {
            return (_context.Annonces?.Any(e => e.AnnonceId == id)).GetValueOrDefault();
        }
    }
}
