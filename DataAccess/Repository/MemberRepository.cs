using DataAccess.Context;
using DataAccess.IRepository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private FptEStoreDbContext _context;
        public MemberRepository(FptEStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Member?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.Email.Equals(email) && m.Password.Equals(password));
        }
    }
}
