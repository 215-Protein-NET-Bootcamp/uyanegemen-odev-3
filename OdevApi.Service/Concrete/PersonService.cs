using AutoMapper;
using OdevApi.Base.Execption;
using OdevApi.Base.Extension;
using OdevApi.Base.Response;
using OdevApi.Data;
using OdevApi.Data.Model;
using OdevApi.Data.Repository.Abstract;
using OdevApi.Dto;
using OdevApi.Service.Abstract;

namespace OdevApi.Service.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        public PersonService(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(personRepository, mapper, unitOfWork)
        {
            this.personRepository = personRepository;
        }

        private readonly IPersonRepository personRepository;


        public override async Task<BaseResponse<PersonDto>> InsertAsync(PersonDto createPersonResource)
        {
            try
            {
                // Mapping Resource to Person
                var person = Mapper.Map<PersonDto, Person>(createPersonResource);
                person.CreatedAt = DateTime.UtcNow;


                await personRepository.InsertAsync(person);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Person, PersonDto>(person);

                return new BaseResponse<PersonDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Person_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<PersonDto>> UpdateAsync(int id, PersonDto request)
        {
            try
            {
                // Validate Id is existent
                var person = await personRepository.GetByIdAsync(id);
                if (person is null)
                {
                    return new BaseResponse<PersonDto>("Person_Id_NoData");
                }

                person.FirstName = request.FirstName;
                person.LastName = request.LastName;
                person.DateOfBirth = request.DateOfBirth;
                person.Description = request.Description;

                personRepository.Update(person);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<PersonDto>(Mapper.Map<Person, PersonDto>(person));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Person_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<PersonDto>> GetByIdAsync(int id)
        {
            var person = await personRepository.GetByIdAsync(id);

            // Mapping
            var personResource = Mapper.Map<Person, PersonDto>(person);

            // 
            return new BaseResponse<PersonDto>(personResource);
        }


        public async Task<PaginationResponse<IEnumerable<PersonDto>>> GetPaginationAsync(QueryResource pagination, PersonDto filterResource)
        {
            var paginationPerson = await personRepository.GetPaginationAsync(pagination, filterResource);

            // Mapping
            var tempResource = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(paginationPerson.records);

            var resource = new PaginationResponse<IEnumerable<PersonDto>>(tempResource);

            // Using extension-method for pagination
            resource.CreatePaginationResponse(pagination, paginationPerson.total);

            return resource;
        }


    }
}
