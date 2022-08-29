using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TodoITA.BLL.DTO.TodoCategory
{
    public class CreateTodoCategoryDto
    {
        [Required(ErrorMessage = "Укажіть назву категорії")]
        [MaxLength(30, ErrorMessage = "Довжина категорії має бути до 30 символів")]
        public string Title { get; set; }
    }
}
