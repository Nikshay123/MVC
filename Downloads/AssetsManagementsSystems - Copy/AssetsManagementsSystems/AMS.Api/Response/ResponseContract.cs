using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Api.Response
{
    //public class CustomResponse<T>where T : class
    //{
    //    public int StatusCode { get; set; }
    //    public string StatusMessage { get; set; }
    //    public T Data { get; set; }
    //}


    //public class ErrorDetails
    //{
    //    public int StatusCode { get; set; }
    //    public string ErrorMessage { get; set; }
    //}


    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
    public class CustomResponse<T> : BaseResponse where T : class
    {
        public T Data { get; set; }
    }
     //We created a BaseResponse class containing the status code and status message properties.
    // CustomResponse<T> now inherits from BaseResponse   (as told by himanshu bhaiya)
    // The controller methods use CustomResponse<T> to encapsulate responses, ensuring a consistent structure for status information across the API.
    


    //Approach no. 3 this is not optimal
    //public interface IBaseResponse
    //{
    //    int StatusCode { get; set; }
    //    string StatusMessage { get; set; }
    //}
    //public class CustomResponse<T> : IBaseResponse where T : class
    //{
    //    public int StatusCode { get; set; }
    //    public string StatusMessage { get; set; }
    //    public T Data { get; set; }
    //}





}
