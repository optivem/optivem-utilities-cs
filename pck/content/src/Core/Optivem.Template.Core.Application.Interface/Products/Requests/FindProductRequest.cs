﻿using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Products.Responses;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class FindProductRequest : IRequest<FindProductResponse, int>
    {
        public int Id { get; set; }
    }
}