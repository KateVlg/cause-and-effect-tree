using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Dal
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Failure> Failures { get; set; }
        public DbSet<RootCause> RootCauses { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }

        public ApplicationContext(string connString) : base()
        {
            Database.SetConnectionString(connString);
            Database.EnsureCreated();
        }
    }
}
