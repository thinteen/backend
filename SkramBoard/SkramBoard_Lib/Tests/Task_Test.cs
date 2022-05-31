using ScrumBoard.Task;
using Task = ScrumBoard.Task.Task;

namespace ScrumBoardTest

{
    public class TaskTest
    {
        [Fact]
        public void CreateTask()
        {
            string taskName = "������";
            string taskDescription = "��������";
            ITask task = new Task(taskName, taskDescription, TaskRating.Low);
            Assert.False(string.IsNullOrEmpty(task.id));
            Assert.Equal(taskName, task.Name);
            Assert.Equal(taskDescription, task.Description);
            Assert.Equal(TaskRating.Low, task.Rating);
        }

        [Fact]
        public void ChangeTaskName_NameWillBeChanged()
        {
            string newTaskName = "����� ��������";
            ITask task = new Task("������", "��������", TaskRating.Low);
            task.Name = newTaskName;
            Assert.Equal(newTaskName, task.Name);
        }

        [Fact]
        public void ChangeTaskRating_RatingWillBeChanged()
        {
            ITask task = new Task("������", "��������", TaskRating.Low);
            task.Rating = TaskRating.High;
            Assert.Equal(TaskRating.High, task.Rating);
        }

        [Fact]
        public void ChangeTaskDescription_DescriptionWillBeChanged()
        {
            string newTaskDescription = "����� ��������";
            ITask task = new Task("������", "��������", TaskRating.Low);
            task.Description = newTaskDescription;
            Assert.Equal(newTaskDescription, task.Description);
        }
    }
}