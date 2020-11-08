using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models

{
    public class AlbumInfo
    {

        public string genre {get; set;}

        public Album album {get; set;}


    }
}