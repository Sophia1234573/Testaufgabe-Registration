using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Registration.CustomActionFilters;
using Registration.Data;
using Registration.Models.Domain;
using Registration.Models.DTO;
using Registration.Repositories;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly RegistrationDbContext dbContext;
        private readonly IBranchRepository branchRepository;
        private readonly IMapper mapper;
        public BranchesController(RegistrationDbContext dbContext, IBranchRepository branchRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.branchRepository = branchRepository;
            this.mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branchesDomain = await branchRepository.GetAllAsync();         

            return Ok(mapper.Map<List<BranchDto>>(branchesDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {       
            var branchDomain = await branchRepository.GetByIdAsync(id);

            if (branchDomain == null)
            {
                return NotFound();
            }
                   
            return Ok(mapper.Map<BranchDto>(branchDomain));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddBranchRequestDto addBranchRequestDto)
        {
            var branchDomainModel = mapper.Map<Branch>(addBranchRequestDto);

            branchDomainModel = await branchRepository.CreateAsync(branchDomainModel);

            var branchDto = mapper.Map<BranchDto>(branchDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = branchDto.Id }, branchDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBranchRequestDto updateBranchRequestDto)
        {
            var branchDomainModel = mapper.Map<Branch>(updateBranchRequestDto);

            branchDomainModel = await branchRepository.UpdateAsync(id, branchDomainModel);

            if (branchDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BranchDto>(branchDomainModel));            
        } 

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            var branchDomainModel = await branchRepository.DeleteAsync(id);

            if (branchDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BranchDto>(branchDomainModel));
        }
    }
}
