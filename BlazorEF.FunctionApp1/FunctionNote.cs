using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using BlazorEF.FunctionApp1.Entities;

namespace BlazorEF.FunctionApp1
{
    public class FunctionNote
    {
        private readonly EfContext _efContext;
        private readonly ILogger<FunctionNote> _logger;

        public FunctionNote(ILogger<FunctionNote> log, EfContext efContext)
        {
            _logger = log;
            _efContext = efContext;
        }

        [FunctionName("FunctionNote")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "title", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Title** parameter")]
        [OpenApiParameter(name: "message", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Message** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string title = req.Query["title"];

            string message = req.Query["message"];

            var note = new Note
            {
                NoteId = Guid.NewGuid().ToString(),
                Title = title,
                Message = message,
                CreateDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            _efContext.Notes.Add(note);

            await _efContext.SaveChangesAsync();

            //using (var db = new EfContext())
            //{
            //    db.Database.EnsureCreated();
            //    db.Notes.Add(note);
            //    db.SaveChanges();
            //}

            return new OkObjectResult("Done!");
        }
    }
}

