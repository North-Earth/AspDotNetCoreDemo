using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Learn.Models.Models
{
    //[Bind("Name")]  // Возможность привязки целой модели.
    public class User
    {
        public int Id { get; set; }

        //[BindRequired] // Атрибут требует обязательного наличия значения для свойства модели.
        [BindingBehavior(BindingBehavior.Required)] // Required: аналогично примению атрибута BindRequired
        public string Name { get; set; }

        [BindingBehavior(BindingBehavior.Optional)] // Optional: действие по умолчанию, мы можем передавать значение, 
                                                    // а можем и не передавать, тогда будут применяться значения по умолчанию
        public int Age { get; set; }

        //[BindNever] // Атрибут указывает, что свойство модели надо исключить из механизма привязки.
        [BindingBehavior(BindingBehavior.Never)] // Never: аналогично примению атрибута BindNever
        public bool HasRight { get; set; }
    }

    public class SecondUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
