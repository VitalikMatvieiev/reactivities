using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    public class ActivitiesController : BaseApiController
    {
        public ActivitiesController(ILogger<BaseApiController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivitiesAsync()
        {
            var request = new List.Query();
            return await Mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var request = new Details.Query() 
            {
                Id = id
            };
            return await Mediator.Send(request);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody]Activity activity) 
        {
            var request = new Create.Command() { Activity = activity };
            return Ok(await Mediator.Send(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateActivity(Guid id, [FromBody]Activity activity) 
        {
            activity.Id = id;
            var request = new Edit.Command() { Activity = activity };
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id) 
        {
            var request = new Delete.Command() {Id = id};
            return Ok(await Mediator.Send(request));
        }
    }
 }