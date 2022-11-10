using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.Application.Interfaces;
using DapperDemo.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.User.GetAll();
            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.User.Get(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            var data = await unitOfWork.User.Add(user);
            return Ok(data);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(User user)
        {
            var data = await unitOfWork.User.Update(user);
            return Ok(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.User.Delete(id);
            return Ok(data);
        }
    }
}

