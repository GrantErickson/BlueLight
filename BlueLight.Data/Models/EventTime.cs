using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLight.Data.Models;
public class EventTime
{   
    public Guid EventTimeId { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;

    public string Name { get; set; }

    public List<EventRegistration> EventRegistrations { get; set; } = null!;




}
