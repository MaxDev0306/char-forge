namespace Schule_REST.Model
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Background Background { get; set; }

        public int BackgroundId { get; set; }

        public Class Class { get; set; }

        public int ClassId { get; set; } 

        public List<Ability> Abilities { get; set; }

        public List<Item> Items { get; set; }

        public List<Proficiency> Proficiencies { get; set; }

        public Race Race { get; set; }

        public int RaceId { get; set;}

        public int Level { get; set; }

        public string Alignment { get; set; }

        public int ExperiencePoints { get; set; }

        public string PersonalityTrait { get; set; }

        public string Ideals {  get; set; }

        public string Bonds { get; set; }

        public string Flaws { get; set; }
    }
}
