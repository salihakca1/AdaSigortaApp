namespace AdaSigortaMaui.ViewModels
{
    internal class AsyncCommand<T> : IAsyncCommand<int>
    {
        public AsyncCommand(Func<int, Task> deleteDask)
        {
            DeleteDask = deleteDask;
        }

        public Func<int, Task> DeleteDask { get; }
    }
}
