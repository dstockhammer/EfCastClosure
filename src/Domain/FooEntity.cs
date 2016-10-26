using System.ComponentModel.DataAnnotations;

namespace EfCastClosure.Domain
{
    public class FooEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string String { get; set; }
    }
}