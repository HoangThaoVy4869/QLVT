﻿using System;
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
	public class PhieuNhapController : ControllerBase
	{
		private PhieuNhapSvc phieuNhapSvc;
		public PhieuNhapController()
		{
			phieuNhapSvc = new PhieuNhapSvc();
		}
		[HttpPost("pn-get-by-id")]
		public IActionResult GetPhieuNhapByID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = phieuNhapSvc.Read(simpleReq.Id);
			return Ok(res);
		}
		[HttpPost("create-phieunhap")]
		public IActionResult CreatePhieuNhap([FromBody] PhieuNhapReq phieuNhapReq)
		{
			var res = new SingleRsp();
			res = phieuNhapSvc.CreatePhieuNhap(phieuNhapReq);
			return Ok(res);
		}
		[HttpPost("update-phieunhap")]
		public IActionResult UpdatePhieuNhap([FromBody] PhieuNhapReq phieuNhapReq)
		{
			var res = new SingleRsp();
			res = phieuNhapSvc.UpdatePhieuNhap(phieuNhapReq);
			return Ok(res);
		}

		[HttpDelete("xoa-phieu-nhap")]
		public IActionResult XoaPhieuNhap([FromBody] SimpleReq req)
		{
			var res = phieuNhapSvc.XoaPhieuNhap(req.Id);
			return Ok(res);
		}

		[HttpPost("Tim-PhieuNhap-by-Sopn")]
		public IActionResult SearchProduct([FromBody] int Sopn)
		{
			var res = new SingleRsp();
			res = phieuNhapSvc.SearchPhieuNhapBySoPX(Sopn);
			return Ok(res);
		}
	}
}
