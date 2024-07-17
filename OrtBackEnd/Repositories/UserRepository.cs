using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Contracts;
using OrtBackEnd.DbContent;
using OrtBackEnd.Models;

namespace OrtBackEnd.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task UpdateAsync(User updatedUser)
        { 

            if (updatedUser != null) 
            { 
                _context.Users.Entry(updatedUser).State = EntityState.Modified; 
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                //This will mark the Entity State as Deleted
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
        }

    //    private bool disposed = false;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                _context.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }
    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }

        
    //
    }
}
