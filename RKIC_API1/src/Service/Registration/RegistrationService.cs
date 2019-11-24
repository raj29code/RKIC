using Service.Registration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Model.Student;
using Service.Model.comman;
using RKICStudent = Web.Model.Student.Student;
namespace Service.Registration
{
   public class RegistrationService : IStudentRegistration
    {
        private readonly ICommandHandler<ICreateCommand<RKICStudent>> _createStudent;
        private readonly IQueryHandler<IQuery<RKICStudent>, bool> _studentExists;
        private readonly IQueryHandler<IQuery<RKICStudent>, IReadOnlyList<RKICStudent>> _student;
        private readonly IQueryHandler<IQuery<RKICStudent>, RKICStudent> _getStudent;

        public RegistrationService(ICommandHandler<ICreateCommand<RKICStudent>> createStudent,
               IQueryHandler<IQuery<RKICStudent>, bool> studentExists,
             IQueryHandler<IQuery<RKICStudent>, IReadOnlyList<RKICStudent>>student,
             IQueryHandler<IQuery<RKICStudent>, RKICStudent> getStudent)
        {
            _createStudent = createStudent;
            _studentExists = studentExists;
            _student = student;
            _getStudent = getStudent;
        }

       

        public async Task<ReturnInfo<RKICStudent>> StudentRegistration(StudentRegistration studentRegistrationData)
        {
            var result = new ReturnInfo<RKICStudent>();
            var Isexist = await _studentExists.Handle(
                RegistrationFilter.MobileNumber(studentRegistrationData.mobileNumber)
                   );
            if (Isexist)
            {
   
                result.ReturnData = null;
                result.ErrorMessage = "Student or mobile no already exist";
                return result;
            }
            else
            {
                var customFieldsData = RKICStudent.From(
         studentRegistrationData);
              var iscreated =   await _createStudent.Handle(
                   CreateCommand<RKICStudent>.From(customFieldsData));
                if(iscreated)
                {
                    var data = await _getStudent.Handle(
                            RegistrationFilter.MobileNumber(studentRegistrationData.mobileNumber)
                                  );

                    result.ReturnData = data;
                    result.SuccessMessage = "Student Registration Successfull";
                    return result;
                }
            }
            result.ErrorMessage = "something went wrong";
            return result;
        }
    }
}
