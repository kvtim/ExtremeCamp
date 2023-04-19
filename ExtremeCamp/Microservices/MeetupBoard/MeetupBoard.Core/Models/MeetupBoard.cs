using MeetupBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupBoard.Core.Models;
public class MeetupBoard
{
    private List<Meetup> _meetups = new List<Meetup>();


    public void AddMeetupToBoard(Meetup meetup)
    {
        if (meetup is null)
        {
            throw new ArgumentNullException("meetup");
        }

        _meetups.Add(meetup);
    }

    public void DeleteMeetupFromBoard(Meetup meetup)
    {
        if (_meetups.Contains(meetup))
        {
            throw new Exception();
        }

        _meetups.Remove(meetup);
    }

    public List<Meetup> GetAllMeetupsFromBoard()
    {
        if (!_meetups.Any())
        {
            throw new Exception();
        }

        return _meetups;
    }
}
