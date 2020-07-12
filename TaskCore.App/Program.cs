using CommandCore.Library;

namespace TaskCore.App
{
    class Program
    {
        static int Main(string[] args)
        {
            var commandCoreApp = new CommandCoreApp();
            return commandCoreApp.Parse(args);
        }
    }
}