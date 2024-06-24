using Microsoft.EntityFrameworkCore;
using ToteSync.DAL;
using ToteSync.DAL.Persistence;


var options = new DbContextOptionsBuilder<ApplicationDBContext>()
    .UseInMemoryDatabase(databaseName: "PlaygroundTestToteSyncDB")
    .Options;

using (var context = new ApplicationDBContext(options)) 
{
    context.Database.EnsureCreated();

    var userRepository = new UserRepository(context);

    var userList = await userRepository.GetAllAsync();

    foreach (var user in userList) {
        Console.WriteLine(user.UserName);
    }
}