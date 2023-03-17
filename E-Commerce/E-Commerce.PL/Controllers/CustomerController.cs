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
    public class CustomerController : Controller
    {
        private readonly IGenericRepository<Customer> customerRepo;
        private readonly IMapper mapper;

        public CustomerController(IGenericRepository<Customer> CustomerRepo, IMapper mapper)
        {
            customerRepo = CustomerRepo;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await customerRepo.GetAll();
            var mapped = mapper.Map<IReadOnlyList<CustomerViewModel>>(customers);
            return View(mapped);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapped = mapper.Map<Customer>(model);
                await customerRepo.Add(mapped);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var customer = await customerRepo.GetById(id);
            if (customer == null) return NotFound();
            return View(mapper.Map<CustomerViewModel>(customer));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var customer = await customerRepo.GetById(id);
            if (customer == null) return NotFound();
            return View(mapper.Map<CustomerViewModel>(customer));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] int? id, CustomerViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    await customerRepo.Update(mapper.Map<Customer>(model));
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    return View(model);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var result = await customerRepo.GetById(id);
            if (result == null) return NotFound();
            await customerRepo.Delete(result);
            return RedirectToAction(nameof(Index));

        }
    }
}
