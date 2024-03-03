using makeITconvenient.InitialConf;
using makeITconvenient.Models;
using makeITconvenient.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Primitives;
using System.Reflection.Metadata;

namespace makeITconvenient.Controllers
{
    //[Authorize(Policy = "RequiredSuperAdmin")]
    public class PersonController : Controller
    {
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices)
        {
            _personServices = personServices;
        }
        
        [HttpGet]
        [ServiceFilter(typeof(RoleAuthorizationFilter))]
        public IActionResult AddPerson()
        {
            var personDto = new PersonDto();
            personDto.ContactDetails = new ContactDetailsDto();
            personDto.AddressList = new List<AddressDto>();
            for(int i =0; i<2; i++)
            {
                personDto.AddressList.Add(new AddressDto());
            }
            return View(personDto);
        }
        

        [HttpPost]
        public async Task<IActionResult>AddPerson(PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                await _personServices.AddAsync(personDto);
                ViewBag.Success = "Dane zostały poprawnie zapisane";
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult PersonSearch(string personName)
        {
            if (!string.IsNullOrEmpty(personName))
            {
                ViewBag.ErrorMessage = $"osoba: {personName} nie została znaleziona";
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult>SearchPersonResult(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction(nameof(PersonSearch));
            }
            var personDtoList = await _personServices.SearchAsync(name);
            if (personDtoList.Any())
            {
                return View(personDtoList);
            }
            return RedirectToAction(nameof(PersonSearch),new {personName = name });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _personServices.DetailsAsync(id);
            if (result.AddressList.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    result.AddressList.Add(new AddressDto());
                }
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var result =await  _personServices.DetailsAsync(id);
            if (result != null)
            {
                if (result.AddressList.Count == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        result.AddressList.Add(new AddressDto());
                    }
                }
                return View(result);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult>Edit(PersonDto personDto)
        
        {
            if (ModelState.IsValid)
            {
                await _personServices.EditAsync(personDto);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _personServices.RemoveAsync(id);
            return View();
        }
    }
}
