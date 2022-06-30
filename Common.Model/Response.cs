﻿using System.Collections.Generic;

namespace Common.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; } = 200;

        public T Data { get; set; }
    }
}
