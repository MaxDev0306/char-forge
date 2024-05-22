using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schule_REST.Database;
using Schule_REST.Model;

namespace Schule_REST.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private DatabaseContext _DatabaseContext { get; set; }
        public RaceController(
            DatabaseContext db
            )
        {
            _DatabaseContext = db;
        }

        [HttpGet("")]
        public IActionResult Test()
        {
            try
            {
                Race elf = new Race();
                elf.Name = "Woodelf";
                elf.BaseRaceName = "Elf";
                elf.Description = "Forest dwellers that like to live among their own kind and see other races as inferior to them, especially dwarvens.";
                elf.Size = "M";
                elf.WalkingSpeed = 35;
                elf.SwimmingSpeed = 0;
                elf.FlyingSpeed = 0;
                elf.ClimbingSpeed = 0;
                Skill Acrobatics = new Skill()
                {
                    Name = "Acrobatics"
                };
                Skill SleightOfHand = new Skill()
                {
                    Name = "Sleight of Hand"
                };
                Skill Stealth = new Skill()
                {
                    Name = "Stealth"
                };
                Ability dex = new Ability()
                {
                    Name = "Dexterity",
                    Value = 0,
                    Skills = new() { Acrobatics, SleightOfHand, Stealth }
                };
                Skill ah = new Skill()
                {
                    Name = "Animal Handling"
                };
                Skill insight = new Skill()
                { Name = "Insight" };
                Skill medicine = new Skill() { Name = "Medicine" };
                Skill perception = new Skill() { Name = "Perception" };
                Skill survival = new() { Name = "Survival" };
                Ability wisdom = new Ability()
                {
                    Name = "Wisdom",
                    Value = 0,
                    Skills = new() { ah, insight, medicine, perception, survival }
                };
                RaceAbilityScoreIncrease asi = new RaceAbilityScoreIncrease()
                {
                    Ability = dex,
                    Amount = 2
                };
                RaceAbilityScoreIncrease raceAbilityScoreIncrease = new RaceAbilityScoreIncrease()
                {
                    Ability = wisdom,
                    Amount = 1
                };
                elf.AbilityScoreIncreases = new()
                {
                    asi,
                    raceAbilityScoreIncrease
                };
                Proficiency p = new()
                {
                    Name = "longsword",
                    Ability = dex,
                    Skill = Acrobatics
                };
                Proficiency f = new()
                { Name = "shortbow",
                    Ability = dex,
                    Skill = Acrobatics
                };
                Proficiency g = new()
                { Name = "longbow",
                    Ability = dex,
                    Skill = Acrobatics
                };
                elf.Proficiencies = new()
                {
                    p,f,g
                };
                elf.RaceFeatures = new();
                RaceFeature ff = new()
                {
                    Name = "Fleet of Foot",
                    Description = "Your base walking speed increases to 35 feet.",
                    Race = elf
                };
                RaceFeature dv = new()
                {
                    Name = "Dark Vision",
                    Description = "You can see in dim light within 60 feet as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray."
                };
                elf.RaceFeatures.Add(ff);
                elf.RaceFeatures.Add(dv);

                _DatabaseContext.Races.Add(elf);
                _DatabaseContext.SaveChanges();
                return Ok();
            }
            catch ( Exception ex )
            {
                return BadRequest( ex );
            }
        }

        [HttpGet("{name}")]
        public ActionResult<Race> GetRace(string name)
        {
            try
            {
                var a = _DatabaseContext.Races
                    .Include(x => x.RaceFeatures)
                    .Include(x => x.AbilityScoreIncreases).ThenInclude(x => x.Ability)
                    .Include(x => x.Proficiencies)
                    .FirstOrDefault(x => x.Name == name);

                return Ok(a);
            }
            catch ( Exception ex )
            {
                return BadRequest(ex);
            }
        }
    }
}
