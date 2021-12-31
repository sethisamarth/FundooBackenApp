using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RespositoryLayer.Entity
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NotesId { get; set; }
        public User User { get; set; }

        [ForeignKey("Users")]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime Remainder { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public bool IsPin { get; set; }
        [Required]
        public bool IsTrash { get; set; }

        public DateTime? Createdat { get; set; }

        public DateTime? Modifiedat { get; set; }
    }
}
