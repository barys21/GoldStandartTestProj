using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public int? UserId { get; set; }    //ProjectAdminId
        public User User { get; set; }     //ProjectAdmin
        public List<ProjectTask> ProjectTasks { get; set; }                
    }

    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? StatusId { get; set; }
        public Status Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        
    }
}
