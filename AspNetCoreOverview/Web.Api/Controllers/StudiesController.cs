using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class StudiesController : ControllerBase
    {
        public ActionResult<Study[]> List()
        {
            return new[]
            {
                new Study {Id = 1, Title = "My Study"},
                new Study {Id = 2, Title = "Another Study"}
            };
        }

        [Route("{id}")]
        public ActionResult<Study> Get(int id)
        {
            return new Study {Id = id, Title = "string"};
        }

        [Route("{id}/slides")]
        public ActionResult<Slide[]> GetSlides(int id)
        {
            return new[] {new Slide()};
        }

        [HttpPost]
        public ActionResult Create(StartStudy command)
        {
            // call application layer
            return Created("/studies/123", new { Id = 123});
        }
    }

    public class StartStudy
    {
        public string Title { get; set; }
    }

    public class Slide  
    {
    }

    public class Study
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}