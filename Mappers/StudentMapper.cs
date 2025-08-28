using EXAMINATION.Models;
using EXAMINATION.Models.DTO;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.Enum;


namespace EXAMINATION.Mappers
{
   static public class StudentMapper
    {
        public static void ApplyPatch(StudentDto updateStudentDto, StudentProfile student)
        {
            if (updateStudentDto.Signature != null)
            {
                student.Signature = updateStudentDto.Signature;
            }

            if (updateStudentDto.FatherName != null)
            {
                student.FatherName = updateStudentDto.FatherName;
            }
            if (updateStudentDto.MotherName != null)
            {

                student.MotherName = updateStudentDto.MotherName;//for reference type just use .Property_name
            }

            
            if (updateStudentDto.Gender != null)
            {
                student.Gender = updateStudentDto.Gender.Value;

            }
            if (updateStudentDto.MaritalStatus != null)
            {
                student.MaritalStatus = updateStudentDto.MaritalStatus.Value;
            }

            if (updateStudentDto.DateOfBirth != null)
            {
                student.DateOfBirth = updateStudentDto.DateOfBirth.Value;// for value types use Property_name.Value 
            }
            if (updateStudentDto.CollegeName != null)
            {
                student.CollegeName = updateStudentDto.CollegeName;
            }
            if (updateStudentDto.CollegeAddress != null)
            {
                student.CollegeAddress = updateStudentDto.CollegeAddress;
            }
            if (updateStudentDto.ProgramId != null)
            {
                student.ProgramId = updateStudentDto.ProgramId.Value;
            }
            if (updateStudentDto.SemesterId != null)
            {
                student.SemesterId = updateStudentDto.SemesterId.Value;
            }
            if (updateStudentDto.ElectiveSubjects != null)
            {
                student.ElectiveSubjects = updateStudentDto.ElectiveSubjects;
            }
            if (updateStudentDto.Applications != null)
            {
                student.Applications = updateStudentDto.Applications;
            }
            if (updateStudentDto.Payments!=null){
                student.Payments = updateStudentDto.Payments;
            }
            //if (updateStudentDto.Results != null)
            //{
            //    student.Results = updateStudentDto.Results;
            //}
            

        }

    }
}
