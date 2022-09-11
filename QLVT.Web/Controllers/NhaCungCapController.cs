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
	public class NhaCungCapController : ControllerBase
	{
		private NhaCungCapSvc nhaCungCapSvc;
		public NhaCungCapController()
		{
			nhaCungCapSvc = new NhaCungCapSvc();
		}
		[HttpPost("ncc-get-by-id")]
		public IActionResult GetNhaCCByID ([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = nhaCungCapSvc.Read(simpleReq.Id);
			return Ok(res);
		}

		[HttpPost("create-nhacungcap")]
		public IActionResult CreateNhaCC([FromBody] NhaCungCapReq nhaCungCapReq)
		{
			var res = new SingleRsp();
			res = nhaCungCapSvc.CreateNhaCC(nhaCungCapReq);
			return Ok(res);
		}

		[HttpPost("update-nhacungcap")]
		public IActionResult UpdateNhaCC ([FromBody] NhaCungCapReq nhaCungCapReq)
		{
			var res = new SingleRsp();
			res = nhaCungCapSvc.UpdateNhaCC(nhaCungCapReq);
			return Ok(res);
		}

		[HttpDelete("xoa-nha-cung-cap")]
		public IActionResult XoaNhaCungCap([FromBody] SimpleReq req)
		{
			var res = nhaCungCapSvc.XoaNhaCungCap(req.Id);
			return Ok(res);
		}

		[HttpPost("Tim-nhaCC-by-maNhaCC")]
		public IActionResult SearchProduct([FromBody] SearchNhaCCReq NhaCC)
		{
			var res = new SingleRsp();
			res = nhaCungCapSvc.SearchNhaCCByMaNCC(NhaCC);
			return Ok(res);
		}
	}
}
