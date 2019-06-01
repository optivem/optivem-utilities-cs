using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Infrastructure.Persistence.Records;
using Optivem.NorthwindLite.Web.Test.Fixture;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

// TODO: VC: Consider moving to base
// [assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Optivem.NorthwindLite.Web.Test
{
    public class CustomersControllerTest : TestFixture
    {
        private List<CustomerRecord> _customerRecords;

        public CustomersControllerTest(TestClient client) : base(client)
        {

        }

        protected override void Startup()
        {
            _customerRecords = new List<CustomerRecord>
            {
                new CustomerRecord
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CustomerRecord
                {
                    FirstName = "John",
                    LastName = "McDonald",
                }
            };

            Fixture.AddRange(_customerRecords);
        }

        [Fact]
        public async Task ListCustomers_OK()
        {
            var actual = await Fixture.Customers.ListCustomersAsync();

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Content;

            Assert.Equal(2, actualContent.Data.Count);

            var expectedFirst = _customerRecords[0];
            var actualFirst = actualContent.Data[0];

            Assert.True(actualFirst.Id > 0);
            Assert.Equal(expectedFirst.FirstName, actualFirst.FirstName);
            Assert.Equal(expectedFirst.LastName, actualFirst.LastName);

            var expectedSecond = _customerRecords[1];
            var actualSecond = actualContent.Data[1];

            Assert.True(actualSecond.Id > 0);
            Assert.Equal(expectedSecond.FirstName, actualSecond.FirstName);
            Assert.Equal(expectedSecond.LastName, actualSecond.LastName);
        }

        [Fact]
        public async Task CreateCustomer_Valid_Created()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Content;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.FirstName, createResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, createResponseContent.LastName);

            var findResponse = await Fixture.Customers.FindCustomerAsync(createResponseContent.Id);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Content;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.FirstName, findResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, findResponseContent.LastName);
        }

        [Fact]
        public async Task CreateCustomer_MissingFirstName_UnprocessableEntity()
        {
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities

            var createRequest = new CreateCustomerRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, createResponse.StatusCode);

            var createResponseContent = createResponse.Content;

            var problemDetails = createResponse.ProblemDetails;

            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }

        [Fact]
        public async Task UpdateCustomer_Valid_OK()
        {
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities

            var customerRecord = _customerRecords[0];

            var updateRequest = new UpdateCustomerRequest
            {
                Id = customerRecord.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.Customers.UpdateCustomerAsync(updateRequest);

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

            var updateResponseContent = updateResponse.Content;

            Assert.Equal(updateRequest.Id, updateResponseContent.Id);
            Assert.Equal(updateRequest.FirstName, updateResponseContent.FirstName);
            Assert.Equal(updateRequest.LastName, updateResponseContent.LastName);
        }
    }
}