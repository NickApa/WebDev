using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models

{
    public class Search 
    {
        [Required(ErrorMessage = "Please search for atleast 2 characters")] 
        [MinLength(2)]
        public string nameSearch {get; set;}

        public IEnumerable<Artist> ArtistList {get; set;}

        public int ArtistID {get; set;}

        public string ArtistName {get; set;}

        public List<AlbumInfo> Albums {get; set;} 

    }
}