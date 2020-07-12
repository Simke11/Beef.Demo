/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef.Business;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.Data.Database;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the <b>ReferenceData</b> database access.
    /// </summary>
    public partial class ReferenceDataData : IReferenceDataData
    {
        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Gender"/> objects.
        /// </summary>
        /// <returns>A <see cref="RefDataNamespace.GenderCollection"/>.</returns>
        public async Task<RefDataNamespace.GenderCollection> GenderGetAllAsync()
        {
            var __coll = new RefDataNamespace.GenderCollection();
            await DataInvoker.Default.InvokeAsync(this, async () => 
            {
                await DemoDb.Default.GetRefDataAsync<RefDataNamespace.GenderCollection, RefDataNamespace.Gender>(__coll, "[Ref].[spGenderGetAll]", "GenderId");
            }, BusinessInvokerArgs.RequiresNewAndTransactionSuppress).ConfigureAwait(false);

            return __coll;
        }
    }
}

#pragma warning restore IDE0005
#nullable restore