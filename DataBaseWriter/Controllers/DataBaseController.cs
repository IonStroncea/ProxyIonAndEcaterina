using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

namespace DataBaseWriter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataBaseController : ControllerBase
    {
        DBWriter writer;

        public DataBaseController(DBWriter writer)
        {
            this.writer = writer;
        }

        [HttpPost]
        public int WriteDB([FromBody] DBRequest request)
        {
            writer.AddRequest(request);

            return 1;
        }
    }
}
