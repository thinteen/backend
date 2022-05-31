using ScrumBoard.Task;
using ScrumBoard.Column;
using ScrumBoard.Board;
using Task = ScrumBoard.Task.Task;

namespace ScrumBoardTest
{
    public class BoardTest
    {
        [Fact]
        public void CreateBoard()
        {
            string boardName = "Доска";
            IBoard board = new Board(boardName);
            Assert.Equal(boardName, board.Name);
        }

        [Fact]
        public void AddColumnInBoard_ColumnWillBeAddedInBoard()
        {
            IColumn column = new Column("Колонка");
            IBoard board = new Board("Доска");
            board.AddColumn(column);
            Assert.Equal(column, board.FindColumn(column.id));
        }

        [Fact]
        public void AddExistColumnInBoard_ExeptionWillBeReturned()
        {
            IBoard board = new Board("Доска");
            IColumn column = new Column("Колонка");
            board.AddColumn(column);
            Assert.Throws<Exception>(() => board.AddColumn(column));
        }

        [Fact]
        public void AddExtraColumnInBoard_ExeptionWillBeReturned()
        {
            IBoard board = new Board("Доска");
            for (int i = 1; i <= 10; i++)
                board.AddColumn(new Column("Колонка" + i));
            Assert.Throws<Exception>(() => board.AddColumn(new Column("11")));
        }

        [Fact]
        public void EditColumnNameInBoard_ColumnNameWillBeChanged()
        {
            string newColumnName = "Новое название колонки";
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            board.RedactColumnName(column.id, newColumnName);
            Assert.Equal(newColumnName, column.Name);
        }

        [Fact]
        public void FindColumnInBoard_ColumnWillBeReturned()
        {
            IColumn column = new Column("Колонка");
            IBoard board = new Board("Доска");
            board.AddColumn(column);
            IColumn returnedColumn = board.FindColumn(column.id);
            Assert.Equal(column, returnedColumn);
        }

        [Fact]
        public void FindNotExistColumnInBoard_ExeptionWillBeReturned()
        {
            IBoard board = new Board("Доска");
            Assert.Throws<Exception>(() => board.FindColumn(""));
        }

        [Fact]
        public void DeleteColumnInBoard_ColumnWillBeDeleted()
        {
            IColumn column = new Column("Колонка");
            IBoard board = new Board("Доска");
            board.AddColumn(column);
            board.DeleteColumn(column.id);
            Assert.Throws<Exception>(() => board.FindColumn(column.id));
        }

        [Fact]
        public void DeleteNotExistColumnInBoard_ExeptionWillBeReturned()
        {
            IBoard board = new Board("Доска");
            Assert.Throws<Exception>(() => board.DeleteColumn(""));
        }

        [Fact]
        public void AddTaskInBoardInColumn_TaskWillBeAdded()
        {
            ITask task = new Task("Задача", "Описание задачи", TaskRating.Low);
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            board.AddTask(task);
            Assert.Equal(task, column.FindTask(task.id));
        }

        [Fact]
        public void AddTaskInBoardInNumColumn_TaskWillBeAdded()
        {

            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn first_column = new Column("Название первой колонки");
            IColumn second_column = new Column("Название второй колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(first_column);
            board.AddColumn(second_column);
            board.AddTask(task, 1);
            Assert.Equal(task, second_column.FindTask(task.id));
        }

        [Fact]
        public void AddTaskInBoardInNotExistColumn_ExeptionWillBeReturned()
        {
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IBoard board = new Board("Доска");
            Assert.Throws<Exception>(() => board.AddTask(task, 2));
        }

        [Fact]
        public void FindTaskInBoard_TaskWillBeReturned()
        {
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn column = new Column("Колонка");
            IBoard board = new Board("Доска");
            board.AddColumn(column);
            board.AddTask(task);
            ITask reternedTask = board.FindTask(task.id);
            Assert.Equal(task, reternedTask);
        }

        [Fact]
        public void FindNotExistTaskInBoard_ExeptionWillBeReturned()
        {
            IBoard board = new Board("Доска");
            Assert.Throws<Exception>(() => board.FindTask(""));
        }

        [Fact]
        public void EditTaskInBoard_TaskWillBeChanged()
        {
            string newTaskName = "Задача";
            string newTaskDescription = "Описание";
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn column = new Column("Колонка");
            IBoard board = new Board("Доска");
            column.AddTask(task);
            board.AddColumn(column);
            board.EditTask(task.id, newTaskName, newTaskDescription, TaskRating.High);
            ITask reternedTask = board.FindTask(task.id);
            Assert.Equal(newTaskName, reternedTask.Name);
            Assert.Equal(newTaskDescription, reternedTask.Description);
            Assert.Equal(TaskRating.High, reternedTask.Rating);
        }

        [Fact]
        public void EditNotExistTaskInBoard_ExeptionWillBeReturned()
        {
            IBoard board = new Board("Доска");
            Assert.Throws<Exception>(() => board.EditTask("", "", "", TaskRating.Low));
        }

        [Fact]
        public void DeleteTaskInBoard_TaskWillBeDeleted()
        {
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn column = new Column("Колонка");
            IBoard board = new Board("Доска");
            column.AddTask(task);
            board.AddColumn(column);
            board.DeleteTask(task.id);
            Assert.Throws<Exception>(() => board.FindTask(task.id));
        }

        [Fact]
        public void DeleteNotExistTaskInBoard_ExeptionWillBeReturned()
        {
            IBoard board = new Board("Доска");
            Assert.Throws<Exception>(() => board.DeleteTask(""));
        }

        [Fact]
        public void TaskTransferInBoard_ColumnWillBeDeleted()
        {
            ITask task = new Task("Задача", "Описание", TaskRating.Low);
            IColumn first_column = new Column("Название первой колонки");
            IColumn second_column = new Column("Название колонки2");
            IBoard board = new Board("Название доски");
            board.AddColumn(first_column);
            board.AddColumn(second_column);
            board.AddTask(task);
            board.TransferTask(second_column.id, task.id);
            Assert.Equal(task, board.FindColumn(second_column.id).FindTask(task.id));
        }
    }
}