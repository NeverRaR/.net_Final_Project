using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("favorite_has_work")]
    public class FavoriteHasWork
    {
        public int WorkId { get; set; }
        public int FavoriteId { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
    }
}
