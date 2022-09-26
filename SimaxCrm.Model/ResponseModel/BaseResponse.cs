namespace SimaxCrm.Model.ResponseModel
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Response { get; set; }
        public T Data { get; set; }
        public string ModelKey { get; set; }

    }

    public class BaseResponse<T, T1> : BaseResponse<T>
    {
        public T1 OtherData { get; set; }
    }
}