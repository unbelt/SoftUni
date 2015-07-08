namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Resource Type")]
        public ResourceType ResourceTypes { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string Link { get; set; }
    }
}