using OdevApi.Base.Response;
using OdevApi.Data.Model;
using OdevApi.Dto;

namespace OdevApi.Service.Abstract
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
        Task<PaginationResponse<IEnumerable<PersonDto>>> GetPaginationAsync(QueryResource pagination, PersonDto filterResource);
    }
}
