using EXAMINATION.Models;
using EXAMINATION.Models.DTO;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EXAMINATION.Mappers
{
    static public class CourseMapper
    {
        static public void ApplyPatch(CourseDto updateCourseData, Course course)
        {
            if (updateCourseData.Name != null)
            {
                course.Name = updateCourseData.Name;
            }
            if (updateCourseData.Code != null)
            {
                course.Code = updateCourseData.Code;
            }
            if (updateCourseData.Type != null)
            {
                course.Type = updateCourseData.Type.Value;
            }
            if (updateCourseData.Credit != null)
            {
                course.Credit = updateCourseData.Credit.Value;
            }
            if (updateCourseData.SemesterId != null)
            {
                course.SemesterId = updateCourseData.SemesterId.Value;
            }

        }
    }
}
