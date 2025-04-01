using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.IRepository
{
    public interface IMemberRepository
    {
        public Task<Member?> GetByEmailAndPasswordAsync(string email, string password);
        public Task<Member> RegisterAsync(Member member);
        public Task<Member?> GetByEmailAsync(string email);
        Task<int> GetMaxMemberIdAsync();
    }
}