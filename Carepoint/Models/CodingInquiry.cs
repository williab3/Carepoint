using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carepoint.Models
{
    public class CodingInquiry
    {
        public int ID { get; set; }
        public string Inquiry { get; set; }
        public DateTime InquiryDate { get; set; }
        public InquiryType InquiryType { get; set; }
        public User Asker { get; set; }
        public User Responder { get; set; }
        public bool HasBeenAnswered { get; set; }
        public string Response { get; set; }
        public int ResponderId { get; set; }
        public DateTime ResponseDate { get; set; }
    }

    public class InquiryType
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int DNSPhone { get; set; }
        public bool IsAdmin { get; set; }
        public DMIS DMIS { get; set; }
    }

    public class DMIS
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}