using makeITconvenient.Models;
using makeITconvenient.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace makeITconvenient.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices)
        {
            _personServices = personServices;
        }

        [HttpGet]
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
                ViewBag.Success = "Dane zostaly poprawnie zapisane";
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult PersonSearch(string name) => View(name);
        [HttpGet]
        public async Task<IActionResult>SearchPersonResult(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("PersonSearch");
            }
            var personDtoList = await _personServices.SearchAsync(name);
            if (personDtoList.Any())
            {
                return View(personDtoList);
            }
            return RedirectToAction(nameof(PersonSearch), new {value =name});
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
            //var result = _personServices.S
            return View();
        }
    }
}
