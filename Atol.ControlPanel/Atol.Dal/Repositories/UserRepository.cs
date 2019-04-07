using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Bll.Core;
using Project.Bll.Core.Dto;
using Project.Bll.Core.Interfaces;
using Project.Bll.Core.StoredItems;

namespace Project.Dal.Ef.Repositories
{
    public class UserRepository:IUserRepository
    {
        public IEnumerable<UserStoredItem> GetAll(Filter filter, int skip, int take)
        {
            EfUnitOfWork.ThrowIfNoContext();

            //todo фильтр можно припилить на что угодно, это пример
            return EfUnitOfWork.Context.Users
                .Where(u => u.Name.Contains(filter.AnythingContains))
                .Skip(skip)
                .Take(take)
                .OrderByDescending(u => u.Name);
        }

        public void AddNew(UserStoredItem user)
        {
            EfUnitOfWork.ThrowIfNoContext();
            EfUnitOfWork.Context.Users.Add(user);
        }

        public UserStoredItem GetById(Guid id)
        {
            EfUnitOfWork.ThrowIfNoContext();
            return EfUnitOfWork.Context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void DeleteById(Guid id)
        {
            EfUnitOfWork.ThrowIfNoContext();
            var user = GetById(id) ?? throw new ArgumentNullException($"Пользователя с {id} нет в базе");
            EfUnitOfWork.Context.Users.Remove(user);
        }
    }
}
