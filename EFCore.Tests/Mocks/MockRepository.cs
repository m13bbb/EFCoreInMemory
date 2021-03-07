using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Tests.Mocks
{
    internal class MockRepository : IServiceRepository
    {
        private readonly List<Team> _teams = new List<Team>();
        private readonly List<TeamMember> _teamMembers = new List<TeamMember>();

        public IQueryable<Team> Teams => _teams.AsQueryable();
        public IQueryable<TeamMember> TeamMembers => _teamMembers.AsQueryable();

        public void Add<EntityType>(EntityType entity)
        {
            switch (entity)
            {
                
                case TeamMember teamMember:
                    _teamMembers.Add(teamMember);
                    break;
                case Team team:
                    _teams.Add(team);
                    break;
            }
        }

        public void SaveChanges()
        {
        }
    }
}
