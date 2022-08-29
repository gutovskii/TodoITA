using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoITA.DataAccess.Entities
{
    public class TodoCategory : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}
