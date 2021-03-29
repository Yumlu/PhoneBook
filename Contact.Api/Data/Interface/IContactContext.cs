using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Api.Data.Interface
{
    public interface IContactContext
    {
        IMongoCollection<Model.Contact> Contacts { get; }
    }
}
