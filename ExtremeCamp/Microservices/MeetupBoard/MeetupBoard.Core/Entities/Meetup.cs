using MeetupBoard.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupBoard.Core.Entities;
public class Meetup
{
    public int Id { get; set; }
    private string _title;
    private string _description;
    private List<User> _users = new List<User>();
    private DateTime _creationTime;
    private DateTime _startTime;
    private string _address;

    public void AddParticipantToMeetup(User user)
    {


        if (_users.Contains(user))
        {
            throw new Exception();
        }

        _users.Add(user);
    }

    public void RemoveParticipantFromMeetup(User user)
    {
        if (!_users.Contains(user)) 
        {
            throw new Exception();
        }

        _users.Remove(user);
    }

    public MeetupDto GetMeetupInformation()
    {
        return new MeetupDto
        {
            Id = Id,
            Title = _title,
            Description = _description,
            StartTime = _startTime,
            Address = _address,
            Users = _users
        };
    }

    public 
}
