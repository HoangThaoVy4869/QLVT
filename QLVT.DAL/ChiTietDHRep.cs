using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
    public class ChiTietDHRep : GenericRep<QLVTContext, Ctdondh>
    {
        public ChiTietDHRep() { }
        public override Ctdondh Read(int id)
        {
            var res = All.FirstOrDefault(n => n.Sodh == id);
            return res;
        }
        public SingleRsp CreateCTDonDH(Ctdondh ctdondh)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Ctdondhs.Add(ctdondh);
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
        public SingleRsp UpdateChiTietDH(Ctdondh ctdondh)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Ctdondhs.Update(ctdondh);
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

        public int XoaCtDonDH(int id)
        {
            var m = base.All.First(i => i.Sodh == id);
            Context.Ctdondhs.Remove(m);
            Context.SaveChanges();
            return m.Sodh;
        }
    }
}