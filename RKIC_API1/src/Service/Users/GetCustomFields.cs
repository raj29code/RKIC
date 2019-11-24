

#pragma warning disable 1591
using FMPCustomFields = Service.Model.User;
using System.Collections.Generic;
#pragma warning disable 1591

namespace Service.Users
{
    public class CustomFieldsFilter : EntityFilterBase<FMPCustomFields>
    {
        public static CustomFieldsFilter UserName(string userName)
        {
            var obj = new CustomFieldsFilter();

            var filter1 = obj.FilterBuilder.Where(
                f => f.UserName == userName
            );

            obj.Filters.Add(filter1);

            return obj;
        }
        public CustomFieldsFilter AndByPassword(string password)
        {
            var filter1 = FilterBuilder.Where(
                f => f.Password == password
            );

            Filters.Add(filter1);

            return this;
        }

    }
 }