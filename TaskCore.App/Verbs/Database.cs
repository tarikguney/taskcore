using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("database", Description = "Commands to do database operations")]
    public class Database : VerbBase<DatabaseOptions>
    {
        private readonly IDbRepository _dbRepository;
        public Database(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public override VerbViewBase Run()
        {
            if (Options.Open)
            {
                _dbRepository.Open();
            }

            return new DatabaseView(Options, _dbRepository);
        }
    }
}
