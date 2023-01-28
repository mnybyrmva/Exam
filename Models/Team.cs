using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public string? ImageUrl { get; set; }
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }
        [StringLength(maximumLength: 100)]
        public string Linkedin { get; set; }
        [StringLength(maximumLength: 100)]
        public string Facebook { get; set; }
        [StringLength(maximumLength: 100)]
        public string Twitter { get; set; }
        public Profession? Profession { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }



    }
}
