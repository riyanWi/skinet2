﻿using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using skinet2.Errors;

namespace skinet2.Controllers
{
	public class BuggyController : BaseApiController
	{
		private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
		public ActionResult GetNotFoundRequest()
		{
			var thing = _context.Products.Find(42);

			if (thing == null)
			{
				return NotFound(new ApiResponse(404));
			}

			return Ok();
		}

		[HttpGet("servererror")]
		public ActionResult GetServerError()
		{
			var thing = _context.Products.Find(42);

			var thingToReturn = thing.ToString();

			return Ok();
		}

		[HttpGet("badrequest")]
		public ActionResult GetBadRequest()
		{
			return BadRequest(new ApiResponse(401));
		}

		[HttpGet("badrequest/{id}")]
		public ActionResult GetBadRequest(int id)
		{
			return Ok();
		}
	}
}
