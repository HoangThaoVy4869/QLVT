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
	public class TonKhoController : ControllerBase
	{
		private TonKhoSvc tonKhoSvc;
		public TonKhoController()
		{
			tonKhoSvc = new TonKhoSvc();
		}
		[HttpPost("tk-get-by-id")]
		public IActionResult GetTonKhoByID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = tonKhoSvc.Read(simpleReq.Id);
			return Ok(res);
		}
		[HttpPost("update-tonkho")]
		public IActionResult UpdateTonKho ([FromBody] TonKhoReq tonKhoReq)
		{
			var res = new SingleRsp();
			res = tonKhoSvc.UpdateTonKho(tonKhoReq);
			return Ok(res);
		}
	}
}
