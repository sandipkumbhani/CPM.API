using Cpm.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Inftrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        public DbSet<ClinicMasterModel> Clinic_master { get; set; }
        public DbSet<DoctorMasterModel> Doctor_master { get; set; }
        public DbSet<SkillMasterModel> Skill_master { get; set; }
        public DbSet<RoleMasterModel> Role_master { get; set; }
        public DbSet<LoginModel> Login_Model { get; set; }

    }
}
