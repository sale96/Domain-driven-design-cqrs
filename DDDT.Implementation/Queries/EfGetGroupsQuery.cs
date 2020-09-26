using DDDT.Application.DataTransfer;
using DDDT.Application.Queries;
using DDDT.Application.Searches;
using DDDT.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDT.Implementation.Queries
{
    public class EfGetGroupsQuery : IGetGroupsQuery
    {
        private readonly DDDTContext _context;

        public EfGetGroupsQuery(DDDTContext context)
        {
            _context = context;
        }

        public int Id => 4;

        public string Name => "Group search";

        public IEnumerable<GroupDto> Excute(GroupSearch search)
        {
            var query = _context.Groups.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Select(x => new GroupDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
