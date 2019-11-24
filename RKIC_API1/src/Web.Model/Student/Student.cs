using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Web.Model.comman;

namespace Web.Model.Student
{
   public class Student:Base
    {
        public ObjectId _id { get; set; }
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

        public static Student From(StudentRegistration data)
        {

            return new Student()
            {
                _id = ObjectId.GenerateNewId(),
                registrationNo = GetNewStudentRegistration(data.courseId),
                firstName = data.firstName,
                middleName = data.middleName,
                lastName = data.lastName,
                mobileNumber = data.mobileNumber,
                gender = data.gender,
                fatherName = data.fatherName,
                motherName = data.motherName,
                dateOfBirth = data.dateOfBirth,
                parentName = data.parentName,
                religion = data.religion,
                cast = data.cast,
                isMinority = data.isMinority,
                minorityDetails = data.minorityDetails,
                stream = data.stream,
                subject = data.subject,
                fatherOccupation = data.fatherOccupation,
                motherOccupation = data.motherOccupation,
                email = data.email,
                permanentAddress = data.permanentAddress,
                currentAddress = data.currentAddress,
                lastCollegeName = data.lastCollegeName,
                studentType = data.studentType,
                courseId = data.courseId,
                qualification = data.qualification,
                CreatedBy = data.CreatedBy,
                CreatedDateTime = DateTime.Now.ToString(),
                LastUpdatedDateTime = DateTime.Now.ToString(),
                LastUpdatedBy = data.LastUpdatedBy,
                IsActive = true,
            };

      
    }
        private static string GetNewStudentRegistration(string courseId)
        {
            return DateTime.Now.Year.ToString() + "222" + 13; //need to remove  
        }
    }
}
