using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLabs.Server.Models
{
    public abstract class UserRecord : Record
    {
        public UserRecord()
        {
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;

        }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public virtual ApplicationUser CreateByUser { get; set; }
        //Foreing Key
        [ForeignKey(nameof(CreateByUser))]
        public string CreateByUserId { get; set; }

        public virtual ApplicationUser ModifiedByUser { get; set; }

        [ForeignKey(nameof(ModifiedByUser))]
        public string ModifiedByUserId { get; set; }
    }

}
