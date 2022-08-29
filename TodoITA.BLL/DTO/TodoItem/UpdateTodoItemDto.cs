using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TodoITA.BLL.DTO.TodoItem
{
    public class UpdateTodoItemDto
    {
        [MaxLength(50, ErrorMessage = "Довжина завдання має бути до 50 символів")]
        public string Text { get; set; }

        [MaxLength(100, ErrorMessage = "Довжина опису має бути до 100 символів")]
        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
