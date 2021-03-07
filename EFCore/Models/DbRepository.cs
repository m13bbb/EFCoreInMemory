using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class DbRepository : IServiceRepository
    {
        private readonly ServiceContext _db;

        public DbRepository(ServiceContext db)
        {
            _db = db;
        }

        public IQueryable<Team> Teams => _db.Teams;
        public IQueryable<TeamMember> TeamMembers => _db.TeamMembers;

        public void Add<EntityType>(EntityType entity) => _db.Add(entity);
        public void SaveChanges() => _db.SaveChanges();
    }
}
