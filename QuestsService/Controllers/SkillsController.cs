using Microsoft.AspNetCore.Mvc;

namespace QuestsService.Controllers
{
	[Route("api/q/[controller]")]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		public SkillsController()
		{
		}

		[HttpPost]
		public ActionResult TestInboundConnection()
		{
			Console.WriteLine("-- Inbound POST # Quest Service");
			return Ok("Inbound teste of from Skills Controller");
		}
	}
}
