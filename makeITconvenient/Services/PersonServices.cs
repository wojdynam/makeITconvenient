using AutoMapper;
using ComponentModules.BaseModule;
using ComponentModules.Interfaces;
using makeITconvenient.Models;
using makeITconvenient.Services.Interfaces;

namespace makeITconvenient.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonServices(IPersonRepository personRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonDto> AddAsync(PersonDto personDto)
        {
           var person = _mapper.Map<PersonDto,Person>(personDto);
            await _personRepository.CreateAsync(person);
           
            return personDto;
        }

        public async Task<PersonDto> DetailsAsync(int id)
        {
            var result = await _personRepository.ReadAsync(id);
            if (result!=null)
            {
                var personDto = _mapper.Map<Person, PersonDto>(result);
                return personDto;
            }
            return null;
        }


        public async Task<PersonDto> EditAsync(PersonDto personDto)
        {
            var result = _mapper.Map<PersonDto, Person>(personDto);
            await _personRepository.UpdateAsync(result);
            //throw new NotImplementedException();
            return null;
        }

       

        public async Task RemoveAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
            
        }

        

        public async Task<IEnumerable<PersonDto>> SearchAsync(string name)
        {
            var result = await _personRepository.GetByNameAsync(name);
            var PersonList = new List<PersonDto>();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    PersonList.Add(_mapper.Map<Person, PersonDto>(item));
                }
            }
            return (PersonList);
        }

        
    }
}
