using Microsoft.EntityFrameworkCore;
using ReadBookMuds.Data;

namespace ReadBookMuds.Services
{
    public partial class Service
    {
        private readonly ReadBookContext _context;
        public Service(ReadBookContext context)
        {
            this._context = context;    
        }
        public void Reset()
        {
            _context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(en => en.State = EntityState.Detached);
        }
    }
}
