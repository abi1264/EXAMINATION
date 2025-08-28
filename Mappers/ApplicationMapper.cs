using EXAMINATION.Models.DTO;
using EXAMINATION.Models;
namespace EXAMINATION.Mappers
{

    static public class ApplicationMapper
    {
        static public void ApplyPatch(ApplicationDto updateApplicationData, Application application)
        {


            if (updateApplicationData.SemesterId != null)
            {
                application.SemesterId = updateApplicationData.SemesterId.Value;
            }
            if (updateApplicationData.ExamType != null)
            {

                application.ExamType = updateApplicationData.ExamType.Value;
            }
            if (updateApplicationData.Status != null)
            {
                application.Status = updateApplicationData.Status.Value;
            }


        }
    }
}

