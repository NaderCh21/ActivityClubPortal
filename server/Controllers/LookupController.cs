using Microsoft.AspNetCore.Mvc;
using ActivityClubPortal.Models;
using ActivityClubPortal.Models.Repositories;
using System.Collections.Generic;
using ActivityClubPortal.Repositories;

[ApiController]
[Route("api/[controller]")]
public class LookupController : ControllerBase
{
    private readonly LookupRepository _lookupRepository;

    public LookupController(LookupRepository lookupRepository)
    {
        _lookupRepository = lookupRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Lookup>> GetAllLookups()
    {
        var lookups = _lookupRepository.GetAllLookups();
        return Ok(lookups);
    }
}
