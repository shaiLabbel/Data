using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.DTO
{
     public class PickUpDTO 
    {
        public int OrderNumber;
        public int PickUpNumber;
        public string CollectionPoint;
        public TimeSpan CollectionTime;
        public string Destination;
        public string OrderStatus;
    }
}