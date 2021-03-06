using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models
{
    [Table("Playlist")]
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        [Key]
        public int PlaylistId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

        [InverseProperty(nameof(PlaylistTrack.Playlist))]
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
