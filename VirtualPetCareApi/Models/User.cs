using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        public ICollection<Pet>? Pets { get; set; }
    }
}
