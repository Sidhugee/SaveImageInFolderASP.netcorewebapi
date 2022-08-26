using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactProjectGym.Model
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string About { get; set; }

        [Required]
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
    }
}
