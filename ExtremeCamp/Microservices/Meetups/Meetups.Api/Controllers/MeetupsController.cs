using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Models;
using Meetups.Data.Meetups.Commands.CreateMeetup;
using Meetups.Data.Meetups.Commands.DeleteMeetup;
using Meetups.Data.Meetups.Commands.UpdateMeetup;
using Meetups.Data.Meetups.Queries.GetAllMeetups;
using Meetups.Data.Meetups.Queries.GetMeetupById;
using System.Data;
using Meetups.Core.Dtos.Participant;
using Meetups.Data.Meetups.Commands.AddParticipant;
using Meetups.Data.Meetups.Commands.DeleteParticipant;

namespace Meetups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MeetupsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeetups()
        {
            var meetups = await _mediator.Send(new GetAllMeetupsQuery());

            return Ok(meetups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meetup = await _mediator.Send(new GetMeetupByIdQuery()
            {
                Id = id
            });

            return Ok(meetup);
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateMeetupDto createMeetupDto)
        {
            var meetup = await _mediator.Send(new CreateMeetupCommand()
            {
                Meetup = _mapper.Map<Meetup>(createMeetupDto)
            });
            return Ok(meetup);
        }

        [HttpPost("add-participant")]
        public async Task<IActionResult> AddParticipant(
            [FromBody] AddParticipantDto addParticipantDto)
        {
            var meetup = await _mediator.Send(new AddParticipantCommand()
            {
                Participant = _mapper.Map<Participant>(addParticipantDto)
            });

            return Ok(meetup);
        }

        [HttpDelete("delete-participant")]
        public async Task<IActionResult> DeleteParticipant(
            [FromBody] DeleteParticipantDto deleteParticipantDto)
        {
            await _mediator.Send(new DeleteParticipantCommand()
            {
                MeetupId = deleteParticipantDto.MeetupId,
                UserId = deleteParticipantDto.UserId
            });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,
            [FromBody] UpdateMeetupDto updateMeetupDto)
        {
            var meetup = await _mediator.Send(new UpdateMeetupCommand()
            {
                Id = id,
                UpdateMeetupDto = updateMeetupDto
            });

            return Ok(meetup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteMeetupCommand()
            {
                Id = id
            });

            return Ok();
        }
    }
}
