using AutoMapper.API.DTO;
using AutoMapper.API.Entities;
using AutoMapper.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(_userRepository.GetAllUser());
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {

            return Ok(_userRepository.GetUserById(id));
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            return Ok(_userRepository.CreateUser(user));
        }


        [HttpGet("DTO")]
        public ActionResult<UserReadDto> GetDTO(Guid id)
        {

            //return Ok(_userRepository.GetUserById(id));
            var user = _userRepository.GetUserById(id);

            var userReadDto = new UserReadDto()
            {
                Email = user.Email,
                FullName = $"{user.FirstName} {user.LastName}",
                Age = HelperFunctions.HelperFunctions.GetCurrentAge(user.DateOfBirth)
            };
            return Ok(userReadDto);
        }


        [HttpGet("AutoMapper")]
        public ActionResult<UserReadDto> GetAutoMapper(Guid id)
        {

            //return Ok(_userRepository.GetUserById(id));
            var user = _userRepository.GetUserById(id);

            var userReadDto=_mapper.Map<UserReadDto>(user);
            return Ok(userReadDto);
        }

        [HttpGet(nameof(getallDTO))]
        public ActionResult<List<UserReadDto>> getallDTO() 
        {
            var all=_userRepository.GetAllUser();
            
            return Ok( _mapper.Map<List<UserReadDto>>(all));
        }

        [HttpPost("createUserFromDTO")]
        public ActionResult<User> createUserFromDTO(UserCreateDto u) 
        {
             User uu=   _mapper.Map<User>(u);

            return _userRepository.createUserfromDTO(uu);

            
        }

    }
}
