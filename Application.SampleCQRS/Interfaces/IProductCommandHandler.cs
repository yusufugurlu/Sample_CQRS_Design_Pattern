using Application.SampleCQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SampleCQRS.Interfaces
{
    public interface IProductCommandHandler
    {
        Task Handle(CreateProductCommand command);
        Task Handle(UpdateProductCommand command);
        Task Handle(DeleteProductCommand command);
    }
}
