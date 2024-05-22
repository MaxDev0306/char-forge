using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schule_REST.Database;
using Schule_REST.Model;

namespace Schule_REST.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private DatabaseContext _DatabaseContext { get; set; }
        public CharacterController(
            DatabaseContext db
            )
        {
            _DatabaseContext = db;
        }

        [HttpGet()]
        public IActionResult Test()
        {
            try
            {
                Character character = new Character();
                character.Name = "Branibor Treulicht";
                character.Background = _DatabaseContext.Backgrounds.FirstOrDefault();
                character.Class = _DatabaseContext.Classes.FirstOrDefault();
                character.Abilities = new() { _DatabaseContext.Abilities.FirstOrDefault() };
                character.Items = new() { _DatabaseContext.Items.FirstOrDefault() };
                character.Proficiencies = new() { _DatabaseContext.Proficiencies.FirstOrDefault() };
                character.Race = _DatabaseContext.Races.FirstOrDefault();
                character.Level = 2;
                character.Alignment = "Lawful neutral";
                character.ExperiencePoints = 300;
                character.PersonalityTrait = "Likes all sorts of cakes. Even the weird ones.";
                character.Ideals = "Wants to own a bakery and make cake for the king.";
                character.Bonds = "His Father owns a bakery that he will inherit one day.";
                character.Flaws = "Not so secretly hates chocolate.";

                _DatabaseContext.Characters.Add(character);
                _DatabaseContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCharacter(int id)
        {
            try
            {

                return Ok(
                        _DatabaseContext.Characters
                        .Include(x => x.Proficiencies)
                        .Include(x => x.Background)
                        .Include(x => x.Class)
                        .Include(x => x.Abilities)
                        .Include(x => x.Items)
                        .Include(x => x.Race)
                        .FirstOrDefault(x => x.Id == id)
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost()]
        public IActionResult CreateCharacter([FromBody]Character c)
        {
            try
            {
                _DatabaseContext.Characters.Add (c);
                _DatabaseContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut()]
        public IActionResult UpdateCharacter([FromBody] Character c)
        {
            try
            {
                _DatabaseContext.Characters.Update(c);
                _DatabaseContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
