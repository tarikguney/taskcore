using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("clear", Description = "Remove database folder.")]
    public class ClearDatabase : VerbBase<ClearDatabaseOptions>
    {
        private readonly IDbRepository _dbRepository;

        public ClearDatabase(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public override VerbViewBase Run()
        {
            if (!Options.Force)
            {
                return new ClearDatabaseErrorView(Options);
            }
            
            _dbRepository.Clear();
            return new ClearDatabaseView(Options);
        }
    }
}
