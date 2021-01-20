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
    public class ExpenseDetailController : ControllerBase
    {
        private IExpenseDetail _transaction;
        private readonly IMapper _mapper;

        public ExpenseDetailController(IExpenseDetail transaction, IMapper mapper)
        {
            _transaction = transaction;
            _mapper = mapper;
        }
        // GET: Transactions
        // GET: api/Transaction
        [HttpGet]

        public async Task<ActionResult<ExpenseDetail>> GetExpenseDetails()
        {
            var transactions = await _transaction.GetExpenseDetails();

            var results = _mapper.Map<IEnumerable<ExpenseDetailDto>>(transactions);

            return Ok(results);
        }
        [HttpGet("{id}")]
        // GET: api/Transaction/Details/5

        public async Task<ActionResult<ExpenseDetail>> Details(int id)
        {

            var transactions = await _transaction.GetExpenseDetails();
            var transaction = transactions.FirstOrDefault(m => m.TransactionID == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        // POST: api/Transaction/Create

        public async Task<IActionResult> Create(ExpenseDetail model)
        {
            if (ModelState.IsValid)
            {
                await _transaction.Add(model);
                return RedirectToAction("Index");
            }
            return Ok(model);
        }
        // PUT: api/Transaction/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _transaction.Remove(Id);
            return RedirectToAction("Index");
        }
        // PUT: api/Transaction/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ExpenseDetail model)
        {

            await _transaction.Update(model);
            return RedirectToAction("Index");
        }
    }
}