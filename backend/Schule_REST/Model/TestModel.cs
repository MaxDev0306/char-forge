using System.ComponentModel.DataAnnotations.Schema;

namespace Schule_REST.Model
{
    [Table("test_model")]
    public class TestModel
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
