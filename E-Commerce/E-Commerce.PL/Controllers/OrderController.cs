using AutoMapper;
using E_Commerce.BLL.Interfaces;
using E_Commerce.BLL.Specification;
using E_Commerce.DAL.Entities;
using E_Commerce.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.PL.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericRepository<Order> genericRepository;
        private readonly IMapper mapper;
        private readonly IGenericRepository<ProductOrder> productOrderRepo;

        public OrderController(IGenericRepository<Order> genericRepository,IMapper mapper,IGenericRepository<ProductOrder> ProductOrderRepo)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
            productOrderRepo = ProductOrderRepo;
        }

        public async Task< IActionResult> Index()
        {
            var spec = new OrderSpecification();
            var result = await genericRepository.GetAllWithSpec(spec);
            var mapped = mapper.Map<IEnumerable<OrderViewModel>>(result);
            
            return View(mapped);
        }
        public async Task<IActionResult> Details(int?  id)
        {
            if (id == null)
                return NotFound();
            var order = await genericRepository.GetById(id);
            if (order == null)
                return NotFound();
            return View(order);
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if(ModelState.IsValid)
            {
                var order=mapper.Map<OrderViewModel,Order>(model);
                await genericRepository.Add(order);
                foreach(var item in model.ProductId)
                {
                   await productOrderRepo.Add(new ProductOrder() { OrderId = order.Id, ProductId = item });
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var order=await genericRepository.GetById(id);
            if(order!=null)
            {
                await genericRepository.Delete(order);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null) return NotFound();
            var order= await genericRepository.GetById(id);
            if (order == null) return NotFound();

            return View(mapper.Map<Order,OrderViewModel>(order));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute]int? id,OrderViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if(ModelState.IsValid)
            {
                try
                {
                    await genericRepository.Update(mapper.Map<OrderViewModel, Order>(model));
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
