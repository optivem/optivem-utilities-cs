﻿using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class UpdateProductUseCase : UpdateAggregateUseCase<IProductRepository, UpdateProductRequest, UpdateProductResponse, Product, ProductIdentity, int>
    {
        public UpdateProductUseCase(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        protected override Task UpdateAsync(UpdateProductRequest request, Product aggregateRoot)
        {
            aggregateRoot.ProductName = request.Description;
            aggregateRoot.ListPrice = request.UnitPrice;

            return Task.CompletedTask;
        }
    }
}