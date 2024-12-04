using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		Connection conn = new Connection();


		
		public IActionResult Index()
		{
			var datafetch = conn.users.ToList();
			return Ok(datafetch);
		}

		[HttpPost]
		public IActionResult Index([FromBody] User xyz)
		{
			conn.users.Add(xyz);
			conn.SaveChanges();
			return Ok(xyz);
		}
		[HttpPost]
		public IActionResult Login([FromBody] User abc)
		{
			var data = conn.users.Where(x => x.email== abc.email && x.password == abc.password);
            if (data.Any())
            {
				return Ok(new { success = true });
            }
            return Ok(new {success = false});
		}
		[HttpPut]
		public IActionResult Update([FromBody] User def)
		{
		var data = conn.users.Where(x => x.id == def.id).FirstOrDefault();
		data.names = def.names;
		data.email = def.email;
		data.password = def.password;


			conn.SaveChanges();

			return Ok(def);

		}
		[HttpDelete]
		public IActionResult Delete([FromBody] User def)
		{
			var data = conn.users.Find(def.id);
			conn.users.Remove(data);

			conn.SaveChanges();

			return Ok(data);

		}


	}
}
