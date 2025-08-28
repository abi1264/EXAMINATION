using EXAMINATION.Models.DTO;
using EXAMINATION.Models;
namespace EXAMINATION.Mappers
{
    static public class ResultMapper
    {
        static public void ApplyPatch(ResultDto updateResultData,Result result)
        {
            if (updateResultData.StudentProfileId != null)
            {
                result.StudentProfileId = updateResultData.StudentProfileId.Value;
            }
            if (updateResultData.CourseId != null)
            {

                result.CourseId = updateResultData.CourseId.Value;
            }
            if (updateResultData.MarksObtained != null)
            {

                result.MarksObtained = updateResultData.MarksObtained.Value;
            }
            if (updateResultData.Grade != null)
            {
                result.Grade = updateResultData.Grade;
            }
            if (updateResultData.Status != null)
            {
                result.Status = updateResultData.Status.Value;
            }
            if (updateResultData.PublishedAt != null)
            {
                result.PublishedAt = updateResultData.PublishedAt.Value;
            }
        }
    }
}
