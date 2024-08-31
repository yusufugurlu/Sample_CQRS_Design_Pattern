using Application.SampleCQRS.Queries;
using Core.SampleCQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SampleCQRS.Interfaces
{
    public interface IProductQueryHandler
    {
        Task<Product> Handle(GetProductByIdQuery query);
        Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    }
}
