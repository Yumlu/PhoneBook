using Contact.Api.Data.Interface;
using Contact.Api.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Api.Data
{
    public class ContactContext : IContactContext
    {

        public ContactContext(IContactDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Contacts = database.GetCollection<Model.Contact>(settings.CollectionName);
            //CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Model.Contact> Contacts { get; }

    }
}
