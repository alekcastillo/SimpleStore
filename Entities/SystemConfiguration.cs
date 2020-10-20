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
        public Guid Id { get; private set; }
        public string BooksSavePath { get; private set; }
        public string BookPreviewsSavePath { get; private set; }
        public string SongsSavePath { get; private set; }
        public string SongPreviewsSavePath { get; private set; }
        public string MoviesSavePath { get; private set; }
        public string MoviePreviewsSavePath { get; private set; }
    }
}
