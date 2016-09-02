using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstPaoloTest.Entities
{
    public class Player
    {
        public Player()
        {
            
        }

        [Key]
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "Player name is required")]
        [DisplayName("player name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Player surname is required")]
        [DisplayName("player surname")]
        public string Surname { get; set; }

        public decimal? Height { get; set; }
        public float? Weight { get; set; }

        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}
