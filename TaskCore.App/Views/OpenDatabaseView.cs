using CommandCore.Library.PublicBase;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Views
{
    public class OpenDatabaseView : VerbViewBase
    {
        private readonly IDbRepository _dbRepository;
        public OpenDatabaseView(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public override void RenderResponse()
        {
            _dbRepository.Open();
        }
    }
}