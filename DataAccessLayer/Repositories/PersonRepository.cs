using ComponentModules.BaseModule;
using ComponentModules.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;

namespace DataAccessLayer.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreateAsync(Person entity)
        {
           await _context.Persons.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public   async Task DeleteAsync(int id)
        {
            var result = await _context.Persons.FindAsync(id);
            if(result != null)
            {
                _context.Persons.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        

        public async Task<Person> GetById(int id)
        {
            var result = await _context.Persons.FindAsync(id);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetByNameAsync(string name)
        {
            //throw new NotImplementedException();

            var result =await _context.Persons.Where(p => p.FirstName == name).ToListAsync();
            return result;
        }

        public async Task<Person> ReadAsync(int id)
        {
            //var result = await _context.Persons.Include(p =>p.ContactDetails).Include(p=>p.AddressList).FirstOrDefaultAsync(p=>p.PersonId ==id);
            var result = await _context.Persons.Include(p => p.ContactDetails).Include(p => p.AddressList).FirstOrDefaultAsync(p => p.PersonId == id);
            return result;
        }

        public async Task UpdateAsync(Person person)
        {
            var result =  _context.Persons.Update(person);
            await _context.SaveChangesAsync();
           // throw new NotImplementedException();
        }
    }
}
