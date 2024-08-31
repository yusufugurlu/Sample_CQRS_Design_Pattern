using Application.SampleCQRS.Commands;
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
    public class ProductCommandHandler : IProductCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product { Name = command.Name, Price = command.Price };
            _unitOfWork.Products.Add(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Handle(UpdateProductCommand command)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            product.Name = command.Name;
            product.Price = command.Price;
            _unitOfWork.Products.Update(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Handle(DeleteProductCommand command)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
