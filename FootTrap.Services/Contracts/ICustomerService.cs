using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace FootTrap.Services.Contracts
{
    public interface ICustomerService
    {
        Task Create(string userId);

        Task<string?> GetCustomerIdByUserIdAsync(string userId);
    }
}
