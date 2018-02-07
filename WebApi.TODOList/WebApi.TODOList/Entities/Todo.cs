using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.TODOList.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EditedDate { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
