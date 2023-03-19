using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.Core.Abstract
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
