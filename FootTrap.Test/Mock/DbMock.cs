using FootTrap.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Test.Mock
{
    public class DbMock
    {
        public static FootTrapDbContext Instance
        {
            get
            {
                var options = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

                return new FootTrapDbContext(options, false);
            }
        }
    }
}
