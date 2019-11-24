using System;
using System.Collections.Generic;
using System.Text;
using Web.Model.comman;

namespace Web.Model.Student
{
   public class StudentRegistration:Base
    {
        public string registrationNo { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string mobileNumber { get; set; }
        public string gender { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string parentName { get; set; }
        public string religion { get; set; }
        public string cast { get; set; }
        public bool isMinority { get; set; }
        public string minorityDetails { get; set; }
        public string stream { get; set; }
        public List<string> subject { get; set; }
        public string fatherOccupation { get; set; }
        public string motherOccupation { get; set; }
        public string email { get; set; }
        public string permanentAddress { get; set; }
        public string currentAddress { get; set; }
        public string lastCollegeName { get; set; }
        public string studentType { get; set; }
        public string courseId { get; set; }
        public List<Qualification> qualification { get; set; }
    }
    public class Qualification
    {
        public string serial_number { get; set; }
        public string examination { get; set; }
        public string yearOfPassing { get; set; }
        public string examinationType { get; set; }
        public string percentage { get; set; }
        public string selectedSubject { get; set; }
        public string instituteName { get; set; }
        public string board { get; set; }

    }

}
