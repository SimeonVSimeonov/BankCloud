using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Data.Context
{
    public class BankCloudDbContext : IdentityDbContext
    {
        public BankCloudDbContext(DbContextOptions<BankCloudDbContext> options)
            : base(options)
        {
        }
    }
}
