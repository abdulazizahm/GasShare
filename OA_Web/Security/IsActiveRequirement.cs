using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Security
{
    public class IsActiveRequirement: IAuthorizationRequirement
    {
    }
}
