using BusinessObject.IService;
using DataAccess.IRepository;
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
        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }
    }
}
