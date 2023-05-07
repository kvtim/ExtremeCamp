using AutoMapper;
using MediatR;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandHandler : IRequestHandler<UpdateMeetupCommand, MeetupDto>
    {
        IMeetupRepository _repository;
        IMapper _mapper;

        public UpdateMeetupCommandHandler(IMeetupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MeetupDto> Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = await _repository.GetByIdAsync(request.Id);

            if (meetup == null)
            {
                throw new KeyNotFoundException("Meetup doesn't exist!");
            }

            if (request.Role != "Admin" && meetup.OwnerId != request.UserId)
            {
                throw new ArgumentException("You can update only your meetup");
            }

            meetup.Title = request.UpdateMeetupDto.Title;
            meetup.Description = request.UpdateMeetupDto.Description;
            meetup.Sport = request.UpdateMeetupDto.Sport;
            meetup.Address = request.UpdateMeetupDto.Address;
            meetup.MeetupDate = request.UpdateMeetupDto.MeetupDate;

            await _repository.UpdateAsync(meetup);
            await _repository.SaveChangesAsync();

            return _mapper.Map<MeetupDto>(meetup);
        }
    }
}
