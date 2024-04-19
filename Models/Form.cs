using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Hull.Models
{
    public class Form
    {
        //set the attributes of the Form class
        [Key]
        [Required]
        public int MovieId { get; set;  }

        [ForeignKey("CategoryId")] //CategoryId
        public int? CategoryId { get; set; }
        public Category? CategoryName { get; set; } //CategoryName
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Edited is required!")]
        public int Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Copied To Plex is required!")]
        public int CopiedToPlex { get; set; }
        [StringLength(25, ErrorMessage = "Notes cannot be more than 25 charachters")]
        public string? Notes { get; set; }
}
}
