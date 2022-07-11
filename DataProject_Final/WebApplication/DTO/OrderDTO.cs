using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.DTO
{
    public class OrderDTO
    {
        public int OrderNumber;
        public string ContactName;
        public string ContactNumber;
        public DateTime Date;
        public int Passengers;
        public string OrderStatus;
        public string Type;
        public int? Bid;
        public string Driver;
        public List<PickUpDTO> Points;
    }
}