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
	public class ChiTietPNController : ControllerBase
	{
		private ChiTietPNSvc chiTietPNSvc;
		public ChiTietPNController()
		{
			chiTietPNSvc = new ChiTietPNSvc();
		}
		[HttpPost("ph-get-by-id")]
		public IActionResult GetPNByID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = chiTietPNSvc.Read(simpleReq.Id);
			return Ok(res);
		}
		[HttpPost("create-ctphieunhap")]
		public IActionResult CreateChiTietPN([FromBody] ChiTietPNReq chiTietPNReq)
		{
			var res = new SingleRsp();
			res = chiTietPNSvc.CreateChiTietPN(chiTietPNReq);
			return Ok(res);
		}
		[HttpPost("update-ctphieunhap")]
		public IActionResult UpdateCTPN([FromBody] ChiTietPNReq chiTietPNReq)
		{
			var res = new SingleRsp();
			res = chiTietPNSvc.UpdateChiTietPN(chiTietPNReq);
			return Ok(res);
		}
		[HttpDelete("xoa-ct-phieu-nhap")]
		public IActionResult XoaCtPhieuNhap([FromBody] SimpleReq req)
		{
			var res = chiTietPNSvc.XoaCtPhieuNhap(req.Id);
			return Ok(res);
		}
	}
}
