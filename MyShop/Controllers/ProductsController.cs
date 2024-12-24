﻿using Microsoft.AspNetCore.Mvc;
using service;
using Entity;
using AutoMapper;
using dto;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMapper _mapper;
        IProductService ProductService;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            ProductService = productService;
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<productDTO>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = await ProductService.GetAllProducts(desc, minPrice, maxPrice, categoryIds);
            List<productDTO> productsDTO = _mapper.Map<List<Product>, List<productDTO>>(products);
            return Ok(productsDTO);
        }


    }
}
