namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        [Display(Name = "Content URL")]
        public string ContentUrl { get; set; }

        [Required]
        [Display(Name = "Content Type")]
        public FileType FileType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}