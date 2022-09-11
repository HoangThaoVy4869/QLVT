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
	public class DonDHController : ControllerBase
	{
		private DonDHSvc donDHSvc;
		public DonDHController()
		{
			donDHSvc = new DonDHSvc();
		}
		[HttpPost("dh-get-by-id")]
		public IActionResult GetDHByID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = donDHSvc.Read(simpleReq.Id);
			return Ok(res);
		}

		[HttpPost("create-donhang")]
		public IActionResult CreateDondh([FromBody] DonDHReq donDHReq)
		{
			var res = new SingleRsp();
			res = donDHSvc.CreateDondh(donDHReq);
			return Ok(res);
		}

		[HttpPost("update-donhang")]
		public IActionResult UpdateDondh ([FromBody] DonDHReq donDHReq)
		{
			var res = new SingleRsp();
			res = donDHSvc.UpdateDondh(donDHReq);
			return Ok(res);
		}

		[HttpDelete("xoa-don-dh")]
		public IActionResult XoaDonDH([FromBody] SimpleReq req)
		{
			var res = donDHSvc.XoaDH(req.Id);
			return Ok(res);
		}

		[HttpPost("Tim-DonDH-by-SoDH")]
		public IActionResult SearchProduct([FromBody] int Sopx)
		{
			var res = new SingleRsp();
			res = donDHSvc.SearchDonDHBySoDH(Sopx);
			return Ok(res);
		}
	}
}
