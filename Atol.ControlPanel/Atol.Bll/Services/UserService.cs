using System;
using System.Collections.Generic;
using Project.Bll.Core.Dto;
using Project.Bll.Core.Helpers;
using Project.Bll.Core.Interfaces;

namespace Project.Bll.Core.Services
{
    public class UserService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWorkFactory unitOfWorkFactory, IUserRepository userRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
        }

        public List<UserModel> GetAll(Filter filter, int skip, int take)
        {
            using (_unitOfWorkFactory.Create())
            {
                return _userRepository.GetAll(filter: filter, 
                                              skip: skip, 
                                              take: take)
                                      .ToModelsList();
            }
        }

        public void AddNew(UserModel user)
        {
            using (_unitOfWorkFactory.Create())
            {
                _userRepository.AddNew(user.ToStoredItem());
            }
        }

        public UserModel GetById(Guid id)
        {
            using (_unitOfWorkFactory.Create())
            {
                return _userRepository.GetById(id).ToModel();
            }
        }

        public void DeleteById(Guid id)
        {
            using (_unitOfWorkFactory.Create())
            {
                _userRepository.DeleteById(id);
            }
        }
    }
}