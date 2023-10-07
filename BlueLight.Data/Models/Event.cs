using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLight.Data.Models;
public class Event
{
    public Guid EventId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public List<EventTime> EventTimes { get; set; } = null!;

}
