using Project_Managment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Infrastructure.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(ApplicationUser user);
    }
}
