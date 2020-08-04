using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("show", Description = "Shows your local database path in console.")]
    public class ShowDatabase : VerbBase<ShowDatabaseOpitons>
    {
        private readonly IDbRepository _dbRepository;
        public ShowDatabase(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public override VerbViewBase Run()
        {
            return new ShowDatabaseView(_dbRepository);
        }
    }
}
