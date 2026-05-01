using AutoMapper;
using BankApp.Api.DTOs;
using BankApp.Api.Exceptions;
using BankApp.Api.Interfaces;
using BankApp.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BankApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public BankAccountController(IBankAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBankAccountDto dto)
        {
            var account = _mapper.Map<BankAccountEntity>(dto);
            var created = await _accountRepository.CreateAsync(account);
            created.AccountNumber = $"DE{DateTime.Now.Year}{created.Id.ToString("D8")}";
            await _accountRepository.UpdateAsync(created);
            var createdDto =  _mapper.Map<BankAccountDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _accountRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<BankAccountDto>>(getAll);
            
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getById = await _accountRepository.GetByIdAsync(id);
            
            if (getById == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<BankAccountDto>(getById);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]BankAccountDto dto)
        {
            var account = _mapper.Map<BankAccountEntity>(dto);
            account.Id = id;

            try
            {
                var updated = await _accountRepository.UpdateAsync(account);
                var updatedDto = _mapper.Map<BankAccountDto>(updated);
                return Ok(updatedDto);
            }
            catch(AccountNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _accountRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
