using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("favorite")]
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        public String Name { get; set; }

        public User User { get; set; }

        [ForeignKey("FavoriteId")]
        public List<FavoriteHasWork> FavoriteHasWorks { get; set; }
    }
}
