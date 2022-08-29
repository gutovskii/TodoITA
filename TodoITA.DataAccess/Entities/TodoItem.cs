using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TodoITA.DataAccess.Entities
{
    public class TodoItem : IEntity
    {
        public int Id { get; set; }

        [Required]   
        [MaxLength(50)]
        public string Text { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public bool IsDone { get; set; } = false;

        [Required]
        public TodoCategory TodoCategory { get; set; }

        public int TodoCategoryId { get; set; }
    }
}
