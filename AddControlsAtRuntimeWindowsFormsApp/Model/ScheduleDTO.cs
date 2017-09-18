using AddControlsAtRuntimeWindowsFormsApp.DATA;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddControlsAtRuntimeWindowsFormsApp.Model
{
    [NotMapped]
    public class ScheduleDTO: Project, IDTO
    {
        public Project _project;
        public  int S_Id;
        public DateTime? S_ApprovedEndDate;
        public DateTime? S_ProjectedEndDate;
        public decimal? S_EndDateVariance;
        public DateTime? S_WorkOrder_BaseEstimateDate;
        public decimal? S_WorkOrder_BaseEstimateDateVariance;
        public DateTime? S_ActualWorkEndDate;
        public decimal? S_ActualWorkEndDateVariance;

        public ScheduleDTO() { }

        public ScheduleDTO(Project project)
        {
            _project = project;
            GetDTO(project);
        }

        public void GetDTO( Project project)
        {
            S_Id = project.Id;
            S_ApprovedEndDate = project.ApprovedEndDate;
            S_ProjectedEndDate = project.ProjectedEndDate;
            S_EndDateVariance = CalculateEndDateVariance();
            S_WorkOrder_BaseEstimateDate = project.WorkOrder_BaseEstimateDate;
            S_WorkOrder_BaseEstimateDateVariance = CalculateWOBaseEstimateVariance();
           S_ActualWorkEndDate = project.ActualWorkEndDate;
            S_ActualWorkEndDateVariance = CalculateActualWorkEndDateVariance();
        }

        private decimal? CalculateEndDateVariance()
        {
            decimal? v = 1m;
            return v;

        }
            private decimal? CalculateWOBaseEstimateVariance()
            {
                decimal? v = 2.1m;
                return v;
            }

            private decimal? CalculateActualWorkEndDateVariance()
        {
            decimal? v = 1.5m;
            return v;
        }
    }
}
