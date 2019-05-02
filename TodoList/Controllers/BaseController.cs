using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace TodoList.Controllers
{
    public class BaseController : Controller
    {
        CancellationToken ct => HttpContext?.RequestAborted ?? CancellationToken.None; 
    }
}
