/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beef;
using Beef.RefData;
using Beef.Demo.Business.DataSvc;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business
{
    /// <summary>
    /// Provides the <see cref="ReferenceData"/> implementation using the corresponding data services.
    /// </summary>
    public class ReferenceDataProvider : RefDataNamespace.ReferenceData
    {
        #region Collections

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.GenderCollection"/>.
        /// </summary>
        public override RefDataNamespace.GenderCollection Gender => (RefDataNamespace.GenderCollection)this[typeof(RefDataNamespace.Gender)];

        #endregion
  
        /// <summary>
        /// Gets the <see cref="IReferenceDataCollection"/> for the associated <see cref="ReferenceDataBase"/> <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="ReferenceDataBase"/> <see cref="Type"/>.</param>
        /// <returns>A <see cref="IReferenceDataCollection"/>.</returns>
        public override IReferenceDataCollection this[Type type] => ReferenceDataDataSvc.GetCollection(type);
        
        /// <summary>
        /// Prefetches all, or the list of <see cref="ReferenceDataBase"/> objects, where not already cached or expired.
        /// </summary>
        /// <param name="names">The list of <see cref="ReferenceDataBase"/> names; otherwise, <c>null</c> for all.</param>
        public override Task PrefetchAsync(params string[] names)
        {
            var types = new List<Type>();
            if (names == null)
            {
                types.AddRange(GetAllTypes());
            }
            else
            {
                foreach (string name in names.Distinct())
                {
                    switch (name)
                    {
                        case var n when string.Compare(n, nameof(RefDataNamespace.Gender), StringComparison.InvariantCultureIgnoreCase) == 0: types.Add(typeof(RefDataNamespace.Gender)); break;
                    }
                }
            }

            Beef.ExecutionContext.FlowSuppression(ecf =>
            {
                Parallel.ForEach(types, (type, _) => { ecf.SetExecutionContext(); var __ = this[type]; });
            });

            return Task.CompletedTask;
        }
    }
}

#pragma warning restore IDE0005
#nullable restore