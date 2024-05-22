using Microsoft.EntityFrameworkCore;
using Schule_REST.Model;

namespace Schule_REST.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base (options)
        {
        }
        public DbSet<Ability> Abilities { get; set; }

        public DbSet<Skill> Skill { get; set; }

        public DbSet<Background> Backgrounds { get; set; }

        public DbSet<BackgroundFeature> BackgroundFeatures { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<ClassSpecificFeature> ClassSpecificFeatures { get; set; }

        public DbSet<ItemChoice> ItemChoices { get; set; }

        public DbSet<Item> Items { get; set; }   

        public DbSet<Proficiency> Proficiencies { get; set; }


        public DbSet<Race> Races { get; set; }

        public DbSet<RaceAbilityScoreIncrease> RaceAbilityScoreIncreases { get; set; }

        public DbSet<RaceFeature> RaceFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>().HasKey(x => x.Id);
            modelBuilder.Entity<Skill>().HasKey(x => x.Id);
            modelBuilder.Entity<Background>().HasKey(x => x.Id);
            modelBuilder.Entity<BackgroundFeature>().HasKey(x => x.Id);
            modelBuilder.Entity<Character>().HasKey(x => x.Id);
            modelBuilder.Entity<Class>().HasKey(x => x.Id);
            modelBuilder.Entity<ClassSpecificFeature>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemChoice>().HasKey(x => x.Id);
            modelBuilder.Entity<Item>().HasKey(x => x.Id);
            modelBuilder.Entity<Proficiency>().HasKey(x => x.Id);
            modelBuilder.Entity<Race>().HasKey(x => x.Id);
            modelBuilder.Entity<RaceAbilityScoreIncrease>().HasKey(x => x.Id);
            modelBuilder.Entity<RaceFeature>().HasKey(x => x.Id);

            modelBuilder.Entity<Ability>()
                .HasMany(x => x.Skills)
                .WithOne(x => x.Ability)
                .HasForeignKey(x => x.AbilityId);

            modelBuilder.Entity<Ability>()
                .HasMany(x => x.Characters)
                .WithMany(x => x.Abilities);
            
            modelBuilder.Entity<Ability>()
                .HasMany(x => x.RaceAbilityScoreIncreases)
                .WithOne(x => x.Ability)
                .HasForeignKey(x => x.AbilityId);
            
            modelBuilder.Entity<Background>()
                .HasMany(x => x.Proficiencies)
                .WithMany(x => x.Backgrounds);
            
            modelBuilder.Entity<Background>()
                .HasMany(x => x.Characters)
                .WithOne(x => x.Background)
                .HasForeignKey(x => x.BackgroundId);
            
            modelBuilder.Entity<Background>()
                .HasMany(x => x.Equipment)
                .WithMany(x => x.Backgrounds);
            
            modelBuilder.Entity<Background>()
                .HasMany(x => x.Features)
                .WithOne(x => x.Background)
                .HasForeignKey(x => x.BackgroundId);            
            
            modelBuilder.Entity<Character>()
                .HasMany(x => x.Proficiencies)
                .WithMany(x => x.Characters);        
            
            modelBuilder.Entity<Character>()
                .HasMany(x => x.Abilities)
                .WithMany(x => x.Characters);        
            
            modelBuilder.Entity<Character>()
                .HasOne(x => x.Class)
                .WithMany(x => x.Characters)
                .HasForeignKey(x => x.ClassId);        
            
            modelBuilder.Entity<Character>()
                .HasMany(x => x.Items)
                .WithMany(x => x.Characters);        
            
            modelBuilder.Entity<Character>()
                .HasOne(x => x.Race)
                .WithMany(x => x.Characters)
                .HasForeignKey(x => x.RaceId);

            modelBuilder.Entity<Character>()
                .HasMany(x => x.Proficiencies)
                .WithMany(x => x.Characters);

            modelBuilder.Entity<Class>()
                .HasMany(x => x.StartEquipment)
                .WithMany(x => x.Classes);

            modelBuilder.Entity<Class>()
                .HasMany(x => x.StartEquipment)
                .WithMany(x => x.Classes);

            modelBuilder.Entity<Class>()
                .HasMany(x => x.StartEquipmentChoices)
                .WithMany(x => x.Classes);

            modelBuilder.Entity<Class>()
                .HasMany(x => x.Proficiencies)
                .WithMany(x => x.Classs);

            modelBuilder.Entity<Class>()
                .HasMany(x => x.ClassSpecificFeatures)
                .WithOne(x => x.Class)
                .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<Item>()
                .HasMany(x => x.ItemChoices)
                .WithMany(x => x.Items);

            modelBuilder.Entity<Proficiency>()
                .HasMany(x => x.Races)
                .WithMany(x => x.Proficiencies);

            modelBuilder.Entity<Race>()
                .HasMany(x => x.AbilityScoreIncreases)
                .WithOne(x => x.Race)
                .HasForeignKey(x => x.RaceId);

            modelBuilder.Entity<Race>()
                .HasMany(x => x.RaceFeatures)
                .WithOne(x => x.Race)
                .HasForeignKey(x => x.RaceId);

        }
    }
}
