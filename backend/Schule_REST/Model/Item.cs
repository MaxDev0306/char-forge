namespace Schule_REST.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }

        public int Weight { get; set; }

        public int ArmorClass { get; set; }

        public string ArmorType { get; set; }

        public int RequiredStrength { get; set; }

        public bool StealthDisadvantage { get; set; }

        public bool IsArmor { get; set; }

        public int DamageDie { get; set; }

        public string WeaponType { get; set; }

        public string Properties { get; set; }

        public string DamageType { get; set; }

        public bool IsWeapon { get; set; }

        public List<Character> Characters { get; set; }

        public List<Background> Backgrounds { get; set; }

        public List<Class> Classes { get; set; }

        public List<ItemChoice> ItemChoices { get; set; }
    }

    public class ItemChoice
    {
        public int Id { get; set; }
        public List<Class> Classes { get; set; }
        public string Name { get; set; }

        public int ChoiceAmount { get; set; }

        public List<Item> Items { get; set; }
    }
}