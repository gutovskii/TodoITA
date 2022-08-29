namespace TodoITA.WebApi.ViewModels
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
