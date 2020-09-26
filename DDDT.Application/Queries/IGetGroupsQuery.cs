using DDDT.Application.DataTransfer;
using DDDT.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDT.Application.Queries
{
    public interface IGetGroupsQuery : IQuery<GroupSearch, IEnumerable<GroupDto>>
    {
    }
}
