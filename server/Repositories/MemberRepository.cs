using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ActivityClubPortal.Models;

namespace ActivityClubPortal.Repositories
{
    public class MemberRepository
    {
        private readonly activityclubportalContext _context;

        public MemberRepository(activityclubportalContext context)
        {
            _context = context;
        }

        public List<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int memberId)
        {
            return _context.Members.Find(memberId);
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void UpdateMember(Member member)
        {
            _context.Entry(member).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMember(int memberId)
        {
            var member = _context.Members.Find(memberId);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
        }
    }
}
