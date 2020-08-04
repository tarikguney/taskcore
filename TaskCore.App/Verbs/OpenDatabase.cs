using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("open", Description = "Opens your local database folders with your file manager.")]
    public class OpenDatabase : VerbBase<OpenDatabaseOptions>
    {
        private readonly IDbRepository _dbRepository;
        public OpenDatabase(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public override VerbViewBase Run()
        {
            return new OpenDatabaseView(_dbRepository);
        }
    }
}
