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
	public class ChiTietPXController : ControllerBase
	{
		private ChiTietPXSvc chiTietPXSvc;
		public ChiTietPXController()
		{
			chiTietPXSvc = new ChiTietPXSvc();
		}
		[HttpPost("ctpx-get-by-id")]
		public IActionResult GetCTPXByID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = chiTietPXSvc.Read(simpleReq.Id);
			return Ok(res);
		}
		[HttpPost("create-ctphieuxuat")]
		public IActionResult CreateChiTietPX([FromBody] ChiTietPXReq chiTietPXReq)
		{
			var res = new SingleRsp();
			res = chiTietPXSvc.CreateChiTietPX(chiTietPXReq);
			return Ok(res);
		}
		[HttpPost("update-ctphieuxuat")]
		public IActionResult UpdateChiTietPX([FromBody] ChiTietPXReq chiTietPXReq)
		{
			var res = new SingleRsp();
			res = chiTietPXSvc.UpdateChiTietPX(chiTietPXReq);
			return Ok(res);
		}
		[HttpDelete("xoa-ct-phieu-xuat")]
		public IActionResult XoaCTPhieuXuat([FromBody] SimpleReq req)
		{
			var res = chiTietPXSvc.XoaCTPhieuXuat(req.Id);
			return Ok(res);
		}
	}
}
