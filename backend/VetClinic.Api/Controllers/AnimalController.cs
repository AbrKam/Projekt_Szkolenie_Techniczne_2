using Microsoft.AspNetCore.Mvc;
using VetClinic.Infrastructure.Repositories;

namespace VetClinic.Api.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalRepository _animalRepository;
    }
}
