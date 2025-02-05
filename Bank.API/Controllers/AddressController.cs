using Microsoft.AspNetCore.Mvc;
using Bank.Application.ServiceInterfaces;
using Bank.Application.Requests;
using Bank.API.DTOs;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid address ID.");

            try
            {
                var address = await _addressService.GetAddressByIdAsync(id);
                return Ok(address);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressDTO addressDTO)
        {
            if (addressDTO == null)
                return BadRequest("Request body cannot be null.");
            try
            {
                var request = new CreateAddressRequest(addressDTO.Street, addressDTO.City, addressDTO.PostalCode, addressDTO.Country, addressDTO.Number);
                var address = await _addressService.CreateAddressAsync(request);
                return CreatedAtAction(nameof(GetAddressById), new { id = address.ID }, address);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
