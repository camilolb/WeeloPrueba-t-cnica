using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartamentService _departamentService;

        public DepartamentController(IDepartamentService departamentService)
        {
            _departamentService = departamentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var service = _departamentService.Gets();
                var response = new ApiResponse<IEnumerable<Departament>>(service);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var service = await _departamentService.Get(id);
                var response = new ApiResponse<Departament>(service);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post(Departament item)
        {
            try
            {
                await _departamentService.Insert(item);
                var response = new ApiResponse<Departament>(item);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }

        [HttpPut]
        public IActionResult Put(int id, Departament item)
        {
            try
            {
                item.Id = id;
                _departamentService.Update(item);
                var response = new ApiResponse<bool>(true);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }
    }
}