using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
//using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

using MovieApi;

namespace MovieApi.Controllers
{
    //[EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return Movie.Movies;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            return Movie.Find(id);
        }

         [HttpPost]
        public void Post([FromBody] Movie value)
        {
            Movie.New(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie value)
        {
            Movie mov = Movie.Find(id);
            if(mov != null)
            {
                mov.title = value.title;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Movie.Delete(id);
        }

    }

}
