using NUnit.Framework;
using PuzzleGame.Business.Abstract;
using PuzzleGame.Business.DepencyResolvers.Ninject;
using PuzzleGame.Entities.Concrate;

namespace PuzzleGame.Business.Tests
{
    public class Tests
    {
        IUsersService _usersService;
        [SetUp]
        public void Setup()
        {
            _usersService = InstanceFactory.GetInstance<IUsersService>();
        }

        [Test]
        public void Test1()
        {
            Users user = new Users() { username = "caner" };

            var returnUser = _usersService.CreateAsync(user);

            Assert.NotNull(returnUser);
        }
    }
}