using System;
using System.Collections.Generic;
using Project.Bll.Core.Dto;
using Project.Bll.Core.Helpers;
using Project.Bll.Core.Interfaces;

namespace Project.Bll.Core.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ProductService(IProductRepository productRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _productRepository = productRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        //todo На этом же уровне и идет логировка и все сопутсвующие действия. Еслои слишком много - добавляем еще фасад

        public List<ProductModel> GetAll(Filter filter, int skip, int take)
        {
            using (_unitOfWorkFactory.Create())
            {
                return _productRepository.GetAll(filter: filter,
                        skip: skip,
                        take: take)
                    .ToModelsList();
            }
        }

        public void AddNew(ProductModel product)
        {
            using (_unitOfWorkFactory.Create())
            {
                _productRepository.AddNew(product.ToStoredItem());
            }
        }

        public ProductModel GetById(Guid id)
        {
            using (_unitOfWorkFactory.Create())
            {
                return _productRepository.GetById(id).ToModel();
            }
        }

        public void DeleteById(Guid id)
        {
            using (_unitOfWorkFactory.Create())
            {
                _productRepository.DeleteById(id);
            }
        }
    }
}
