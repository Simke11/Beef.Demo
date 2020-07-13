using Beef.Data.Database;
using Beef.Demo.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beef.Demo.Business.Data
{
    public partial class CompanyData
    {
        private async Task<CompanyCollectionResult> GetAllOnImplementationAsync()
        {
            var sp = DemoDb.Default.StoredProcedure("[Demo].[spCompanyGetAll]");

            var companies = new CompanyCollectionResult();

            await sp.SelectQueryMultiSetAsync(new MultiSetCollArgs<CompanyCollection, Company>(CompanyData.DbMapper.Default, (r) => companies.Result = r));

            return companies;
        }
    }
}