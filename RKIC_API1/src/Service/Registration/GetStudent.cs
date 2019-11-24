

#pragma warning disable 1591
using RKICStudent = Web.Model.Student.Student;
using System.Collections.Generic;
#pragma warning disable 1591

namespace Service.Registration
{
    public class RegistrationFilter : EntityFilterBase<RKICStudent>
    {
        public static RegistrationFilter MobileNumber(string number)
        {
            var obj = new RegistrationFilter();

            var filter1 = obj.FilterBuilder.Where(
                f => f.mobileNumber == number
            );

            obj.Filters.Add(filter1);

            return obj;
        }
        public RegistrationFilter AndByRegistrationNo(string RegistrationNo)
        {
            var filter1 = FilterBuilder.Where(
                f => f.registrationNo == RegistrationNo
            );

            Filters.Add(filter1);

            return this;
        }

    }
}