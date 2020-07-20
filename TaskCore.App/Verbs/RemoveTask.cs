using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("rm", Description = "Deletes a given task.")]
    public class RemoveTask : VerbBase<RemoveTaskOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public RemoveTask(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public override VerbViewBase Run()
        {
            // For simplicity, we are using the order number of the task as the id of it. Otherwise, it would be 
            // hard for the users to type the full id number. That's why the TaskOrder is mapped to ID even though
            // it is just a user construct.
            var activeTasks = _todoTaskRepository.GetActiveTasksOrderedByAddedDate();
            // TODO check if the index is out of the bound
            var task = activeTasks[Options.TaskOrder];
            _todoTaskRepository.Delete(task);
            return new RemoveTaskView(task);
        }
    }
}