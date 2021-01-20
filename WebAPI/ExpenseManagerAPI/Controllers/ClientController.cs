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
    public class ClientController : ControllerBase
    {
        private IClient _client;
        private readonly IMapper _mapper;

        public ClientController(IClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        // GET: Clients
        // GET: api/Client
        [HttpGet]
        [Route("client/details")]

        public async Task<ActionResult<Client>> GetClients()
        {
            var cllients = await _client.GetClients();

            var results = _mapper.Map<IEnumerable<ClientDto>>(cllients);

            return Ok(results);
        }

        [HttpGet]
        [Route("client/details/{id}")]
        // GET: api/Client/Details/5

        public async Task<ActionResult<Client>> Details(int id)
        {
           
            var clients = await _client.GetClients();
            var client = clients.FirstOrDefault(m => m.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        [Route("client/create")]
        // POST: api/Client/Create

        public async Task <IActionResult> Create(Client model)
        {
            if (ModelState.IsValid)
            {
                await _client.Add(model);
                return RedirectToAction("Index");
            }
            return Ok(model);
        }

        // PUT: api/Client/Delete
        [HttpDelete]
        [Route("client/delete/{id}")]
        public async Task <IActionResult> Delete(int Id)
        {
            await _client.Remove(Id);
            return RedirectToAction("Index");
        }

        // PUT: api/Client/Update
        [HttpPut]
        [Route("client/update/{id}")]
        public async Task<IActionResult> Update(Client model)
        {

            await _client.Update(model);
            return RedirectToAction("Index");
        }

    }
}