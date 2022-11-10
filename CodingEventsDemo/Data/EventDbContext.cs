using System;
using CodingEventsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsDemo.Data
{
    public class EventDbContext : DbContext
    {
        public DbSet<EventCategory> Events { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options): base(options)
        {
        }
    }
}