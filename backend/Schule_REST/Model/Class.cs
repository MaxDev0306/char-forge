namespace Schule_REST.Model
{
    public class Class
    {
        public int Id { get; set; }

        public string BaseClassName { get; set; }

        public int HitDice { get; set; }

        public List<Item> StartEquipment { get; set; }

        public List<ItemChoice> StartEquipmentChoices { get; set; }

        public List<Character> Characters { get; set; }

        public List<ClassSpecificFeature> ClassSpecificFeatures { get; set; }

        public List<Proficiency> Proficiencies { get; set; }

        public string SubClassName { get; set; }
    }

    public class ClassSpecificFeature
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public int Level { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public Class Class { get; set; }
    }
}
