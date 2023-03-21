using Ninject.Modules;
using PuzzleGame.Business.Abstract;
using PuzzleGame.Business.Concrate;
using PuzzleGame.Core.Abstract;
using PuzzleGame.DataAcess.Abstract;
using PuzzleGame.DataAcess.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.Business.DepencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IPuzzlesDal>().To<PuzzleDal>().InSingletonScope();
            Bind<IUsersDal>().To<UsersDal>().InSingletonScope();

            Bind<IPuzzleService>().To<PuzzleService>().InSingletonScope();
            Bind<IUsersService>().To<UsersService>().InSingletonScope();

        }
    }
}
