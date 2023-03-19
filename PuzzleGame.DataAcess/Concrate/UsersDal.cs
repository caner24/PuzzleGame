using PuzzleGame.Core.Concrate;
using PuzzleGame.DataAcess.Abstract;
using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.DataAcess.Concrate
{
    public class UsersDal : EfEntityRepositoryBase<Users>, IUsersDal
    {
        public UsersDal(DbConfiguration<Users> dbConfiguration) : base(dbConfiguration)
        {
        }
    }
}
