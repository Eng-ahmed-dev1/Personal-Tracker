using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Trackeer.Model
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [MaxLength(80)]
        [Required]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public ICollection<Visa> Visas { get; set; } = new List<Visa>();
    }
}