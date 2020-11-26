using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Entities
{
    // Requirement 4.4.2
    // ( This is obviously not the best way to handle system configs
    // But the project's requirements specified it this way )
    public class SystemConfiguration : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string BooksSavePath { get; set; }
        public string BookPreviewsSavePath { get; set; }
        public string SongsSavePath { get; set; }
        public string SongsPreviewsSavePath { get; set; }
        public string MoviesSavePath { get; set; }
        public string MoviePreviewsSavePath { get; set; }
    }
}
