using AutoMapper;
using E_Commerce.BLL.Interfaces;
using E_Commerce.DAL.Entities;
using E_Commerce.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository ProductRepository,IMapper mapper)
        {
            productRepository = ProductRepository;
            this.mapper = mapper;
        }

        public async Task< IActionResult> Index()
        {
            var products = await productRepository.GetAll();
            var mappedProducts = mapper.Map<IEnumerable<ProductViewModel>>(products);
            return View(mappedProducts);
        }
        public async Task<IActionResult> Details(int?id)
        {
            if (id == null) return NotFound();
            var product = await productRepository.GetById(id);
            if(product == null) return NotFound();
            return View(mapper.Map<ProductViewModel>(product));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                await productRepository.Add(mapper.Map<Product>(model));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int?id)
        {
            if (id == null) return NotFound();
            var product = await productRepository.GetById(id);
            if(product == null) return NotFound();
            return View(mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update([FromRoute]int?id, ProductViewModel model)
        {
            if(id!=model.Id)return BadRequest();
            if(ModelState.IsValid)
            {
                try
                {
                    var mappedModel=mapper.Map<Product>(model);
                    await productRepository.Update(mappedModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View(model);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var product= await productRepository.GetById(id);
            if(product == null) return NotFound();
            await productRepository.Delete(product);
            return RedirectToAction(nameof(Index));
        }
        public  IActionResult ProductInStock()
        {
            return  View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductInStock(int id)
        {
            var result = await productRepository.QuantityInStock(id);
            return Json(result);
        }
    }
}
