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
            if (_options.Show)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Local database folder path: \"{_dbRepository.GetPath()}\"");
                Console.ResetColor();
            }
            if (_options.Clear)
            {
                if (_options.Force)
                {
                    _dbRepository.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("If you're sure you want to delete the database folder, rerun this command with --force.");
                    Console.ResetColor();
                    Environment.ExitCode = 105;
                }
            }
        }
    }
}
