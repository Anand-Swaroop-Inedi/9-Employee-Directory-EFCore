using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Department")]
        public string Department { get; set; }
        [ForeignKey("Location")]
        public string Location { get; set; }
        [AllowNull]
        public string Description { get; set; }
    }
}
