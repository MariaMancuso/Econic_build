using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Econic.Mobile.Services
{
    public interface IPermissionService
    {
        Task<bool> RequestAllPermissions();
    }
}
