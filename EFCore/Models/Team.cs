using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
