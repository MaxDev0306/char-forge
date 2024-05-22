using Microsoft.AspNetCore.Mvc;
using Schule_REST.Model;
using System.Reflection;

namespace Schule_REST.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        /// <summary>
        /// get all versions of used libs
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<VersionInfo>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult GetVersionInfo()
        {
            List<VersionInfo> myInfo = new List<VersionInfo>();
            myInfo.Add(new VersionInfo(
               typeof(VersionController).Assembly.GetName().Name.ToString(),
               typeof(VersionController).Assembly.GetName().Version.Major,
               typeof(VersionController).Assembly.GetName().Version.Minor,
               typeof(VersionController).Assembly.GetName().Version.Build,
               typeof(VersionController).Assembly.GetName().Version.Revision));

            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var assembly in referencedAssemblies)
                myInfo.Add(new VersionInfo(
                   assembly.Name,
                    assembly.Version.Major,
                     assembly.Version.Minor,
                      assembly.Version.Build,
                       assembly.Version.Revision
                   ));

            Response.Headers.CacheControl = "private";
            return Ok(myInfo);
        }
    }
}
