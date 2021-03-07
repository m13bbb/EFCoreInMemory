using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public interface IServiceRepository
    {
        public IQueryable<Team> Teams { get; }
        public IQueryable<TeamMember> TeamMembers { get; }
        void Add<EntityType>(EntityType entity);

        void SaveChanges();
    }
}
