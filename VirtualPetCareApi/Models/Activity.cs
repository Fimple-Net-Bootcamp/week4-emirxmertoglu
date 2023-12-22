using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCareApi.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [ForeignKey("PetId")]
        public int? PetId { get; set; }
        public Pet? Pet { get; set; }
    }
}
