using System.Diagnostics.CodeAnalysis;

namespace Schule_REST.Model
{
    public class Proficiency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Character> Characters { get; set; }

        public List<Background> Backgrounds { get; set; }

        public int AbilityId { get; set; }

        
        public Ability Ability { get; set; }

        
        public Skill Skill { get; set; }

        public int SkillId { get; set; }

        public bool IsExpertiese { get; set; }

        public List<Race> Races { get; set; }

        public List<Class> Classs { get; set; }
    }
}
