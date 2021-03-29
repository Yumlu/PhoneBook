using Contact.Api.Data.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Api.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactContext _context;

        public ContactRepository(IContactContext context)
        {
            _context = context;
        }

       
        public async Task CreateContact(Model.Contact contact)
        {
            await _context.Contacts.InsertOneAsync(contact);
        }

        public async Task<bool> DeleteContact(string id)
        {
            FilterDefinition<Model.Contact> filter = Builders<Model.Contact>.Filter.Eq(p => p.UUID, id);

            DeleteResult deleteResult = await _context
                                                .Contacts
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Model.Contact>> GetContacts()
        {
            return await _context
                           .Contacts
                           .Find(p => true)
                           .ToListAsync();
        }

        public async Task<Model.Contact> GetContact(string id)
        {
            return await _context
                           .Contacts
                           .Find(p => p.UUID == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateContact(Model.Contact contact)
        {
            var updateResult = await _context
                                      .Contacts
                                      .ReplaceOneAsync(filter: g => g.UUID == contact.UUID, replacement: contact);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
