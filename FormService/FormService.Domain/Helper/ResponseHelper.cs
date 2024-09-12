using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormService.Domain.Helper
{
    public static class ResponseHelper
    {
        public static IActionResult CreateOkResponse<T>(T data)
        {
            return new OkObjectResult(data);
        }
    }
}
