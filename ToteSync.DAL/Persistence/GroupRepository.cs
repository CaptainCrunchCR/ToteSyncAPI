using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToteSync.DAL.Persistence
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext context) : base(context)
        {
        }
    }
}
