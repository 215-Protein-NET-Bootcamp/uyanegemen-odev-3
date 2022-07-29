using OdevApi.Base.Response;
using OdevApi.Data.Model;
using OdevApi.Dto;

namespace OdevApi.Data.Repository.Abstract
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<(IEnumerable<Person> records, int total)> GetPaginationAsync(QueryResource pagination, PersonDto filterResource);
        Task<int> TotalRecordAsync();
    }
}
