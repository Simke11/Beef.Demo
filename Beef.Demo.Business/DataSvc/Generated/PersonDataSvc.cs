/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Beef.Demo.Business.Data;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.DataSvc
{
    /// <summary>
    /// Provides the Person data repository services.
    /// </summary>
    public static partial class PersonDataSvc
    {
        #region Private
        #pragma warning disable CS0649 // Defaults to null by design; can be overridden in constructor.

        private static readonly Func<Person?, Guid, Task>? _getOnAfterAsync;
        private static readonly Func<Person, Task>? _createOnAfterAsync;
        private static readonly Func<Person, Task>? _updateOnAfterAsync;
        private static readonly Func<Guid, Task>? _deleteOnAfterAsync;
        private static readonly Func<PersonCollectionResult, PersonArgs?, PagingArgs?, Task>? _getByArgsOnAfterAsync;

        #pragma warning restore CS0649
        #endregion

        /// <summary>
        /// Gets the <see cref="Person"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="Person"/> object where found; otherwise, <c>null</c>.</returns>
        public static Task<Person?> GetAsync(Guid id)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __key = new UniqueKey(id);
                if (ExecutionContext.Current.TryGetCacheValue<Person>(__key, out Person __val))
                    return __val;

                var __result = await Factory.Create<IPersonData>().GetAsync(id).ConfigureAwait(false);
                ExecutionContext.Current.CacheSet(__key, __result!);
                if (_getOnAfterAsync != null) await _getOnAfterAsync(__result, id).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Creates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public static Task<Person> CreateAsync(Person value)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await Factory.Create<IPersonData>().CreateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await Beef.Events.Event.PublishValueEventAsync(__result, $"Beef.Demo.Person.{__result.Id}", "Create").ConfigureAwait(false);
                ExecutionContext.Current.CacheSet(__result.UniqueKey, __result);
                if (_createOnAfterAsync != null) await _createOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public static Task<Person> UpdateAsync(Person value)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await Factory.Create<IPersonData>().UpdateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await Beef.Events.Event.PublishValueEventAsync(__result, $"Beef.Demo.Person.{__result.Id}", "Update").ConfigureAwait(false);
                ExecutionContext.Current.CacheSet(__result.UniqueKey, __result);
                if (_updateOnAfterAsync != null) await _updateOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Deletes the <see cref="Person"/> object.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        public static Task DeleteAsync(Guid id)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                await Factory.Create<IPersonData>().DeleteAsync(id).ConfigureAwait(false);
                await Beef.Events.Event.PublishEventAsync($"Beef.Demo.Person.{id}", "Delete", id).ConfigureAwait(false);
                ExecutionContext.Current.CacheRemove<Person>(new UniqueKey(id));
                if (_deleteOnAfterAsync != null) await _deleteOnAfterAsync(id).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="PersonArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="PersonCollectionResult"/>.</returns>
        public static Task<PersonCollectionResult> GetByArgsAsync(PersonArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await Factory.Create<IPersonData>().GetByArgsAsync(args, paging).ConfigureAwait(false);
                if (_getByArgsOnAfterAsync != null) await _getByArgsOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                return __result;
            });
        }
    }
}

#pragma warning restore IDE0005
#nullable restore