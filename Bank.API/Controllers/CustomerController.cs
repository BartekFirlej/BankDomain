using Bank.API.DTOs;
using Bank.Application.Requests;
using Bank.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid customer ID.");

        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound($"Customer with ID {id} not found.");

        var response = new CustomerResponseDto
        {
            ID = customer.ID,
            Email = customer.ContactData.EmailAddress,
            PhoneNumber = customer.ContactData.PhoneNumber,
            FirstName = customer.PersonalData.FirstName,
            LastName = customer.PersonalData.LastName,
            AddressId = customer.AddressId,
            RegistrationDate = customer.RegistrationDateTime
        };

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterCustomer([FromBody] CreateCustomerDTO customerDto)
    {
        var request = new CreateCustomerRequest(
            customerDto.Email, 
            customerDto.PhoneNumber, 
            customerDto.FirstName,
            customerDto.SecondName, 
            customerDto.LastName,
            customerDto.BirthDate,
            customerDto.AddressId);
        var customer = await _customerService.RegisterCustomerAsync(request);
        var response = new CustomerResponseDto
        {
            ID = customer.ID,
            Email = customer.ContactData.EmailAddress,
            PhoneNumber = customer.ContactData.PhoneNumber,
            FirstName = customer.PersonalData.FirstName,
            LastName = customer.PersonalData.LastName,
            AddressId = customer.AddressId,
            RegistrationDate = customer.RegistrationDateTime,
            RegistrationStatus = customer.RegistrationStatus
        };
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.ID }, response);
    }

    [HttpPut("{customerId}/change-address")]
    public async Task<IActionResult> ChangeCustomerAddress(int customerId, [FromBody] ChangeAddressDTO dto)
    {
        if (customerId <= 0 || customerId != dto.CustomerID)
            return BadRequest("Invalid Customer ID.");

        if (dto == null)
            return BadRequest("Request body cannot be null.");
        var request = new ChangeAddressRequest(dto.CustomerID, dto.Street, dto.City, dto.PostalCode, dto.Country, dto.Number);
        try
        {
            await _customerService.ChangeCustomerAddressAsync(request);
            return Ok($"Customer {customerId} address updated successfully.");
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
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
