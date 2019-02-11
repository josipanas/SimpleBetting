using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Service.Models;

namespace SimpleBetting.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public MatchesController(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var matches = _matchRepository.GetAllMatchesWithOffers();
            if (matches == null) return NotFound();

            return Ok(_mapper.Map<List<MatchDto>>(matches));
        }

        [HttpGet("{id}")]
        public IActionResult GetMatchById(int id)
        {
            var match = _matchRepository.GetMatchById(id);
            if (match == null) return NotFound();

            return Ok(_mapper.Map<MatchDto>(match));
        }

        [HttpGet("sport/{sportId}")]
        public IActionResult GetMatchesBySportName(int sportId)
        {
            var matches = _matchRepository.GetMatchesBySportId(sportId);
            if (matches.Count == 0) return NotFound();

            return Ok(_mapper.Map<List<MatchDto>>(matches));
        }
    }
}