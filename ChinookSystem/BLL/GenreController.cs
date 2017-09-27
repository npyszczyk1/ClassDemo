using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Chinook.Data.Entities;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using Chinook.Data.DTOs;

namespace ChinookSystem.BLL
{
    [DataObject]
    public class GenreController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<GenreDto> Genre_GenreAlbumTracks()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Genres
                              select new GenreDto
                              {
                                  genre = x.Name,
                                  albums = from y in x.Tracks
                                           group y by y.Album into gResults
                                           select new AlbumDto
                                           {
                                               title = gResults.Key.Title,
                                               releaseYear = gResults.Key.ReleaseYear,
                                               numberOfTracks = gResults.Count(),
                                               tracks = from z in gResults
                                                        select new TrackPoco
                                                        {
                                                            song = z.Name,
                                                            milliseconds = z.Milliseconds
                                                        }
                                           }
                              };
                return results.ToList();
            }
        }
    }
}
