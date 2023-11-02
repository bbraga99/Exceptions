using System;
using Exception1.Entities.DomainException;

namespace Exception1.Entities
{
    internal class Reservation
    {
        public int Room { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation()
        {
        }

        public Reservation(int room, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new ReservationException("Check-in must be early than checkOut");
            }

            Room = room;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;

            if(checkIn < now || checkOut < now)
            {
                throw new ReservationException("New reservation must be in a future date");
            }
            if(checkOut <= checkIn)
            {
                throw new ReservationException("Check-in must be early than checkOut");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return "Room "
                + Room
                + ", check-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + " , "
                + Duration()
                + " nights";
        }
    }
}
