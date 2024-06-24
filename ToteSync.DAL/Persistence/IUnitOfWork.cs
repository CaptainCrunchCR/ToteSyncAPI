using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToteSync.DAL.Persistence
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task Commit();

        ICategoryRepository CategoryRepository { get; }
        IGroupRepository GroupRepository { get; }
        IGroupMemberRepository GroupMemberRepository { get; }
        IItemRepository ItemRepository { get; }
        IShoppingListRepository ShoppingListRepository { get; }
        IShoppingListItemRepository ShoppingListItemRepository { get; }
        IUserRepository UserRepository { get; }
        
    }
}
