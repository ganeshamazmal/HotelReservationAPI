using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Data
{
    public class HotelReservationDbInitializer
    {
        private HotelReservationDbContext _context;

        public HotelReservationDbInitializer(HotelReservationDbContext context)
        {
            _context = context;
        }


        private List<Hotel> _hotels = new List<Hotel>
        {
            new Hotel{Name = "Sahid Montana", City = "Dubai", Address = "SpecialStreet 15", AvailableRooms = 10, Rating = 4,Price = 26.77, IsActive = true },
            new Hotel{Name = "Grand Canyon", City = "Sharjah", Address = "HiddenStreet 18", AvailableRooms = 20, Rating = 5,Price = 28.42, IsActive = true },
            new Hotel{Name = "Great Hotel", City = "Ajman", Address = "ProStreet 2", AvailableRooms = 30, Rating = 3,Price = 30.12, IsActive = true }
        };

        private List<Customer> _customers = new List<Customer>
        {
            new Customer{FirstName = "Albert", LastName = "Einstein", IDNumber = "AAA123123", Email = "iwasright@gmail.com", Phone = 123123123, IsActive = true },
            new Customer{FirstName = "Barack", LastName = "Obama", IDNumber = "BBB234234", Email = "yeswecan@gmail.com", Phone = 234234234, IsActive = true },
            new Customer{FirstName = "Michael", LastName = "Bay", IDNumber = "CCC345345", Email = "specialeffects@gmail.com", Phone = 345345345, IsActive = true }
        };

        public async Task Initialize()
        {
            if (!_context.Hotels.Any())
            {
                _context.Hotels.AddRange(_hotels);
                await _context.SaveChangesAsync();
            }

            if (!_context.Customers.Any())
            {
                _context.Customers.AddRange(_customers);
                await _context.SaveChangesAsync();
            }
        }

    }
}
