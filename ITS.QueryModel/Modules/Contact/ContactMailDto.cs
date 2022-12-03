using System;

namespace ITS.QueryModel.Modules.Contact
{
    public class ContactMailDto
    {   
        public Guid Id { get; set; }
        public string MailAddress { get; set; }
        public int? MailTypeCode { get; set; }
    }
}