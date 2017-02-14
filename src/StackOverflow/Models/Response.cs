using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
    [Table("Responses")]
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
