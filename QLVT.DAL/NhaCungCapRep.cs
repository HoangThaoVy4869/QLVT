using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
	public class NhaCungCapRep : GenericRep<QLVTContext, Nhacungcap>
    {
        public NhaCungCapRep() { }
        public override Nhacungcap Read(int id)
        {
            var res = All.FirstOrDefault(n => n.Manhacc == id);
            return res;
        }

        public SingleRsp UpdateNhaCC (Nhacungcap nhacungcap)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Nhacungcaps.Update(nhacungcap);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
