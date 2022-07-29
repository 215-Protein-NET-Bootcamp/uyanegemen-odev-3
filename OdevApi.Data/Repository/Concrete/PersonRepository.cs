using Microsoft.EntityFrameworkCore;
using OdevApi.Base.Extension;
using OdevApi.Base.Response;
using OdevApi.Data.Context;
using OdevApi.Data.Model;
using OdevApi.Data.Repository.Abstract;
using OdevApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevApi.Data.Repository.Concrete
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IEnumerable<Person> records, int total)> GetPaginationAsync(QueryResource pagination, PersonDto filterResource)
        {
            var queryable = ConditionFilter(filterResource);

            var total = await queryable.CountAsync();

            var records = await queryable.AsNoTracking()
                .AsSplitQuery()
                .OrderByDescending(x => x.AccountId)
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return (records, total);
        }

        private IQueryable<Person> ConditionFilter(PersonDto filterResource)
        {
            var queryable = Context.Person.AsQueryable();

            if (filterResource != null)
            {
                if (!string.IsNullOrEmpty(filterResource.AccountId.ToString()))
                    queryable = queryable.Where(x => x.AccountId.ToString().Contains(filterResource.AccountId.ToString().RemoveSpaceCharacter()));

                if (!string.IsNullOrEmpty(filterResource.FirstName))
                {
                    string fullName = filterResource.FirstName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.FirstName.Contains(fullName));
                }

                if (!string.IsNullOrEmpty(filterResource.LastName))
                {
                    string fullName = filterResource.LastName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.LastName.Contains(fullName));
                }
            }

            return queryable;
        }
        public override async Task<Person> GetByIdAsync(int id)
        {
            return await Context.Person.AsSplitQuery().SingleOrDefaultAsync(x => x.AccountId == id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.Person.CountAsync();
        }
    }
}
