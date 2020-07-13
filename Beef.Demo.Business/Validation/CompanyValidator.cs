using Beef.Validation;
using System;
using Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Validation
{
    /// <summary>
    /// Represents a <see cref="Person"/> validator.
    /// </summary>
    public class CompanyValidator : Validator<Company, CompanyValidator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonValidator"/> class.
        /// </summary>
        public CompanyValidator()
        {
            Property(x => x.Name).Mandatory().String(100);
            Property(x => x.Address).Mandatory().String(250);
            Property(x => x.Phone).Mandatory();
        }
    }
}