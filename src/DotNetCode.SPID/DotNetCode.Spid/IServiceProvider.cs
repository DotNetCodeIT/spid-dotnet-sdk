using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid
{
    public interface IServiceProvider
    {

        string ServiceProviderId { get; set; }

        string OrganizationName { get; set; }

        string OrganizationDisplayName { get; set; }

        string OrganizationUrl { get; set; }

       
    }

  
}
