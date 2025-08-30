using EXAMINATION.Models;
using EXAMINATION.Models.DTO;
namespace EXAMINATION.Mappers
{
    static public class AcademicProgramMapper
    {
        static public void ApplyPatch(AcademicProgramDto updateAcademic, AcademicProgram academic)
        {
            if (string.IsNullOrEmpty(updateAcademic.Name))
            {
                academic.Name = updateAcademic.Name;
                
            }
            if (updateAcademic.Fee!= null)
            {
                academic.Fee = updateAcademic.Fee.Value;
            }

        }
    }
}
