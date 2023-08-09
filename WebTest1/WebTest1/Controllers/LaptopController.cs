using Microsoft.AspNetCore.Mvc;
using WebTest1.Interface;
using WebTest1.Models;

namespace WebTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController:Controller
    {
        ILaptopRepository _laptopRepository;
        public LaptopController(ILaptopRepository laptopRepository) 
        {
            _laptopRepository = laptopRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLaptops()
        {
            var laptops = await _laptopRepository.GetLaptops();
            if(laptops == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(laptops);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLaptop(int id)
        {
            var laptop = await _laptopRepository.GetLaptop(id);
            if(laptop == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(laptop);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetLaptopByName(string name)
        {
            var laptop = await _laptopRepository.GetLaptopByName(name);
            if (laptop == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(laptop);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLaptop(Laptop laptop)
        {
            if(laptop == null)
            {
                return BadRequest(ModelState);
            }
            await _laptopRepository.CreateLaptop(laptop);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Laptop Created Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLaptop(int id,Laptop laptop)
        {
            if (laptop == null || laptop.Id!=id)
            {
                return BadRequest(ModelState);
            }
            await _laptopRepository.UpdateLaptop(laptop);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Laptop Updated Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLaptop(int id)
        {
            var laptop = await _laptopRepository.GetLaptop(id);
            if (laptop == null)
            {
                return BadRequest(ModelState);
            }
            await _laptopRepository.DeleteLaptop(laptop);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Laptop Deleted Successfully");
        }
    }
}
