using MeetupBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupBoard.Core.Dtos;
public class MeetupDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<User> Users { get; set; } = new List<User>();
    public DateTime StartTime { get; set; }
    public string Address { get; set; }
}
