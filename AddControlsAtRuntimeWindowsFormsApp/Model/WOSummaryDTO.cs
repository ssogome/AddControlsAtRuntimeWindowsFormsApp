using AddControlsAtRuntimeWindowsFormsApp.DATA;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddControlsAtRuntimeWindowsFormsApp.Model
{
    [NotMapped]
    public class WOSummaryDTO:Project
    {
        public Project _project;
        public int WO_Id;
        public decimal? WO_percentCompleteWO;
        public decimal?WO_percentTaskComplete;
        public decimal? WO_percentTrackComplete;
        public int? WO_TotalWorkCompleted;
        public int? WO_TotalWorkOrder;
        public int? WO_TotalTask;
        public int? WO_TotalTaskCompleted;
        public int? WO_TotalTracks;
        public int? WO_TotalTracksCompleted;

        public WOSummaryDTO() { }

        public WOSummaryDTO(Project project)
        {
            _project = project;
            GetDTO(project);
        }

        public void GetDTO(Project project)
        {
            WO_Id = project.Id;
            WO_percentCompleteWO = CalculateCompleteWOPercentage(project);
            WO_percentTaskComplete = CalculateTaskCompletePercentage(project);
            WO_percentTrackComplete = CalculateTrackCompletePercentage(project);
            WO_TotalWorkCompleted = project.TotalWorkCompleted;
            WO_TotalWorkOrder = project.TotalWorkOrder;
            WO_TotalTask = project.TotalTask;
            WO_TotalTaskCompleted = project.TotalTaskCompleted;
            WO_TotalTracks = project.TotalTracks;
            WO_TotalTracksCompleted = project.TotalTracksCompleted;
        }

        private decimal? CalculateCompleteWOPercentage(Project project)
        {
            decimal? v ;

            v = (project.TotalWorkCompleted * 100) / project.TotalWorkOrder;
            return v;
        }
        private decimal? CalculateTaskCompletePercentage(Project project)
        {
            decimal? v;

            v = (project.TotalTaskCompleted * 100) / project.TotalTask;
            return v;
        }
        private decimal? CalculateTrackCompletePercentage(Project project)
        {
            decimal? v;

            v = (project.TotalTracksCompleted * 100) / project.TotalTracks;
            return v;
        }




    }
}
