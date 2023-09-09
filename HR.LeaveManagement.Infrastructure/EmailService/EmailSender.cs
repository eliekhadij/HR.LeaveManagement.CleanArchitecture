using HR.LeaveManagement.Application.Contracts.Emails;
using HR.LeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings {  get; }
        public EmailSender(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }
        public Task<bool> SendEmail(EmailMessage email)
        {
            throw new NotImplementedException();
        }
    }
}
