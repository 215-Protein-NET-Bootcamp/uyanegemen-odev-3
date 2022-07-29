using OdevApi.Base.Request;
using OdevApi.Base.Response;
using OdevApi.Data.Model;
using OdevApi.Dto;

namespace OdevApi.Service.Abstract
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
        Task<BaseResponse<AccountDto>> SelfUpdateAsync(int id, AccountDto resource);
        Task<BaseResponse<AccountDto>> UpdatePasswordAsync(int id, UpdatePasswordRequest resource);
    }
}
