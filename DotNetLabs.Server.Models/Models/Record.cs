using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetLabs.Server.Models
{
    public abstract class Record
    {
        public Record()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }


    }

}
