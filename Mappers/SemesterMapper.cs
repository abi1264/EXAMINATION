using EXAMINATION.Models.DTO;
using EXAMINATION.Models;


namespace EXAMINATION.Mappers
{
    static public class SemesterMapper
    {
        static public void ApplyPatch(SemesterDto updateSemester,Semester semester)
        {
            if (updateSemester.Name != null)
            {
                semester.Name = updateSemester.Name;
            }
            if (updateSemester.Fee!=null)
            {
                semester.Fee = updateSemester.Fee.Value; 
            }
            if (updateSemester.ProgramId != null)
            {
                semester.ProgramId = updateSemester.ProgramId.Value;
            }
            if (updateSemester.Courses != null)
            {
                semester.Courses = updateSemester.Courses;
            }
            
        }
    }
}
