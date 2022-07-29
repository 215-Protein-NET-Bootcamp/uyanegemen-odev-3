using OdevApi.Base.Request;
using OdevApi.Base.Response;

namespace OdevApi.Service.Abstract
{
    public interface ITokenManagementService
    {
        public interface ITokenManagementService
        {
            Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
        }
    }
}
