using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя пользователя")]
        public string Name { get; set; }

        [Range(1, 119, ErrorMessage = "Возвраст должен быть в промежутке от 1 до 119")]
        [Required(ErrorMessage = "Укажите возраст пользователя")]
        public int Age { get; set; }
    }
}
