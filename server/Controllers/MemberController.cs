using Microsoft.AspNetCore.Mvc;
using ActivityClubPortal.Models;
using ActivityClubPortal.Models.Repositories;
using System.Collections.Generic;
using ActivityClubPortal.Repositories;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{   
    private readonly MemberRepository _memberRepository;

    public MemberController(MemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Member>> GetAllMembers()
    {
        var members = _memberRepository.GetAllMembers();
        return Ok(members);
    }

    [HttpGet("{id}")]
    public ActionResult<Member> GetMemberById(int id)
    {
        var member = _memberRepository.GetMemberById(id);

        if (member == null)
        {
            return NotFound();
        }

        return Ok(member);
    }

    [HttpPost]
    public ActionResult<Member> CreateMember([FromBody] Member newMember)
    {
        if (newMember == null)
        {
            return BadRequest("Invalid member data");
        }

        _memberRepository.AddMember(newMember);

        return CreatedAtAction(nameof(GetMemberById), new { id = newMember.MemberId }, newMember);
    }

    [HttpPut("{id}")]
    public ActionResult<Member> UpdateMember(int id, [FromBody] Member updatedMember)
    {
        var existingMember = _memberRepository.GetMemberById(id);

        if (existingMember == null)
        {
            return NotFound();
        }

        existingMember.FullName = updatedMember.FullName;
        existingMember.Email = updatedMember.Email;
        existingMember.Password = updatedMember.Password;
        existingMember.DateOfBirth = updatedMember.DateOfBirth;
        existingMember.Gender = updatedMember.Gender;
        existingMember.JoiningDate = updatedMember.JoiningDate;
        existingMember.MobileNumber = updatedMember.MobileNumber;
        existingMember.EmergencyNumber = updatedMember.EmergencyNumber;
        existingMember.Photo = updatedMember.Photo;
        existingMember.Profession = updatedMember.Profession;
        existingMember.Nationality = updatedMember.Nationality;

        _memberRepository.UpdateMember(existingMember);

        return Ok(existingMember);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteMember(int id)
    {
        var existingMember = _memberRepository.GetMemberById(id);

        if (existingMember == null)
        {
            return NotFound();
        }

        _memberRepository.DeleteMember(id);

        return NoContent();
    }
}
