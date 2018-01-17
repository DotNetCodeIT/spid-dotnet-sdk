using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPID_ASPNET_CORE_2_0_Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
