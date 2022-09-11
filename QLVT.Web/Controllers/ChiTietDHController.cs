using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLVT.BLL;
using QLVT.Common.Req;
using QLVT.Common.Rsp;

namespace QLVT.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChiTietDHController : ControllerBase
	{
		private ChiTietDHSvc chiTietDHSvc;
		public ChiTietDHController()
		{
			chiTietDHSvc = new ChiTietDHSvc();
		}

		[HttpPost("ctdh-get-by-id")]
		public IActionResult GetCTDHByID ([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = chiTietDHSvc.Read(simpleReq.Id);
			return Ok(res);
		}

		[HttpPost("create-ctdh")]
		public IActionResult CreateCTDH ([FromBody] ChiTietDHReq chiTietDHReq)
		{
			var res = new SingleRsp();
			res = chiTietDHSvc.CreateCTDonDH(chiTietDHReq);
			return Ok(res);
		}

		[HttpPost("update-ctdh")]
		public IActionResult UpdateCTDondh ([FromBody] ChiTietDHReq chiTietDHReq)
		{
			var res = new SingleRsp();
			res = chiTietDHSvc.UpdateChiTietDH(chiTietDHReq);
			return Ok(res);
		}

		[HttpDelete("xoa-ct-don-dh")]
		public IActionResult XoaCtDonDH([FromBody] SimpleReq req)
		{
			var res = chiTietDHSvc.XoaCtDonDH(req.Id);
			return Ok(res);
		}
	}
}
