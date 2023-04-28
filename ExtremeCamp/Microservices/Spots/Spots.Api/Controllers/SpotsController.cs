using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spots.Core.Dtos.Spot;
using Spots.Core.Models;
using Spots.Data.Spots.Commands.CreateSpot;
using Spots.Data.Spots.Commands.DeleteSpot;
using Spots.Data.Spots.Commands.UpdateSpot;
using Spots.Data.Spots.Queries.GetAllSpots;
using Spots.Data.Spots.Queries.GetSpotById;
using System.Data;

namespace Spots.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SpotsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpots()
        {
            var spots = await _mediator.Send(new GetAllSpotsQuery());

            return Ok(spots);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var spot = await _mediator.Send(new GetSpotByIdQuery()
            {
                Id = id
            });

            return Ok(spot);
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateSpotDto createSpotDto)
        {
            var spot = await _mediator.Send(new CreateSpotCommand()
            {
                Spot = _mapper.Map<Spot>(createSpotDto)
            });
            return Ok(spot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,
            [FromBody] UpdateSpotDto updateSpotDto)
        {
            var spot = await _mediator.Send(new UpdateSpotCommand()
            {
                Id = id,
                UpdateSpotDto = updateSpotDto
            });

            return Ok(spot);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteSpotCommand()
            {
                Id = id
            });

            return Ok();
        }
    }
}
