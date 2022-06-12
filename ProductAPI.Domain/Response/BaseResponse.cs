namespace ProductAPI.Domain.Response
{
    public class BaseResponse<T>: IBaseResponse<T>
    {
        public bool IsSuccess { get; set; } = false;
        public T? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
    }
    public interface IBaseResponse<T>
    {
        public T? Result { get; set; }
    }

}
