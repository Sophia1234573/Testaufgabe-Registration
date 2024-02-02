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
    public class CompaniesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public CompaniesController(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        [HttpPost]
        [ValidateModel]
    //    [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddCompanyRequestDto addCompanyRequestDto)
        {
            var companyDomainModel = mapper.Map<Company>(addCompanyRequestDto);

            await companyRepository.CreateAsync(companyDomainModel);

            return Ok(mapper.Map<CompanyDto>(companyDomainModel));
        }

        [HttpGet]
      //  [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var companyDomainModel = await companyRepository.GetAllAsync();

            return Ok(mapper.Map<List<CompanyDto>>(companyDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
     //   [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var companyDomainModel = await companyRepository.GetByIdAsync(id);

            if (companyDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CompanyDto>(companyDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
     //   [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateCompanyRequestDto updateCompanyRequestDto)
        {
            var companyDomainModel = mapper.Map<Company>(updateCompanyRequestDto);

            companyDomainModel = await companyRepository.UpdateAsync(id, companyDomainModel);

            if (companyDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CompanyDto>(companyDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
     //   [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedCompanyDomainModel = await companyRepository.DeleteAsync(id);

            if (deletedCompanyDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CompanyDto>(deletedCompanyDomainModel));
        }
    }
}
