using Chinook.Data.Entities;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

#region Additional Namespaces

#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ArtistAlbumsByReleaseYear> Albums_ByArtist(int artistid)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums // Make sure to add context
                              where x.ArtistId.Equals(artistid)
                              select new ArtistAlbumsByReleaseYear
                              {
                                  // Figure out return type, DTO or POCO
                                  // This is POCO cuz flat data types
                                  // Had to create new class in POCOs with properties matching below fields to map the results
                                  Title = x.Title,
                                  Released = x.ReleaseYear
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Album> Albums_FindByYearRange(int minYear, int maxYear)
        {
            using (var context = new ChinookContext())
            {
                // This is not POCO since we are returning everything in the Album entity
                var results = from x in context.Albums
                              where x.ReleaseYear >= minYear && x.ReleaseYear <= maxYear
                              orderby x.ReleaseYear, x.Title
                              select x;

                return results.ToList();
            }
        }
    }
}
