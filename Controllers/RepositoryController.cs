using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubReposSearch.API.Helpers;
using GithubReposSearch.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GithubReposSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {

        [HttpPost("bookmark")]
        public IActionResult Bookmark([FromBody] Repository repo)
        {

            HttpContext.Session.SetComplexData("repo" + repo.Id, repo);
            return Ok(HttpContext.Session.Id);
        }

        [HttpGet("bookmarks")]
        public IActionResult GetBookmarks()
        {
             List<Repository> repositories = new List<Repository>();

           
             var keys = HttpContext.Session.Keys;
             foreach (var key in HttpContext.Session.Keys)
             {
                 repositories.Add(HttpContext.Session.GetComplexData<Repository>(key.ToString()));
             }
            
            return Ok(repositories);

        }
        
    }
}
