using System;
using Exterminator.Repositories.Implementations;
using Exterminator.Services.Implementations;
using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exterminator.WebApi.Controllers
{
    
    [Route("api/logs")]
    public class LogController : Controller
    {
        private LogService _logService;
        
        public LogController()
        {
            var logRepository = new LogRepository();
            _logService = new LogService(logRepository);
        }
        // TODO: Implement route which gets all logs from the ILogService,
        // which should be injected through the constructor

        [HttpGet]
        [Route("")]
        public IActionResult GetAllLogs()
        {
            return Ok(_logService.GetAllLogs());
        }
    }
}