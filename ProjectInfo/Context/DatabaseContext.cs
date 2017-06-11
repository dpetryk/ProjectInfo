using ProjectInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectInfo.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        
        }
}