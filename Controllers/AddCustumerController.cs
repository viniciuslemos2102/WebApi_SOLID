using Domain.Contracts.UseCases.AddCustumer;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustumer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustumerController : ControllerBase
    {
        private readonly IAddCustumerUseCase _addCustumerUseCase;

        public AddCustumerController(IAddCustumerUseCase addCustumerUseCase)
        {
            _addCustumerUseCase = addCustumerUseCase;
        }

        [HttpPost]
        public IActionResult AddCustumer(AddCustumerInput input)
        {
            var custumer = new Domain.Entities.Custumer(input.Name, input.Email, input.Document);
            _addCustumerUseCase.AddCustumer(custumer);
            return Created("", custumer);

        }
    }
}
