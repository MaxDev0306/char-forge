using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schule_REST.Database;
using Schule_REST.Model;

namespace Schule_REST.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class BackgroundController : ControllerBase
    {
        private DatabaseContext _DatabaseContext { get; set; }
        public BackgroundController(
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
                Background background = new Background();
                background.Name = "Acolyte";
                background.Description = "You have spent your life in a temple serving a god.";
                background.Equipment = new()
                {
                    _DatabaseContext.Items.FirstOrDefault()
                };
                background.Proficiencies = new()
                {
                    _DatabaseContext.Proficiencies.FirstOrDefault()
                };
                BackgroundFeature backgroundFeature = new BackgroundFeature();
                backgroundFeature.Name = " Shelter of the Faithful";
                backgroundFeature.Description = "Tempels will grant you and you rparty accomodation and help you if they can.";
                background.Features = new()
                {
                    backgroundFeature
                };

                _DatabaseContext.Backgrounds.Add(background);
                _DatabaseContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{name}")]
        public ActionResult<List<Background>> GetBackground(string name)
        {
            try
            {
                return Ok(_DatabaseContext.Backgrounds
                    .Include(x => x.Proficiencies).ThenInclude(x => x.Ability)
                    .Include(x => x.Features)
                    .Include(x => x.Equipment)
                    .Where(x => x.Name.ToLower() == name.ToLower()).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}