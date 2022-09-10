using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
	public class TonKhoRep: GenericRep<QLVTContext, Tonkho>
    {

        public TonKhoRep() { }
        public override Tonkho Read(int id)
        {
            var res = All.FirstOrDefault(t => t.Maso == id);
            return res;
        }

        public SingleRsp UpdateTonKho (Tonkho tonkho)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Tonkhos.Update(tonkho);
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
