using DataAccess.Models;

namespace BusinessObject.IService
{
    public interface IMemberService
    {
        public Task<Member?> Authenticate(string email, string password);
        public Task<Member> Register(Member member);
        public Task<Member> GetMemberById(int memberId);
        public Task UpdateMember(Member member);
    }
}