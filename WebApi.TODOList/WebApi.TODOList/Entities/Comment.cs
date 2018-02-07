using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.TODOList.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedComment { get; set; }

        [MinLength(10)]
        [MaxLength(250)]
        [Required]
        public string CommentMessage { get; set; }

        [ForeignKey("TodoId")]
        public Todo Todo { get; set; }

        public int TodoId { get; set; }
    }
}