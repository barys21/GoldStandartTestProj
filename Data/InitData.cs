using GoldStandartTestProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Data
{
    public class InitData
    {
        public static void Create(ApplicationContext context)
        {
            if (context.Statuses.ToList().Count == 0)
            {
                Status status1 = new Status { Name = "В проекте" };
                Status status2 = new Status { Name = "В разработке" };
                Status status3 = new Status { Name = "Завершен" };
                Status status4 = new Status { Name = "Остановлен" };
                context.Statuses.AddRange(new List<Status> { status1, status2, status3, status4 });
                context.SaveChanges();
            }

            if (context.Roles.ToList().Count == 0)
            {
                Role role1 = new Role { Name = "Admin" };
                Role role2 = new Role { Name = "ProjectAdmin" };
                Role role3 = new Role { Name = "Developer" };
                context.Roles.AddRange(new List<Role> { role1, role2, role3 });
                context.SaveChanges();
            }
        }
    }
}
