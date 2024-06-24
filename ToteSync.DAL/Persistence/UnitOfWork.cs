using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToteSync.DAL.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        public ICategoryRepository CategoryRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IGroupMemberRepository GroupMemberRepository { get; }
        public IItemRepository ItemRepository { get; }
        public IShoppingListRepository ShoppingListRepository { get; }
        public IShoppingListItemRepository ShoppingListItemRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            ApplicationDBContext context,
            ILogger<UnitOfWork> logger,
            ICategoryRepository categoryRepository, 
            IGroupRepository groupRepository, 
            IGroupMemberRepository groupMemberRepository, 
            IItemRepository itemRepository, 
            IShoppingListRepository shoppingListRepository, 
            IShoppingListItemRepository shoppingListItemRepository, 
            IUserRepository userRepository)
        {
            _context = context;
            _logger = logger;
            CategoryRepository = categoryRepository;
            GroupRepository = groupRepository;
            GroupMemberRepository = groupMemberRepository;
            ItemRepository = itemRepository;
            ShoppingListRepository = shoppingListRepository;
            ShoppingListItemRepository = shoppingListItemRepository;
            UserRepository = userRepository;
        }

        public async Task Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("UnitOfWork commit operation encountered an issue: {message}", ex.Message);
                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
