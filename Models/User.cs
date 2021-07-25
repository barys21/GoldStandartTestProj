using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Project> Projects { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        
    }

    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<User> Users { get; set; }
        
    }
}
