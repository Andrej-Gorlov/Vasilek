namespace Vasilek.Web.Models
{
    public class ResponseDtoBase
    {
        public bool IsSuccess { get; set; } = true;// успешин responce или нет
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string>? ErrorMessages { get; set; }
    }
}
