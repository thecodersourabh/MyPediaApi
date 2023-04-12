using Microsoft.AspNetCore.Mvc;
using MyPediya.Services;
using System.Globalization;

namespace MyPediaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamily _myFamily;

        public FamilyController(IFamily myFamily)
        {
            _myFamily = myFamily;

            Person dad = new Person("John", "Male", new DateTime().ToUniversalTime().ToString(CultureInfo.InvariantCulture), Guid.Empty);
            Person mom = new Person("Jane", "Female", new DateTime().ToUniversalTime().ToString(CultureInfo.InvariantCulture), Guid.Empty);

            Person son = new Person("Tom", "Male", new DateTime().ToUniversalTime().ToString(CultureInfo.InvariantCulture), dad.Id);
            Person daughter = new Person("Samantha", "Female", new DateTime().ToUniversalTime().ToString(CultureInfo.InvariantCulture), dad.Id);

            dad.AddChild(son);
            dad.AddChild(daughter);
            _myFamily.AddMember(dad);
            _myFamily.AddMember(mom);
            _myFamily.AddMember(son);
            _myFamily.AddMember(daughter);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_myFamily.GetMembers());
        }

        [HttpGet("{name}")]
        public ActionResult<Person> Get(string name)
        {
            foreach (Person member in _myFamily.GetMembers())
            {
                if (member.Name == name)
                {
                    return member;
                }
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            _myFamily.AddMember(person);
            return CreatedAtAction(nameof(Get), new { name = person.Name }, person);
        }

        [HttpPost("{parentName}/child")]
        public ActionResult Post(string parentName, Person child)
        {
            foreach (Person member in _myFamily.GetMembers())
            {
                if (member.Name == parentName)
                {
                    member.AddChild(child);
                    _myFamily.AddMember(child);
                    return CreatedAtAction(nameof(Get), new { name = child.Name }, child);
                }
            }

            return NotFound();
        }
    }
}

