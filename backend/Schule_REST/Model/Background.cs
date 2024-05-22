namespace Schule_REST.Model
{
    public class Background
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public List<Character> Characters { get; set; }


        public List<Proficiency> Proficiencies { get; set; }

        public List<Item> Equipment { get; set; }

        public List<BackgroundFeature> Features { get; set; }
    }

    public class BackgroundFeature
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BackgroundId { get; set; }

        public Background Background { get; set; }
    }
}
