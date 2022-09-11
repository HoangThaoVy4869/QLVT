using System;
using System.Collections.Generic;
using System.Text;
using QLVT.Common.DAL;
using QLVT.DAL.Models;
using System.Linq;
using QLVT.Common.Rsp;

namespace QLVT.DAL
{
	public class VatTuRep:GenericRep<QLVTContext,Vattu>
	{
		public VatTuRep(){}

		public override Vattu Read(int id)
		{
			var res = All.FirstOrDefault(v => v.Mavtu == id);
			return res;
		}

        #region -- Methods --
        public SingleRsp CreateVatTu(Vattu vattu)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Vattus.Add(vattu);
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

        public SingleRsp UpdateVatTu(Vattu vattu)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Vattus.Update(vattu);
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

        public int XoaVattu(int id)
        {
            var m = base.All.First(i => i.Mavtu == id);
            Context.Vattus.Remove(m);
            Context.SaveChanges();
            return m.Mavtu;
        }

        public List<Vattu> SearchVatTu(string keyWord)
		{             
            return All.Where(x => x.Tenvtu.Contains(keyWord)).ToList();
		}

        #endregion
    }
}
