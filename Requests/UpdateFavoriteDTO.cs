using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Requests
{
    public class UpdateFavoriteDTO
    {
        public int FavoriteId { get; set; }
        public String FavoriteName { get; set; }
    }
}
