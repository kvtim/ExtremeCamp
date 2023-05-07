using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports.Core.Dtos.Sport;
using Sports.Core.Models;
using Sports.Data.Sports.Commands.CreateSport;
using Sports.Data.Sports.Commands.DeleteSport;
using Sports.Data.Sports.Commands.UpdateSport;
using Sports.Data.Sports.Queries.GetAllSports;
using Sports.Data.Sports.Queries.GetSportById;
using System.Data;

namespace Sports.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SportsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSports()
        {
            var sports = await _mediator.Send(new GetAllSportsQuery());

            return Ok(sports);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var sport = await _mediator.Send(new GetSportByIdQuery()
            {
                Id = id
            });

            return Ok(sport);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(
            [FromBody] CreateSportDto createSportDto)
        {
            var sport = await _mediator.Send(new CreateSportCommand()
            {
                Sport = _mapper.Map<Sport>(createSportDto)
            });
            return Ok(sport);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id,
            [FromBody] UpdateSportDto updateSportDto)
        {
            var sport = await _mediator.Send(new UpdateSportCommand()
            {
                Id = id,
                UpdateSportDto = updateSportDto
            });

            return Ok(sport);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteSportCommand()
            {
                Id = id
            });

            return Ok();
        }
    }
}
