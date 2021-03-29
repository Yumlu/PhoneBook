using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Api.Model;
namespace Contact.Api.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Model.Contact>> GetContacts();
        Task<Model.Contact> GetContact(string id);
        Task CreateContact(Model.Contact contact);
        Task<bool> UpdateContact(Model.Contact product);
        Task<bool> DeleteContact(string id);
     
    }
}
