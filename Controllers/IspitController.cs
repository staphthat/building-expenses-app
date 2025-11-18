using System.Drawing;
using Microsoft.Identity.Client;
using WebTemplate.Models;

namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitController : ControllerBase
{
    public IspitContext Context { get; set; }

    public IspitController(IspitContext context)
    {
        Context = context;
    }

       [HttpGet("VratiSve")]
    public async Task<ActionResult> VratiSve()
    {
        try
        {
            var podaci = await Context.Stanovi.Include(r => r.Racuni).ToListAsync();
            return Ok(podaci);
        }

        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiInformacijeZaStan/{stanID}")]
    public async Task<ActionResult> VratiInformacijeZaStan(int stanID)
    {
        try
        {
            var infoStana = await Context.Stanovi.Where(r => r.ID == stanID).Select(r => new
            {
                BrojStana = r.BrojStana,
                ImeVlasnika = r.ImeVlasnika,
                Povrsina = r.Povrsina,
                BrojClanova = r.BrojClanova,
                Racuni = r.Racuni!.Select(s => new
                {
                    Mesec = s.Mesec,
                    CenaVode = s.CenaVode,
                    CenaStruje = s.CenaStruje,
                    CenaKomunalija = s.CenaKomunalija
                }).ToList()
            }).FirstOrDefaultAsync();

            if (infoStana==null)
            {
                return NotFound($"Stan sa ID-em {stanID} nije pronadjen.");
            }

            return Ok(infoStana);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("IzracunajUkupnoZaduzenje/{stanID}")]
    public async Task<ActionResult> IzracunajUkupnoZaduzenje(int stanID)
    {
        try
        {
            var postojeciStan = await Context.Stanovi.Where(s => s.ID == stanID).FirstOrDefaultAsync();
            
            if(postojeciStan==null)
            {
                return BadRequest("Stan sa tim ID-em ne postoji.");
            }

            var ukupnoZaduzenje = await Context.Racuni.Where(r => !r.Placen && r.Stan==postojeciStan).SumAsync(s=>s.CenaVode + s.CenaKomunalija + s.CenaStruje);
            return Ok( new
            {
                zaduzenje=ukupnoZaduzenje
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("DodajRacun/{stanID}")]
    public async Task<ActionResult> DodajRacun([FromBody] Racun racun, int stanID)
    {
        try
        {
            var stan = await Context.Stanovi.Where(s => s.ID == stanID).FirstOrDefaultAsync();
            if (stan == null)
            {
                return NotFound($"Stan sa ID-jem {stanID} nije pronadjen.");
            }

            double cenaStruje = 150 * stan.BrojClanova;
            double cenaKomunalija = 100 * stan.BrojClanova;


            Racun r = new Racun
            {
                Mesec = racun.Mesec,
                CenaVode = racun.CenaVode,
                CenaStruje = cenaStruje,
                CenaKomunalija = cenaKomunalija,
                Placen = racun.Placen,
                Stan = stan
            };

            Context.Racuni.Add(r);
            await Context.SaveChangesAsync();

            return Ok(r);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost("DodajStan")]
    public async Task<ActionResult> DodajStan([FromBody] Stan stan)
    {
        if (stan == null)
        {
            return BadRequest("Podaci o stanu nisu uneti.");
        }

        try
        {
            // Provera da li stan sa tim brojem vec postoji
            var postojeciStan = await Context.Stanovi.FirstOrDefaultAsync(s => s.BrojStana == stan.BrojStana);
            if (postojeciStan != null)
            {
                return BadRequest($"Stan sa brojem {stan.BrojStana} već postoji.");
            }

            Stan noviStan = new Stan
            {
                BrojStana = stan.BrojStana,
                ImeVlasnika = stan.ImeVlasnika,
                Povrsina = stan.Povrsina,
                BrojClanova = stan.BrojClanova
            };

            Context.Stanovi.Add(noviStan);
            await Context.SaveChangesAsync();

            return Ok(noviStan); // Vracamo kreirani stan sa njegovim ID-jem
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("PromeniStan/{stanID}/{brojStana}")]
    public async Task<ActionResult> PromeniStan (int stanID, int brojStana)
    {
        try
        {
            var stanZaPromenu = await Context.Stanovi.FindAsync(stanID);

            stanZaPromenu!.BrojStana = brojStana;

            Context.Stanovi.Update(stanZaPromenu);
            await Context.SaveChangesAsync();
            return Ok(stanZaPromenu);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
 }