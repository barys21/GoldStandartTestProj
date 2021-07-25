using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Models
{
    [NotMapped]
    public class ToListViewModel
    {
        public List<Project> Projects { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public List<Status> Statuses { get; set; }
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
    }
}
