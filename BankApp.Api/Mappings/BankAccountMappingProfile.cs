using AutoMapper;
using BankApp.Api.DTOs;
using BankApp.Api.Models;
namespace BankApp.Api.Mappings
{
    public class BankAccountMappingProfile : Profile 
    {
        public BankAccountMappingProfile()
        {
            CreateMap<CreateBankAccountDto, BankAccountEntity>();
            CreateMap<BankAccountEntity, BankAccountDto>();
            CreateMap<BankAccountDto, BankAccountEntity>();
        }
    }
}
