using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteCreate
    {
        [Required]
        [MinLength(2,ErrorMessage ="More than 2 characters, please.")]
        [MaxLength(100,ErrorMessage ="Oh come on, really? That's way too many characters!")]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }
    }
}
