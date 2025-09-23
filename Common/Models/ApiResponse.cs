using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Success", int statusCode = 200)
            => new()
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = statusCode
            };

        public static ApiResponse<T> Fail(string message, List<string>? errors = null, int statusCode = 400)
            => new()
            {
                Success = false,
                Message = message,
                Errors = errors,
                StatusCode = statusCode
            };
    }
}
