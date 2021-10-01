using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace iread_story.DataAccess.Data.Entity
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int LanguageId { get; set; }

        public bool Active { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }
}