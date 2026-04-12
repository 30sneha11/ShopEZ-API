using Microsoft.AspNetCore.Mvc;
using ShopEZ.API.DTOs;
using ShopEZ.API.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO dto)
    {
        var product = await _service.CreateAsync(dto);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductDTO dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
            return NotFound();

        return Ok("Updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return Ok("Deleted successfully");
    }
}