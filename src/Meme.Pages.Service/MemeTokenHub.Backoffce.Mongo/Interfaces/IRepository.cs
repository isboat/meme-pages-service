using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Meme.Domain.Models;

namespace MemeTokenHub.Backoffce.Mongo.Interfaces
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetByFilter(Func<T, bool> filter);
    }
}
