using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseManagerAPI.Entities;
using ExpenseManagerAPI.Models;
using ExpenseManagerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private IExpenseCategory _category;
        private readonly IMapper _mapper;

        public ExpenseCategoryController(IExpenseCategory category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        // GET: ExpenseCategories
        // GET: api/Category
        [HttpGet]

        public async Task<ActionResult<ExpenseCategory>> GetExpenseCategories()
        {
            var categories = await _category.GetExpenseCategories();

            var results = _mapper.Map<IEnumerable<ClientDto>>(categories);

            return Ok(results);
        }
        [HttpGet("{id}")]
        // GET: api/Category/Details/5

        public async Task<ActionResult<ExpenseCategory>> Details(int id)
        {

            var categories = await _category.GetExpenseCategories();
            var category = categories.FirstOrDefault(m => m.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPost]
        // POST: api/Category/Create

        public async Task<IActionResult> Create(ExpenseCategory model)
        {
            if (ModelState.IsValid)
            {
                await _category.Add(model);
                return RedirectToAction("Index");
            }
            return Ok(model);
        }
        // PUT: api/Category/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _category.Remove(Id);
            return RedirectToAction("Index");
        }
        // PUT: api/Client/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ExpenseCategory model)
        {

            await _category.Update(model);
            return RedirectToAction("Index");
        }

    }
}