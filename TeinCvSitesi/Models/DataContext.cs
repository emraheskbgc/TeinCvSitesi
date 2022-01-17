using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeinCvSitesi.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DataContext")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<EducationInfo> EducationInfos { get; set; }
        public DbSet<ProfileUpdate> ProfileUpdates { get; set; }
        
    }
}