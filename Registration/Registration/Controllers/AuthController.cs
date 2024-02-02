using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registration.Models.Domain;
using Registration.Models.DTO;
using Registration.Repositories;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IBranchRepository branchRepository;
        public AuthController(UserManager<IdentityUser> userManager,
            ITokenRepository tokenRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            IBranchRepository branchRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.branchRepository = branchRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AddUserRequestDto addUserRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = addUserRequestDto.Username,
            };

            var identityResult = await userManager.CreateAsync(identityUser, addUserRequestDto.Password);

            if (identityResult.Succeeded)

            {
                string companyName = addUserRequestDto?.Company?.Name ?? "";
                string branchName = addUserRequestDto?.Company?.Branch?.Name ?? "";

                var companyDomainModel = await companyRepository.GetByCompanyAndBranchNameAsync(companyName, branchName);
                var branchDomainModel = await branchRepository.GetByNameAsync(branchName);

                if (branchDomainModel == null)
                {
                    return BadRequest($"Branch does not exist.");
                }

                if (companyDomainModel == null)
                {
                    companyDomainModel = new Company
                    {
                        Name = companyName,
                        BranchId = branchDomainModel.Id
                    };

                    companyDomainModel = await companyRepository.CreateAsync(companyDomainModel);
                }

                var userDomainModel = new User()
                {
                    FirstName = addUserRequestDto.FirstName,
                    LastName = addUserRequestDto.LastName,
                    Email = addUserRequestDto.Email,
                    Username = addUserRequestDto.Username,
                    Password = addUserRequestDto.Password,
                    CompanyId = companyDomainModel.Id     
                };

                userDomainModel = await userRepository.CreateAsync(userDomainModel);

                await userManager.AddToRoleAsync(identityUser, "Reader");

                return Ok(mapper.Map<UserDto>(userDomainModel));         
            }

            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByNameAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null) 
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or Password is incorrect");
        }
    }
}
