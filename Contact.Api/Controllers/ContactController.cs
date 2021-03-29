using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contact.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contact.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactRepository repository, ILogger<ContactController> logger)
        {
            _repository = repository;
            _logger = logger;

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Model.Contact>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Model.Contact>>> GetContacts()
        {
            var contacts = await _repository.GetContacts();
            return Ok(contacts);
        }

        [HttpGet("{id:length(24)}", Name = "GetContact")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Model.Contact), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Model.Contact>> GetContactById(string id)
        {
            var contact = await _repository.GetContact(id);

            if (contact == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(contact);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Model.Contact), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Model.Contact>> CreateContact([FromBody] Model.Contact contact)
        {
            await _repository.CreateContact(contact);

            //return CreatedAtRoute("GetContact", new { id = contact.UUID }, contact);
            return CreatedAtRoute("GetContact", new { id = contact.UUID }, contact);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Model.Contact), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateContact([FromBody] Model.Contact contact)
        {
            return Ok(await _repository.UpdateContact(contact));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteContact")]
        [ProducesResponseType(typeof(Model.Contact), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteContactById(string id)
        {
            return Ok(await _repository.DeleteContact(id));
        }

    }
}