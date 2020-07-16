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
            _todoTaskRepository.Add(new TodoTask()
            {
                Title = Options.Title,
                DueDateTime = DateTime.Parse(Options.DueDate),
                CategoryId = Options.Category,
                Priority = Options.Priority
            });
            return new AddTaskView(
                $"Title: {Options.Title}\nPriority: {Options.Priority}\nCategory: {Options.Category}\nDue Date: {Options.DueDate}");
        }
    }
}