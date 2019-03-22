using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Interfaces
{
    public interface IAzureDatabase
    {
        MobileServiceClient GetMobileServiceClient();
        MobileServiceClient GetMobileServiceClient(string TableName);
    }
}
