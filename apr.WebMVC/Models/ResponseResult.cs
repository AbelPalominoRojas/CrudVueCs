using System.Collections.Generic;

namespace apr.WebMVC.Models
{
    public class ResponseResult<T>
    {
        public bool State { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> Datas { get; set; }
    }
}