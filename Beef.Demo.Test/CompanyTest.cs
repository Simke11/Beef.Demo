using Beef;
using Beef.Test.NUnit;
using Beef.WebApi;
using Beef.Demo.Business.Validation;
using Beef.Demo.Common.Agents;
using Beef.Demo.Common.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Beef.Demo.Test
{
    [TestFixture, NonParallelizable]
    public class CompanyTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp() => TestSetUp.Reset();

        #region Validators

        [Test, TestSetUp]
        public void A110_Validation_Empty()
        {
            ExpectValidationException.Throws(
                () => CompanyValidator.Default.Validate(new Company()).ThrowOnError(),
                "Name is required.",
                "Address is required.",
                "Phone is required.");
        }

        [Test, TestSetUp]
        public void A120_Validation_Invalid()
        {
            ExpectValidationException.Throws(
                () => CompanyValidator.Default.Validate(new Company { Name = 'x'.ToLongString(), Address = "123 Test Rd", Phone = "12345" }).ThrowOnError(),
                "Name must not exceed 100 characters in length.");
        }

        #endregion

        #region Get

        [Test, TestSetUp]
        public void B110_Get_NotFound()
        {
            AgentTester.Create<CompanyAgent, Company>()
                .ExpectStatusCode(HttpStatusCode.NotFound)
                .ExpectErrorType(Beef.ErrorType.NotFoundError)
                .Run((a) => a.Agent.GetAsync(404.ToGuid()));
        }

        [Test, TestSetUp]
        public void B120_Get_Found()
        {
            AgentTester.Create<CompanyAgent, Company>()
                .ExpectStatusCode(HttpStatusCode.OK)
                .IgnoreChangeLog()
                .IgnoreETag()
                .ExpectValue((t) => new Company
                {
                    Id = 1.ToGuid(),
                    Name = "RobCo Industries",
                    Address = "123 Test Road",
                    Phone = "123456789"
                })
                .Run((a) => a.Agent.GetAsync(1.ToGuid()));
        }

        [Test, TestSetUp]
        public void B130_GetAll()
        {
            var result = AgentTester.Create<CompanyAgent, CompanyCollectionResult>()
                .ExpectStatusCode(HttpStatusCode.OK)
                .Run((a) => a.Agent.GetAllAsync()).Value.Result;

            Assert.IsTrue(result.Count == 2);
        }

        #endregion
    }
}