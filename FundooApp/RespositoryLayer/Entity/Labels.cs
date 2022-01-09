using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RespositoryLayer.Entity
{
    public class Labels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LableId { get; set; }

        [ForeignKey("NotesTable")]
        public long NotesId { get; set; }
        public Notes Notes { get; set; }

        [ForeignKey("Users")]
        public long Id { get; set; }
        public User User { get; set; }
        public string Label { get; set; }
    }
}
