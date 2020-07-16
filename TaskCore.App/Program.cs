using CommandCore.Library;
using TaskCore.Dal.FileSystem;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App
{
    class Program
    {
        static int Main(string[] args)
        {
            var commandCoreApp = new CommandCoreApp();
            commandCoreApp.ConfigureServices(sp =>
            {
                sp.Register<ITodoTaskRepository, TodoTaskRepository>();
                sp.Register<IPriorityColorChooser, PriorityColorChooser>();
            });
            return commandCoreApp.Parse(args);
        }
    }
}