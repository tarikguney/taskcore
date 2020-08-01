using System;
using System.Globalization;
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
        private readonly ICategoryRepository _categoryRepository;

        public AddTask(ITodoTaskRepository todoTaskRepository, ICategoryRepository categoryRepository)
        {
            _todoTaskRepository = todoTaskRepository;
            _categoryRepository = categoryRepository;
        }

        public override VerbViewBase Run()
        {
            if (string.IsNullOrWhiteSpace(Options.Title))
            {
                return new AddTaskRequiredFieldsMissingView();
            }

            Category category = new Category();
            // Inbox is the default category, which cannot be deleted, added, or edited.
            if (string.IsNullOrWhiteSpace(Options.Category))
            {
                category.Name = "Inbox";
            }
            else if (_categoryRepository.GetByName(Options.Category) == null)
            {
                return new AddTaskNoCategoryView(Options.Category);
            }
            else
            {
                category.Name = Options.Category;
            }

            if (!string.IsNullOrWhiteSpace(Options.DueDate))
            {
                string loweredDueDate = Options.DueDate.ToLower();

                var isDueDateNumeric = double.TryParse(loweredDueDate, out _);

                if (isDueDateNumeric)
                {
                    Options.DueDate = DateTime.Now.AddDays(double.Parse(loweredDueDate)).ToShortDateString();
                }
                else
                {
                    if (loweredDueDate == "today")
                    {
                        Options.DueDate = DateTime.Now.ToShortDateString();
                    }
                    else if (loweredDueDate == "tomorrow")
                    {
                        Options.DueDate = DateTime.Now.AddDays(1).ToShortDateString();
                    }
                    else if (loweredDueDate == "nextweek")
                    {
                        Options.DueDate = DateTime.Now.AddDays(7).ToShortDateString();
                    }
                    else if (loweredDueDate == "nextmonth")
                    {
                        Options.DueDate = DateTime.Now.AddDays(30).ToShortDateString();
                    }
                    else
                    {
                        Options.DueDate = null;
                    }
                }
            }

            // TODO Perform some input validation here, for required fields, etc.
            _todoTaskRepository.Add(new TodoTask()
            {
                Title = Options.Title,
                DueDateTime = Options.DueDate != null
                    ? DateTimeOffset.Parse(Options.DueDate, CultureInfo.CurrentCulture)
                    : (DateTimeOffset?)null,
                // CategoryId is a getter only hash value so we don't need to make a DB call to get it by the category name.
                CategoryId = category.CategoryId,
                Priority = Options.Priority,
                Completed = Options.Completed,
                CreationDate = DateTimeOffset.Now
            });

            return new AddTaskView(Options, category);
        }
    }
}