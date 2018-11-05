using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pim8.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string fieldName { get; set; }
        public DateTime dateTimeStart { get; set; }
        public DateTime dateTimeEnd { get; set; }
        public string description { get; set; }
    }
}