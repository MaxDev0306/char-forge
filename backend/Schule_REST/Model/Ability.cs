namespace Schule_REST.Model
{
    public class Ability
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public List<Proficiency> Proficiencies { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Character> Characters { get; set; }

        public List<RaceAbilityScoreIncrease> RaceAbilityScoreIncreases { get; set; }
    }

    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AbilityId { get; set; }
        public List<Proficiency> Proficiencies { get; set; }

        public Ability Ability { get; set; }
    }
}
