using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMongoRepository<Users> _mongoRepository;

        public UsersController(IMongoRepository<Users> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }


        [HttpPost]
        public IActionResult Register([FromBody] Users user)
        {
            // Validate the user object using data annotations
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(user, null, null);
            if (!Validator.TryValidateObject(user, validationContext, validationResults, true))
            {
                var errorMessages = validationResults.Select(result => result.ErrorMessage);
                return BadRequest(errorMessages);
            }

            try
            {
                // Insert the user into the MongoDB collection using the injected MongoRepository
                _mongoRepository.Insert(user);
            }

            catch (Exception ex)
            {
                // Handle generic exceptions
                return StatusCode(500, $"An error occurred while registering the user: {ex.Message}");
            }

            return Ok("User registered successfully!");
        }

        [HttpPost]
        public IActionResult RegisterMany([FromBody] IEnumerable<Users> users)
        {
            // Add validation and error handling as needed

            // Insert multiple users into the MongoDB collection using the injected MongoRepository
            _mongoRepository.InsertMany(users);

            return Ok("Users registered successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            // Retrieve a user from the MongoDB collection using the injected MongoRepository
            var user = _mongoRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            // Retrieve all users from the MongoDB collection using the injected MongoRepository
            var users = _mongoRepository.GetAll();
            return Ok(users);
        }
    }
}
