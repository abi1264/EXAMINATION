using EXAMINATION.Models;
using EXAMINATION.Models.DTO;

namespace EXAMINATION.Mappers
{
    static public class ElectiveSubjectMapper
    {
        static public void ApplyPatch(ElectiveSubjectDto updateElectiveData,ElectiveSubject elective)
        {
            if (updateElectiveData.StudentProfileId != null)
            {
                elective.StudentProfileId = updateElectiveData.StudentProfileId;
            }
            if (updateElectiveData.CourseId != null)
            {

                elective.CourseId = updateElectiveData.CourseId;
            }
            if (updateElectiveData.ChosenAt != null)
            {
                elective.ChosenAt = updateElectiveData.ChosenAt;
            }

        }
    }
}
