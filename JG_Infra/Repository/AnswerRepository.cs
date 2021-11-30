using JG_Domain.Entities;
using JG_Infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace JG_Infra.Repository
{
    //internal class AnswerRepository : GenericRepository<Answer>, IAnswer
    //{
    //    private readonly DbContextOptionsBuilder<ContextBase> _OptionsBuider;
    //    public AnswerRepository(IConfiguration configuration)
    //    {
    //        _OptionsBuider = new DbContextOptionsBuilder<ContextBase>();
    //        Configuration = configuration;
    //    }
    //    public PagingList<Charge> PagedList(ChargeFilter filter)
    //    {
    //        if (filter.Count == 0)
    //            filter.Count = 10;

    //        if (filter.Page == 0)
    //            filter.Page = 1;

    //        if (string.IsNullOrEmpty(filter.SortExpression))
    //            filter.SortExpression = "ChargeNo";

    //        using (var db = new ContextBase(_OptionsBuider.Options, Configuration))
    //        {
    //            var query = (db.Charges.Where(a =>
    //                           //compare query filter with name, obj code or vendor number
    //                           ((!string.IsNullOrEmpty(a.ClassFormatted) && (a.ClassFormatted.Trim().ToUpper() == filter.Charge.Class.Trim().ToUpper() || a.AttemptedChargeTypeFormatted.Trim().ToUpper() == filter.Charge.Class.Trim().ToUpper())) || string.IsNullOrEmpty(filter.Charge.Class))
    //                           && ((!string.IsNullOrEmpty(a.ChargeNo) && a.ChargeNo.IndexOf(filter.Charge.ChargeNo, StringComparison.CurrentCultureIgnoreCase) >= 0) || string.IsNullOrEmpty(filter.Charge.ChargeNo))
    //                           && ((!string.IsNullOrEmpty(a.FullDescription) && a.FullDescription.IndexOf(filter.Charge.FullDescription, StringComparison.CurrentCultureIgnoreCase) >= 0) || string.IsNullOrEmpty(filter.Charge.FullDescription))
    //                           && ((!string.IsNullOrEmpty(a.ShortDescription) && a.ShortDescription.IndexOf(filter.Charge.ShortDescription, StringComparison.CurrentCultureIgnoreCase) >= 0) || string.IsNullOrEmpty(filter.Charge.ShortDescription))
    //                           && ((!string.IsNullOrEmpty(a.UCRCode) && a.UCRCode.IndexOf(filter.Charge.UCRCode, StringComparison.CurrentCultureIgnoreCase) >= 0) || string.IsNullOrEmpty(filter.Charge.UCRCode))
    //                           && ((!string.IsNullOrEmpty(a.VFIndicator) && a.VFIndicator.IndexOf(filter.Charge.VFIndicator, StringComparison.CurrentCultureIgnoreCase) >= 0) || string.IsNullOrEmpty(filter.Charge.VFIndicator))
    //                        ).Select(c => FillCharge(c))
    //                );

    //            var returnedList = PagingList.CreateAsync(query, filter.Count, filter.Page, filter.SortExpression, "ChargeNo").Result;
    //            return returnedList;
    //        }
    //    }
    //    private static Charge FillCharge(Charge c)
    //    {
    //        return new Charge()
    //        {
    //            Id = c.Id,
    //            ChargeNo = c.ChargeNo,
    //            Class = c.Class,
    //            EffectiveDate = c.EffectiveDate,
    //            FullDescription = c.FullDescription,
    //            RepealDate = c.RepealDate,
    //            ShortDescription = c.ShortDescription,
    //            UCRCode = c.UCRCode,
    //            VFIndicator = c.VFIndicator,
    //            NYSLawCategory = c.NYSLawCategory,
    //            ATD = c.ATD,
    //            AttemptedClass = c.AttemptedClass,
    //            AttemptedNYSLawCategory = c.AttemptedNYSLawCategory,
    //            AttemptedVFIndicator = c.AttemptedVFIndicator,
    //            ChargeType = c.ChargeType
    //        };
    //    }
    //}
}
