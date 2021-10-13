using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace iread_story.DataAccess.Data.Entity
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int LanguageId { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Story> Stories { get; set; }

    }
}