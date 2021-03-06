using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ladders.Models;
using ladders.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ladders.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly LaddersContext _context;

        public BookingRepository(LaddersContext context)
        {
            _context = context;
        }
        
        public async Task<Booking> FindByIdAsync(int id)
        {
            return await _context.Booking.FindAsync(id);
        }

        public Task<Booking> GetByIdIncAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Booking.ToListAsync();
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            booking = await SafeAddBooking(booking);
            await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();
            return await _context.Booking
                .Include(b => b.facility)
                .ThenInclude(f => f.sport)
                .Include(b => b.facility)
                .ThenInclude(f => f.venue)
                .FirstOrDefaultAsync(b => b.bookingId == booking.bookingId);
        }

        public async Task<Booking> SafeAddBooking(Booking booking)
        {
            var sport = await _context.Sport.FirstOrDefaultAsync(a => a.sportId == booking.facility.sportId);
            var venue = await _context.Venue.FirstOrDefaultAsync(a => a.venueId == booking.facility.venueId);
            var facility = await _context.Facility.FirstOrDefaultAsync(a => a.facilityId == booking.facilityId);

            if (sport == null)
                sport = (await _context.Sport.AddAsync(booking.facility.sport)).Entity;

            if (venue == null)
                venue = (await _context.Venue.AddAsync(booking.facility.venue)).Entity;

            if (facility == null)
            {
                return booking;
            }

            facility.sport = sport;
            facility.venue = venue;

            booking.facilityId = facility.facilityId;

            _context.Facility.Update(facility);

            return booking;
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            _context.Booking.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> DeleteAsync(Booking booking)
        {
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
    }
}