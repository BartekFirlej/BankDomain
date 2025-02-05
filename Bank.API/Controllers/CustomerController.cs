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

    [HttpPut("{customerId}/change-address/{newAddressId}")]
    public async Task<IActionResult> ChangeCustomerAddress(int customerId, int newAddressId)
    {
        if (customerId <= 0 || newAddressId <= 0)
            return BadRequest("Invalid Customer ID or Address ID.");

        await _customerService.ChangeCustomerAddressAsync(customerId, newAddressId);
        return Ok($"Customer {customerId} address updated successfully.");
    }
}
