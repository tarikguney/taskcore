using System;
using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

namespace TaskCore.App.Verbs
{
    [VerbName("add", Description = "Adds a new task.")]
    public class AddTask : VerbBase<AddTaskOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public AddTask(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public override VerbViewBase Run()
        {
            // TODO Perform some input validation here, for required fields, etc.
            _todoTaskRepository.Add(new TodoTask()
            {
                Title = Options.Title,
                DueDateTime = Options.DueDate != null
                    ? DateTime.Parse(Options.DueDate)
                    : (DateTime?) null,
                //TODO check if the category exists first, otherwise show a message. The category must be case-insensitive
                CategoryId = Options.Category,
                Priority = Options.Priority,
                Completed = Options.Completed
            });

            return new AddTaskView(Options);
        }
    }
}