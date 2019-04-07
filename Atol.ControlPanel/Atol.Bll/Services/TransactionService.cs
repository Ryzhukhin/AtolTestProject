using System;
using System.Collections.Generic;
using Project.Bll.Core.Dto;
using Project.Bll.Core.Helpers;
using Project.Bll.Core.Interfaces;
using Project.Bll.Core.StoredItems;

namespace Project.Bll.Core.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWorkFactory unitOfWorkFactory, IUserRepository userRepository, IProductRepository productRepository)
        {
            _transactionRepository = transactionRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public List<TransactionModel> GetAll(Filter filter, int skip, int take)
        {
            using (_unitOfWorkFactory.Create())
            {
                return _transactionRepository
                    .GetAll(filter: filter, 
                            skip: skip, 
                            take: take)
                    .ToModelsList();
            }
        }

        public void AddNew(UserModel userModel, ProductModel productModel)
        {
            using (_unitOfWorkFactory.Create())
            {
                var user = _userRepository.GetById(userModel.Id);
                var product = _productRepository.GetById(productModel.Id);
                var transaction = new TransactionModel()
                {
                    Product = product,
                    User = user
                };
                _transactionRepository.AddNew(transaction.ToStoredItem());
            }
        }

        public TransactionModel GetById(Guid id)
        {
            using (_unitOfWorkFactory.Create())
            {
                return _transactionRepository.GetById(id).ToModel();
            }
        }

    }
}