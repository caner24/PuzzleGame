using PuzzleGame.Core.Concrate;
using PuzzleGame.DataAcess.Abstract;
using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.DataAcess.Concrate
{
    public class PuzzleDal : EfEntityRepositoryBase<Puzzless>, IPuzzlesDal
    {
        public PuzzleDal(DbConfiguration<Puzzless> dbConfiguration) : base(dbConfiguration)
        {
        }
    }
}
