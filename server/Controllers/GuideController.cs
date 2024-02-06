using Microsoft.AspNetCore.Mvc;
using ActivityClubPortal.Models;
using System.Collections.Generic;
using ActivityClubPortal.Repositories;

[ApiController]
[Route("api/[controller]")]
public class GuideController : ControllerBase
{
    private readonly GuideRepository _guideRepository;

    public GuideController(GuideRepository guideRepository)
    {
        _guideRepository = guideRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Guide>> GetAllGuides()
    {
        var guides = _guideRepository.GetAllGuides();
        return Ok(guides);
    }

    [HttpGet("{id}")]
    public ActionResult<Guide> GetGuideById(int id)
    {
        var guide = _guideRepository.GetGuideById(id);

        if (guide == null)
        {
            return NotFound();
        }

        return Ok(guide);
    }

    [HttpPost]
    public ActionResult<Guide> CreateGuide([FromBody] Guide guide)
    {
        if (guide == null)
        {
            return BadRequest("Invalid guide data");
        }

        _guideRepository.AddGuide(guide);

        return CreatedAtAction(nameof(GetGuideById), new { id = guide.GuideId }, guide);
    }





    [HttpPut("{id}")]
    public ActionResult<Guide> UpdateGuide(int id, [FromBody] Guide updatedGuide)
    {
        var existingGuide = _guideRepository.GetGuideById(id);

        if (existingGuide == null)
        {
            return NotFound();
        }

        existingGuide.FullName = updatedGuide.FullName;
        existingGuide.Email = updatedGuide.Email;
        existingGuide.Password = updatedGuide.Password;
        existingGuide.DateOfBirth = updatedGuide.DateOfBirth;
        existingGuide.JoiningDate = updatedGuide.JoiningDate;
        existingGuide.Photo = updatedGuide.Photo;
        existingGuide.Profession = updatedGuide.Profession;

        _guideRepository.UpdateGuide(existingGuide);

        return Ok(existingGuide);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteGuide(int id)
    {
        var existingGuide = _guideRepository.GetGuideById(id);

        if (existingGuide == null)
        {
            return NotFound();
        }

        _guideRepository.DeleteGuide(id);

        return NoContent();
    }
}