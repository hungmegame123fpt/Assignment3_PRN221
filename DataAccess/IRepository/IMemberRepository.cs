
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.IRepository
{
    public interface IMemberRepository
    {
        public Task<Member?> GetByEmailAndPasswordAsync(string email, string password);
    }
}
