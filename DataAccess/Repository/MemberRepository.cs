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
        public async Task<Member> RegisterAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member?> GetByEmailAsync(string email)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.Email.Equals(email));
        }
        public async Task<int> GetMaxMemberIdAsync()
        {
            return await _context.Members.AnyAsync()
                ? await _context.Members.MaxAsync(m => m.MemberId)
                : 0;
        }
        public async Task<Member> GetById(int memberId) => await _context.Members.FirstOrDefaultAsync(s => s.MemberId == memberId);

        public async Task UpdateMember(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }
    }
}