using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.DTO
{
    public class UpdatesDTO
    {
        public int UpdateId;
        public DateTime Date;
        public TimeSpan Time;
        public int OrderNumber;
        public string ContactName;
        public DateTime OrderDate;
        public string OrderStatus;
        public int? Bid;
        public string StatusNumber;
        public List<PickUpDTO> Points;

    }
}