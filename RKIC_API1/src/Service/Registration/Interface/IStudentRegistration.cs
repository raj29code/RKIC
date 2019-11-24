using Service.Model.comman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Model.Student;
using RKICStudent = Web.Model.Student.Student;

namespace Service.Registration.Interface
{
   public interface IStudentRegistration
    {
        Task<ReturnInfo<RKICStudent>> StudentRegistration(StudentRegistration studentRegistrationData);
    }
}
