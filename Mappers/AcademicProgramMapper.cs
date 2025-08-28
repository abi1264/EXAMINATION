using EXAMINATION.Models;
using EXAMINATION.Models.DTO;
namespace EXAMINATION.Mappers
{
    static public class AcademicProgramMapper
    {
        static public void ApplyPatch(AcademicProgramDto updateAcademic, AcademicProgram academic)
        {
            if (updateAcademic.Name != null)
            {
                academic.Name = updateAcademic.Name;
                
            }
            if (updateAcademic.Fee!= null)
            {
                academic.Fee = updateAcademic.Fee;
            }

        }
    }
}
