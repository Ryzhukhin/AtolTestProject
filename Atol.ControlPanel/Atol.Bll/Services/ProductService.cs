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

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //todo На этом же уровне и идет логировка и все сопутсвующие действия. Еслои слишком много - добавляем еще фасад

        public List<ProductModel> GetAll(Filter filter, int skip, int take) =>
            _productRepository.GetAll(filter: filter,
                                      skip: skip,
                                      take: take)
                .ToModelsList();

        public void AddNew(ProductModel product) 
            => _productRepository.AddNew(product.ToStoredItem());

        public ProductModel GetById(Guid id)
            => _productRepository.GetById(id).ToModel();

        public void DeleteById(Guid id)
            => _productRepository.DeleteById(id);
    }
}
