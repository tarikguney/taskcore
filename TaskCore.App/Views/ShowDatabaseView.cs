using CommandCore.Library.PublicBase;
using System;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Views
{
    public class ShowDatabaseView : VerbViewBase
    {
        private readonly IDbRepository _dbRepository;
        public ShowDatabaseView(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your local database path: {0}", _dbRepository.Show());
            Console.ResetColor();
        }
    }
}