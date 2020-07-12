/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Threading.Tasks;
using Beef.RefData;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Provides a standard mechanism for accessing the <b>ReferenceData</b>. 
    /// </summary>
    public abstract partial class ReferenceData : IReferenceDataProvider
    {
        private static ReferenceData? _current;

        /// <summary>
        /// Gets the current <see cref="ReferenceData"/> instance; uses the <see cref="ReferenceDataManager.Register(IReferenceDataProvider[])">registered</see> instance from the
        /// <see cref="ReferenceDataManager.GetProvider(string)"/> using the defined <see cref="IReferenceDataProvider.ProviderName"/>.
        /// </summary>
        public static ReferenceData Current => _current ?? (_current = (ReferenceData)ReferenceDataManager.Current.GetProvider(typeof(ReferenceData).FullName));

        /// <summary>
        /// Gets the unique provider name.
        /// </summary>
        public string ProviderName => typeof(ReferenceData).FullName;

        /// <summary>
        /// Gets all the underlying <see cref="ReferenceDataBase"/> <see cref="Type">types</see>.
        /// </summary>
        /// <returns>An array of the <see cref="ReferenceDataBase"/> <see cref="Type">types</see>.</returns>
        public Type[] GetAllTypes() => new Type[] 
            {
                typeof(Gender)
            };
        
        /// <summary>
        /// Gets the <see cref="IReferenceDataCollection"/> for the associated <see cref="ReferenceDataBase"/> <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The associated <see cref="ReferenceDataBase"/> <see cref="Type"/>.</param>
        /// <returns>The corresponding <see cref="IReferenceDataCollection"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1043:Use Integral Or String Argument For Indexers", Justification = "Logical for type")]
        public abstract IReferenceDataCollection this[Type type] { get; }

        /// <summary>
        /// Prefetches all of the named <see cref="ReferenceDataBase"/> objects.
        /// </summary>
        /// <param name="names">The list of <see cref="ReferenceDataBase"/> names.</param>
        /// <remarks>Note for implementers; should only fetch where not already cached or expired. This is provided to improve performance for consuming applications to reduce the overhead of
        /// making multiple individual invocations, i.e. reduces chattiness across a potentially high-latency connection.</remarks>
        public abstract Task PrefetchAsync(params string[] names);
        
        #region Collections

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.GenderCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.GenderCollection Gender { get; }

        #endregion
    }
}

#pragma warning restore IDE0005
#nullable restore