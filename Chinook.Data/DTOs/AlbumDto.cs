using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Data.POCOs;

namespace Chinook.Data.DTOs
{
    public class AlbumDto
    {
        public string title { get; set; }
        public int releaseYear { get; set; }
        public int numberOfTracks { get; set; }
        public IEnumerable<TrackPoco> tracks { get; set; }
    }
}
