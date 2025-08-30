using EXAMINATION.Models;
using EXAMINATION.Models.DTO;

namespace EXAMINATION.Mappers
{
    static public class ElectiveSubjectMapper
    {
        static public void ApplyPatch(ElectiveSubjectDto updateElectiveData, ElectiveSubject elective)
        {
            if (updateElectiveData.StudentProfileId != null)
            {
                elective.StudentProfileId = updateElectiveData.StudentProfileId.Value;
            }
            if (updateElectiveData.CourseId != null)
            {
                elective.CourseId = updateElectiveData.CourseId.Value;
            }
            elective.ChosenAt = updateElectiveData.ChosenAt;
        }
    }
}   
