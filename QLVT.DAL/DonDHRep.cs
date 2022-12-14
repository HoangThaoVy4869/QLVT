using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
	public class DonDHRep : GenericRep<QLVTContext, Dondh>
	{
        public DonDHRep() { }
        public override Dondh Read(int id)
        {
            var res = All.FirstOrDefault(n => n.Sodh == id);
            return res;
        }
        public SingleRsp CreateDondh(Dondh dondh)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Dondhs.Add(dondh);
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
        public SingleRsp UpdateDondh (Dondh dondh)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Dondhs.Update(dondh);
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

        public int XoaDonHang(int id)
        {
            var m = base.All.First(i => i.Sodh == id);
            Context.Dondhs.Remove(m);
            Context.SaveChanges();
            return m.Sodh;
        }

        public List<Dondh> searchDonDH(int idDonDH)
        {
            return All.Where(x => x.Sodh == idDonDH).ToList();
        }
    }
}

