using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Trackeer.Model
{
    public class Visa
    {
        [Key]   
        public int Code { get; set; }
        [Required]
        public int Password { get; set; }

        [ForeignKey(nameof(User))]
        public int User_id { get; set; }
        public Users User { get; set; }
    }
}