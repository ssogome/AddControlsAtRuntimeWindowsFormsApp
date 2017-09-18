using AddControlsAtRuntimeWindowsFormsApp.DATA;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddControlsAtRuntimeWindowsFormsApp.Model
{
    [NotMapped]
    public class MetricsDTO: Project
    {
        Project _project;
        public int M_Id;
        public int? M_TotalWorkCompleted;
        public int? M_TotalTracksCompleted;
        public int? M_TotalTaskCompleted;

        public MetricsDTO() { }

        public MetricsDTO(Project project)
        {
            _project = project;
            GetDTO(_project);
        }

        public void GetDTO(Project project)
        {
            M_Id = project.Id;
            M_TotalWorkCompleted = project.TotalWorkCompleted;
            M_TotalTracksCompleted = project.TotalTracksCompleted;
            M_TotalTaskCompleted = project.TotalTaskCompleted;
           
        }
    }
}
