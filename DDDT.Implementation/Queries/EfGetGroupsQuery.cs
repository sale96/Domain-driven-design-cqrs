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

        public PagedResponse<GroupDto> Execute(GroupSearch search)
        {
            var query = _context.Groups.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<GroupDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new GroupDto { Id = x.Id, Name = x.Name}).ToList()
            };

            return response;
        }
    }
}
