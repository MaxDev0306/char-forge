namespace Schule_REST.Model
{
    public class Race
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string BaseRaceName { get; set; }

        public string Description { get; set; }

        public List<Character> Characters { get; set; }

        public List<RaceAbilityScoreIncrease> AbilityScoreIncreases { get; set; }

        public string Size { get; set; }

        public int WalkingSpeed { get; set; }

        public int FlyingSpeed { get; set; }

        public int SwimmingSpeed { get; set; }

        public int ClimbingSpeed { get; set; }

        public List<Proficiency> Proficiencies { get; set;}

        public List<RaceFeature> RaceFeatures { get; set;}

    }

    public class RaceAbilityScoreIncrease
    {
        public int Id { get; set;}
        public int AbilityId { get; set; }

        public Ability Ability { get; set; }

        public Race Race { get; set; }

        public int RaceId { get; set; }

        public int Amount { get; set; }
    }

    public class RaceFeature
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int RaceId { get; set; }

        public Race Race { get; set; }
    }
}
