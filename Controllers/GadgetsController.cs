
using webappmssql.Data;
using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace webappmssql.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GadgetsController : ControllerBase
	{
		private readonly MyWorldDbContext _myWorldDbContext;

		public GadgetsController(MyWorldDbContext myWorldDbContext)
		{
			_myWorldDbContext = myWorldDbContext;
		}

		// การสร้าง Method Get all Gadgets()
		// https://localhost:5001/Gadgets/all
		[HttpGet]
		[Route("all")]
		public IActionResult GetAllGadgets()
		{
			var allGadgets = _myWorldDbContext.Gadgets.ToList();
			return Ok(allGadgets);
		}

		// การสร้าง Method Get all Gadgets()
		// https://localhost:5001/Gadgets/add
		[HttpPost]
		[Route("add")]
		public IActionResult CreateGagget(Gadgets gadgets)
		{
			_myWorldDbContext.Gadgets.Add(gadgets);
			_myWorldDbContext.SaveChanges();
			return Ok(gadgets.Id);
		}

		// สร้าง Method Update Gadgets()
		// https://localhost:5001/Gadgets/update
		[HttpPut]
		[Route("update")]
		public IActionResult UpdateGadget(Gadgets gadgets)
		{
			_myWorldDbContext.Update(gadgets);
			_myWorldDbContext.SaveChanges();
			return NoContent();
		}

		// สร้าง Method Delete Gadgets()
		// https://localhost:5001/Gadgets/delete
		[HttpDelete]
		[Route("delete/{id}")]
		public IActionResult DeleteGadget(int id)
		{
			var gadgetToDelete = _myWorldDbContext.Gadgets.Where( _ => _.Id == id).FirstOrDefault();
			if (gadgetToDelete == null)
			{
				return NotFound();
			}

			_myWorldDbContext.Gadgets.Remove(gadgetToDelete);
			_myWorldDbContext.SaveChanges();
			return NoContent();
		}
	}
}
