using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.CustomActionFilters;
using Registration.Models.Domain;
using Registration.Models.DTO;
using Registration.Repositories;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
        {
            var userDomainModel = mapper.Map<User>(addUserRequestDto);

            await userRepository.CreateAsync(userDomainModel);

            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userDomainModel = await userRepository.GetAllAsync();

            return Ok(mapper.Map<List<UserDto>>(userDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomainModel = await userRepository.GetByIdAsync(id);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateUserRequestDto updateUserRequestDto)
        {
            var userDomainModel = mapper.Map<User>(updateUserRequestDto);

            userDomainModel = await userRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedUserDomainModel = await userRepository.DeleteAsync(id);

            if (deletedUserDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(deletedUserDomainModel));
        }

        [HttpGet("check-username/{username}")]
        public async Task<IActionResult> CheckUsernameUniqueness(string username)
        {
            var isUnique = await userRepository.IsUsernameUnique(username);
            return Ok(isUnique);
        }
    }
}
