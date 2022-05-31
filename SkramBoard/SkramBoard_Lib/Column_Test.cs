using ScrumBoard.Task;
using ScrumBoard.Column;
using Task = ScrumBoard.Task.Task;

namespace ScrumBoardTest
{
    public class ColumnTest
    {
        [Fact]
        public void CreateColumn()
        {
            string columnName = "Колонка";
            IColumn column = new Column(columnName);
            Assert.False(string.IsNullOrEmpty(column.id));
            Assert.Equal(columnName, column.Name);
        }

        [Fact]
        public void ChangeColumnName_NameWillBeChanged()
        {
            string newColumnName = "Новая колонка";
            IColumn column = new Column("Колонка");
            column.Name = newColumnName;
            Assert.Equal(newColumnName, column.Name);
        }

        [Fact]
        public void AddTaskInColumn_TaskWillBeAddedInColumn()
        {
            string columnName = "Колонка";
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn column = new Column(columnName);
            column.AddTask(task);
            Assert.Equal(task, column.FindTask(task.id));
        }

        [Fact]
        public void EditTaskInColumn_TaskWillBeChangedInColumn()
        {
            string newTaskName = "Новая задача";
            string newTaskDescription = "Новое описание";
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn column = new Column("Колонка");
            column.AddTask(task);
            column.EditTask(task.id, newTaskName, newTaskDescription, TaskRating.Medium);
            ITask? returnedTask = column.FindTask(task.id);
            Assert.Equal(newTaskName, returnedTask.Name);
            Assert.Equal(newTaskDescription, returnedTask.Description);
            Assert.Equal(TaskRating.Medium, returnedTask.Rating);
        }

        [Fact]
        public void FindTaskFromColumn_TaskWillBeReturnedFromColumn()
        {
            ITask task = new Task("Задача", "Описание", TaskRating.Medium);
            IColumn column = new Column("Колонка");
            column.AddTask(task);
            ITask? returnedTask = column.FindTask(task.id);
            Assert.Equal(task, returnedTask);
        }

        [Fact]
        public void DeleteTaskInColumn_TaskWillBeDeleted()
        {
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn column = new Column("Колонка");
            column.AddTask(task);
            column.DeleteTask(task.id);
            Assert.Null(column.FindTask(task.id));
        }
    }
}