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
	public class PhieuXuatController : ControllerBase
	{
		private PhieuXuatSvc phieuXuatSvc;
		public PhieuXuatController()
		{
			phieuXuatSvc = new PhieuXuatSvc();
		}
		[HttpPost("px-get-by-id")]
		public IActionResult GetPhieuXuatByID ([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = phieuXuatSvc.Read(simpleReq.Id);
			return Ok(res);
		}
		[HttpPost("update-phieuxuat")]
		public IActionResult UpdatePhieuXuat([FromBody] PhieuXuatReq phieuXuatReq)
		{
			var res = new SingleRsp();
			res = phieuXuatSvc.UpdatePhieuXuat(phieuXuatReq);
			return Ok(res);
		}
	}
}
