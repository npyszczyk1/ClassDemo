using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Data.POCOs;

namespace Chinook.Data.DTOs
{
    public class GenreDto
    {
        public string genre { get; set; }
        public IEnumerable<AlbumDto> albums { get; set; }
    }
}
