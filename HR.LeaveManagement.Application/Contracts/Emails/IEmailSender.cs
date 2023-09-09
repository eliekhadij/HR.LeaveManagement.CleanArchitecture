﻿using HR.LeaveManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Emails
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
