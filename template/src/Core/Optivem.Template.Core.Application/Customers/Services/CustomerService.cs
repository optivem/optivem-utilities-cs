﻿using Optivem.Core.Application;
using Optivem.Core.Application.Services;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<BrowseCustomersResponse> BrowseCustomersAsync(BrowseCustomersRequest request)
        {
            return HandleAsync<BrowseCustomersRequest, BrowseCustomersResponse>(request);
        }

        public Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return HandleAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }

        public Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            return HandleAsync<DeleteCustomerRequest, DeleteCustomerResponse>(request);
        }

        public Task<FindCustomerResponse> FindCustomerAsync(FindCustomerRequest request)
        {
            return HandleAsync<FindCustomerRequest, FindCustomerResponse>(request);
        }

        public Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request)
        {
            return HandleAsync<ListCustomersRequest, ListCustomersResponse>(request);
        }

        public Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return HandleAsync<UpdateCustomerRequest, UpdateCustomerResponse>(request);
        }

    }
}