using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLight.Data.Models;
public class EventRegistration
{
    public Guid EventRegistrationId { get; set; }
    public Guid EventTimeId { get; set; }
    public EventTime EventTime { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Notes { get; set; }
    public int Quantity { get; set; } = 1;
}
