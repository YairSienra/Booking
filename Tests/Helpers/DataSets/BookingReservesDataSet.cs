using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Helpers.DataSets
{
    public class BookingReservesDataSet
    {

        public static List<Service> ServicesEmpty()
        {
            return new List<Service>();
        }

        public static List<Service> ServicesOn()
        {
            return new List<Service>
            {
                new Service
                {
                    Id = 1,
                    NameService = "TestService",
                    Bookings = new List<Booking>
                    {
                        new Booking
                        {
                            Id = 1,
                            Date = new DateTime(2025, 04, 01),
                            Time = new TimeSpan(10, 0, 0),
                            Reserved = false,
                        },
                        new Booking
                        {
                            Id = 2,
                            Date = new DateTime(2025, 04, 01),
                            Time = new TimeSpan(15, 0, 0),
                            Reserved = false,
                        }
                    }
                }
            };
        }

        public static List<Service> ServicesOnButOneOnTrue()
        {
            return new List<Service>
    {
        new Service
        {
            Id = 1,
            NameService = "TestService",
            Bookings = new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    Date = new DateTime(2025, 04, 01),
                    Time = new TimeSpan(10, 0, 0),
                    Reserved = false
                },
                new Booking
                {
                    Id = 2,
                    Date = new DateTime(2025, 04, 01),
                    Time = new TimeSpan(15, 0, 0),
                    Reserved = true
                }
            }
        }
    };
        }

        public static List<Service> MultipleServices()
        {
            return new List<Service>
            {
                new Service
                {
                    Id = 1,
                    NameService = "TestService",
                    Bookings = new List<Booking>
                    {
                        new Booking
                        {
                            Id = 1,
                            Date = new DateTime(2025, 04, 01),
                            Time = new TimeSpan(10, 0, 0),
                            Reserved = false,
                        },
                        new Booking
                        {
                            Id = 2,
                            Date = new DateTime(2025, 04, 01),
                            Time = new TimeSpan(15, 0, 0),
                            Reserved = false,
                        }
                    }
                },
                new Service
                {
                    Id = 2,
                    NameService = "Servicio 2",
                    Bookings = new List<Booking>
                    {
                        new Booking
                        {
                            Id = 3,
                            Date = new DateTime(2025, 04, 01),
                            Time = new TimeSpan(11, 0, 0),
                            Reserved = false,
                        },
                        new Booking
                        {
                            Id = 4,
                            Date = new DateTime(2025, 04, 01),
                            Time = new TimeSpan(16, 0, 0),
                            Reserved = true,
                        }
                    }
                },
                new Service
                {
                    Id = 3,
                    NameService = "Servicio 3",
                    Bookings = new List<Booking>
                    {
                        new Booking
                        {
                            Id = 5,
                            Date = new DateTime(2025, 04, 01),
                            Time = new TimeSpan(9, 0, 0),
                            Reserved = false,
                        },
                        new Booking
                        {
                            Id = 6,
                            Date = new DateTime(2025, 04, 02),
                            Time = new TimeSpan(14, 0, 0),
                            Reserved = false,
                        }
                    }
                }
            };
        }
    }
}
