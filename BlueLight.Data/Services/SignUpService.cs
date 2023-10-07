using BlueLight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlueLight.Data.Services;

[Coalesce, Service]
public class SignUpService
{
    public SignUpService(AppDbContext db)
    {
        _db = db;
    }

    private AppDbContext _db;

    [Coalesce]
    [Execute(SecurityPermissionLevels.AllowAll)]
    public async Task<IEnumerable<Event>> CurrentEvents()
    {
        var events = await _db.Events
            .Include(f => f.EventTimes).ThenInclude(f => f.EventRegistrations)
            .Where(f => f.Date > DateTime.Now.AddDays(-1) && f.Date < DateTime.Now.AddDays(30))
            .ToListAsync();
        // Obfuscate the emails and phone numbers
        foreach (var e in events)
        {
            foreach (var et in e.EventTimes)
            {
                foreach (var er in et.EventRegistrations)
                {
                    er.Phone = $"***-***-*{er.Phone.Substring(er.Phone.Length - 4, 3)}";
                    er.Email = $"{er.Email.Substring(0, 3)}***@***{er.Email.Substring(er.Email.Length - 6, 5)}";
                    er.Notes = string.IsNullOrWhiteSpace(er.Notes) ? "None" : "Notes Provided";
                }
            }
        }
        return events;
    }

    [Coalesce]
    [Execute(SecurityPermissionLevels.AllowAll)]
    public async Task<string> Register(Guid eventTimeId, string email, string phone, int quantity, string notes)
    {
        // Validation
        if (quantity < 1 || quantity > 16) return "Invalid Quantity";
        if (string.IsNullOrWhiteSpace(email) || email.Length < 8) return "Invalid email";
        if (string.IsNullOrWhiteSpace(phone) || phone.Length < 7) return "Invalid phone";

        // Find the EventTime
        var et = _db.EventTimes
            .Include(f => f.Event)
            .FirstOrDefault(f => f.EventTimeId == eventTimeId);
        // Make sure the eventTime exists and the Event is still valid.
        if (et == null) return "Invalid Event Time";
        if (!et.Event.IsActive) return "Event is no longer active";

        // Create a registration
        var er = new EventRegistration
        {
            EventTime = et,
            Quantity = quantity,
            Email = email,
            Phone = phone,
            Notes = notes,

        };
        _db.EventRegistrations.Add(er);
        await _db.SaveChangesAsync();
        return $"Successful registration of {er.Quantity} for {er.Email} with phone {er.Phone} for {et.Event.Name} at {et.Name}";
    }
}
