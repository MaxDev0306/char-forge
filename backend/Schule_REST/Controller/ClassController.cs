using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schule_REST.Database;
using Schule_REST.Model;
using System.Xml.Linq;

namespace Schule_REST.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private DatabaseContext _DatabaseContext { get; set; }
        public ClassController(
            DatabaseContext db
            )
        {
            _DatabaseContext = db;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            try
            {
                Class monk = new();
                monk.BaseClassName = "Monk";
                monk.SubClassName = "Way of the open Hand";
                monk.HitDice = 8;
                Item dart = new Item()
                {
                    IsWeapon = true,
                    DamageDie = 4,
                    DamageType = "piercing",
                    Name = "Dart",
                    Description = "Throwing Dart",
                    Value = 5,
                    Weight = 0,
                    WeaponType = "Simple Melee Weapon",
                    Properties = "Finesse, Thrown (20/60)",
                    Classes = new() { monk }
                };
                Item shortsword = new()
                {
                    IsWeapon = true,
                    DamageDie = 6,
                    DamageType = "slashing",
                    Name = "Showtsword",
                    Description = "A simple shortsword",
                    Value = 10,
                    Weight = 2,
                    WeaponType = "Martial Melee Weapon",
                    Properties = "Finesse, light"
                };
                Item any = new Item()
                {
                    IsWeapon = true,
                    DamageDie = 0,
                    DamageType = "",
                    Name = "Any simple melee Weapon",
                    Description = "Any simple melee Weapon",
                    Value = 0,
                    Weight = 0,
                    WeaponType = "Simple Melee Weapon",
                    Properties = ""
                };
                monk.StartEquipment = new()
                {
                    dart
                };
                ItemChoice itemChoice = new ItemChoice()
                {
                    Name = "(a) a shortbow or (b) any simple weapon",
                    ChoiceAmount = 1,
                    Items = new()
                        {
                            shortsword,
                            any
                        },
                    Classes = new(){ monk}
                };
                ItemChoice itemChoice2 = new ItemChoice()
                {
                    Name = "(a) a dungeoneers pack (b) an explorers pack",
                    ChoiceAmount = 1,
                    Items = new()
                        {
                            new()
                            {
                                Name = "Dungeoneers pack",
                                Description = "A pack full of everything one might need in a dungeon",
                                Value = 12,
                                Weight = 20
                            },
                            new()
                            {
                                Name = "Explorers pack",
                                Description = "A pack full of everything one might need while being out and about in the wilderness",
                                Value = 10,
                                Weight = 17
                            }
                        }
                };
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
                Proficiency proficiency = new Proficiency()
                {
                    Name = "Acrobatics",
                    Skill = Acrobatics,
                    Ability = dex
                };
                Proficiency proficiency2 = new()
                {
                    Ability = dex,
                    Skill = SleightOfHand,
                    Name = "Sleight of Hand"
                };
                monk.Proficiencies = new()
                {
                    proficiency,
                    proficiency2
                };
                monk.StartEquipmentChoices = new()
                {
                    itemChoice, itemChoice2
                };
                ClassSpecificFeature csf1 = new ClassSpecificFeature()
                {
                    Class = monk,
                    Name = "Unarmored Defense",
                    Description = "Beginning at 1st level, while you are wearing no armor and not wielding a shield, your AC equals 10 + your Dexterity modifier + your Wisdom modifier.",
                    Level = 1
                };
                ClassSpecificFeature csf2 = new()
                {
                    Class = monk,
                    Name = "Martial Arts",
                    Description = "At 1st level, your practice of martial arts gives you mastery of combat styles that use unarmed strikes and monk weapons, which are shortswords and any simple meele weapon that don't have the two-handed or heavy property.",
                    Level = 1
                };
                ClassSpecificFeature csf3 = new()
                {
                    Class = monk,
                    Name = "Ki",
                    Description = "Starting at 2nd level, your training allows you to harness the mystic energy of ki. Your access to this energy is represented by a number of ki points. Your monk level detemines the number of points you have, as shown in the Ki Points column in the Monk table.",
                    Level = 2
                };
                monk.ClassSpecificFeatures = new()
                {
                    csf1,
                    csf2,
                    csf3
                };
                

                _DatabaseContext.Classes.Add( monk );


                _DatabaseContext.SaveChanges();

                return Ok();
            }
            catch ( Exception ex )
            {
                return BadRequest( ex );
            }
        }

        [HttpGet("")]
        public ActionResult<List<Class>> GetClasses()
        {
            try
            {
                var returns = _DatabaseContext.Classes
                    .Include(x => x.ClassSpecificFeatures)
                    .Include(x => x.StartEquipment)
                    .Include(x => x.Proficiencies)
                    .Include(x => x.StartEquipmentChoices).ThenInclude(x => x.Items);

                return Ok(returns);
            }
            catch(Exception e) 
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{name}")]
        public ActionResult<List<Class>> GetClass(string name)
        {
            try
            {
                var returns = _DatabaseContext.Classes
                    .Include(x => x.ClassSpecificFeatures)
                    .Include(x => x.StartEquipment)
                    .Include(x => x.StartEquipmentChoices)
                    .Include(x => x.Proficiencies)
                    .Where(x => x.BaseClassName.ToLower() == name.ToLower());

                return Ok(returns);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("sub/{name}")]
        public ActionResult<List<Class>> GetSubClass(string name)
        {
            try
            {
                var returns = _DatabaseContext.Classes
                    .Include(x => x.ClassSpecificFeatures)
                    .Include(x => x.StartEquipment)
                    .Include(x => x.StartEquipmentChoices).ThenInclude(x => x.Items)
                    .Where(x => x.SubClassName.ToLower() == name.ToLower());

                return Ok(returns);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
