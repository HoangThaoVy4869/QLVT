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
	public class VatTuController : ControllerBase
	{
		private VatTuSvc vatTuSvc;
		public VatTuController()
		{
			vatTuSvc = new VatTuSvc();
		}
		[HttpPost("get-by-id")]
		public IActionResult GetVatTuByID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = vatTuSvc.Read(simpleReq.Id);
			return Ok(res);
		}
		[HttpPost("create-vattu")]
		public IActionResult CreateVatTu ([FromBody] VatTuReq vatTuReq)
		{
			var res = new SingleRsp();
			res = vatTuSvc.CreateVatTu(vatTuReq);
			return Ok(res);
		}
		[HttpPost("search-vattu")]
		public IActionResult SearchVatTu([FromBody] SearchVatTuReq searchVatTuReq)
		{
			var res = new SingleRsp();
			res = vatTuSvc.SearchVatTu(searchVatTuReq);
			return Ok(res);
		}
		[HttpPost("update-vattu")]
		public IActionResult UpdateProduct([FromBody] VatTuReq vatTuReq)
		{
			var res = new SingleRsp();
			res = vatTuSvc.UpdateVatTu(vatTuReq);
			return Ok(res);
		}

		[HttpDelete("xoa-vattu")]
		public IActionResult XoaVattu([FromBody] SimpleReq req)
		{
			var res = vatTuSvc.XoaVattu(req.Id);
			return Ok(res);
		}
	}
}
