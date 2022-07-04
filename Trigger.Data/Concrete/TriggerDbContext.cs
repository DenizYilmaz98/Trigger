using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Model;
using TriggerCore;

namespace Trigger.Data.Concrete
{
   public class TriggerDbContext:DbContext
    {
        private readonly IOptions<AppSettings> _config;

        public DbSet<User> Users { get; set; }
        public DbSet<CommentData> CommentDatas { get; set; }
        public DbSet<TriggerAdded> triggerAddeds { get; set; }
        public TriggerDbContext(DbContextOptions<TriggerDbContext> options, IOptions<AppSettings> config) : base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.Value.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
