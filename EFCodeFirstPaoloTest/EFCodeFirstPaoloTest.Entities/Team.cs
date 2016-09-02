using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstPaoloTest.Entities
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }
        [Required]
        [DisplayName("team name")]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }

        public virtual ICollection<Player> Players  { get; set; }
    }
}
