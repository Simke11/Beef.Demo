using Beef;
using Beef.Data.Database;
using Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    public partial class PersonData
    {
        public PersonData()
        {
            _getByArgsOnQuery = GetByArgsOnQuery;
        }

        private void GetByArgsOnQuery(DatabaseParameters p, PersonArgs? args, IDatabaseArgs dbArgs)
        {
            p.ParamWithWildcard(args?.FirstName, DbMapper.Default[nameof(Person.FirstName)])
             .ParamWithWildcard(args?.LastName, DbMapper.Default[nameof(Person.LastName)])
             .TableValuedParamWith(args?.Genders, "GenderCodes", () => TableValuedParameter.Create(args!.Genders!.ToCodeList()));
        }
    }
}