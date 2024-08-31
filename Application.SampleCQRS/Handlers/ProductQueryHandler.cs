using Application.SampleCQRS.Interfaces;
using Application.SampleCQRS.Queries;
using Core.SampleCQRS.Entities;
using Core.SampleCQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SampleCQRS.Handlers
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(GetProductByIdQuery query)
        {
            return await _unitOfWork.Products.GetByIdAsync(query.Id);
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
        {
            return await _unitOfWork.Products.GetAllAsync();
        }
    }
}
