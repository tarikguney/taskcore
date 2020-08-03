using CommandCore.Library.PublicBase;
using System;
using TaskCore.App.Options;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Views
{
    public class DatabaseView : VerbViewBase
    {
        private readonly DatabaseOptions _options;
        private readonly IDbRepository _dbRepository;
        public DatabaseView(DatabaseOptions options, IDbRepository dbRepository)
        {
            _options = options;
            _dbRepository = dbRepository;
        }

        public override void RenderResponse()
        {
            if (_options.Clear)
            {
                _dbRepository.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Database folder removed.");
                Console.ResetColor();
                return;
            }
            if (_options.Open)
            {
                _dbRepository.Open();
            }
            if (_options.Show)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Your local database path: \"{_dbRepository.GetPath()}\"");
                Console.ResetColor();
            }
        }
    }
}
