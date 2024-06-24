using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToteSync.Domain.Models;

namespace ToteSync.DAL.Persistence
{
    public class ShoppingListItemRepository : BaseRepository<ShoppingListItem>, IShoppingListItemRepository
    {
        public ShoppingListItemRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
