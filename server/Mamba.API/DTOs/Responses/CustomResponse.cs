using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Responses
{
    public class BadRequestCustomResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    public class OkCustomResponse<TObject> where TObject : class
    {
        public bool Success { get; set; }
        public TObject Data { get; set; }
    }
}
