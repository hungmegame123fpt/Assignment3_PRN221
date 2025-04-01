using DataAccess.Models;

namespace BusinessObject.IService
{
    public interface IMemberService
    {
        public Task<Member?> Authenticate(string email, string password);
    }
}
