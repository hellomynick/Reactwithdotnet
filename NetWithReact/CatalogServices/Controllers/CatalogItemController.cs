using CatalogServices.Model;
using CatalogServices.Repositories.UoW;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public CatalogItemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.catalogItems.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.catalogItems.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CatalogItem catalogItem)
        {
            await unitOfWork.catalogItems.AddAsync(catalogItem);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.catalogItems.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CatalogItem catalogItem)
        {
            var data = await unitOfWork.catalogItems.UpdateAsync(catalogItem);
            return Ok(data);
        }
    }
}
