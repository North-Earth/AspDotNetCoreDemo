using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersContext db;

        public UsersController(UsersContext usersContext)
            => db = usersContext;

        // GET api/users
        [HttpGet]
        [FormatFilter] //Атрибут форматирования.
        public IEnumerable<User> Get()
            => db.Users.ToList();

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                ModelState.AddModelError("", "Не указаны данные для пользователя");
                return BadRequest(ModelState);
            }

            // Обработка частных случаев валидации.
            if (user.Age == 111)
                ModelState.AddModelError("Age", $"Возраст не должен быть равен {user.Age}");

            if (user.Name == "admin")
                ModelState.AddModelError("Name", $"Недопустимое имя пользователя - {user.Name}");

            // Eсли валидация не пройдена - возвращаем ошибку 400.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Иначе, сохраняем в базу данных.
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null)
                return BadRequest();

            if (!db.Users.Any(x => x.Id == user.Id))
                return NotFound();

            db.Update(user);
            db.SaveChanges();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}