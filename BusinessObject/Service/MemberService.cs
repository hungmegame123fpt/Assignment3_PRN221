using BusinessObject.IService;
using DataAccess.IRepository;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _repo;
        private readonly IConfiguration _configuration;
        public MemberService(IMemberRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        public async Task<Member?> Authenticate(string email, string password)
        {
            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];

            if (email == adminEmail && password == adminPassword)
            {
                return new Member
                {
                    MemberId = -1,
                    Email = adminEmail,
                    Password = adminPassword, 
                    CompanyName = "FPT Corporation",
                    City = "HCMC",
                    Country = "Vietnam"
                };
            }
            return await _repo.GetByEmailAndPasswordAsync(email, password);
        }
        public async Task<Member> Register(Member member)
        {
            var existingMember = await _repo.GetByEmailAsync(member.Email);
            if (existingMember != null)
            {
                throw new Exception("Email is already registered");
            }

            member.MemberId = await GenerateUniqueMemberId();

            return await _repo.RegisterAsync(member);
        }

        private async Task<int> GenerateUniqueMemberId()
        {
            var maxId = await _repo.GetMaxMemberIdAsync();
            return maxId + 1;
        }
    }
}