using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/Contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly UserContext _context;
        public ContactsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "GetContacts")]
        [Authorize]
        public string GetContacts(int id)
        {
            var userlist = _context.Contacts.AsQueryable().Where(b => b.IdUser == id);
            string json = JsonConvert.SerializeObject(userlist);
            return json;
            //return "ok";
        }

        // POST: api/Contacts
        [HttpPost]
        public string PostContacts(Contacts contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            Message mes = new Message()
            {
                alert = "Contacto agregado con éxito",
                status = 200
            };
            string json = JsonConvert.SerializeObject(mes);
            return json;
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public string DeleteContacts(long id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            Message mes = new Message()
            {
                alert = "Contacto eliminado con éxito",
                status = 200
            };
            string json = JsonConvert.SerializeObject(mes);
            return json;
        }
    }
}
