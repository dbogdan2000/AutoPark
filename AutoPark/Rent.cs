using System;

namespace AutoPark
{
    public class Rent
    {
        public DateTime RentDate { get; set; }
        public double RentPrice { get; set; }
        
        public Rent(){}

        public Rent(DateTime rentDate, double rentPrice)
        {
            RentDate = rentDate;
            RentPrice = rentPrice;
        }
    }
}