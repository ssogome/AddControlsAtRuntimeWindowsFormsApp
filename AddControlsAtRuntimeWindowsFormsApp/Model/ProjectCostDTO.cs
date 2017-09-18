using AddControlsAtRuntimeWindowsFormsApp.DATA;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddControlsAtRuntimeWindowsFormsApp.Model
{
    [NotMapped]
    public class ProjectCostDTO: Project,IDTO
    {
        public Project _project;
        public int PC_Id;
        public decimal? PC_WorkOrderBaseEstimateVariance;
        public decimal? PC_WorkOrderBaseEstimate;
        public decimal? PC_ProjectedCostVariance;
        public decimal? PC_ActualApprovedBudget;
        public decimal? PC_ActualToDateBudget;
        public decimal? PC_RemainingCostBudget;
        public decimal? PC_ProjectedCost;

        public ProjectCostDTO():base() 
            { }

        public ProjectCostDTO(Project project)
        {
            _project = project;
             GetDTO(_project);
        }

        public void GetDTO(Project project)
        {
            PC_Id = project.Id;
            PC_WorkOrderBaseEstimateVariance = CalculateWOBaseEstimateVariance();
            PC_WorkOrderBaseEstimate = project.WorkOrder_BaseEstimate;
            PC_ProjectedCost = project.ProjectedBudget;
            PC_ProjectedCostVariance = CalculateCostVariance(project);
            PC_ActualApprovedBudget = project.ApprovedBudget;
            PC_ActualToDateBudget = project.ActualToDate;
            PC_RemainingCostBudget = CalculateRemainingBudget(project);
        }

        private decimal? CalculateWOBaseEstimateVariance()
        {
            decimal? v =2.81m;
            return v;
        }

        private decimal? CalculateRemainingBudget(Project project)
        {
            decimal? v = project.ApprovedBudget - project.ActualToDate;
            return v;
        }

        private decimal? CalculateCostVariance(Project project)
        {
            decimal? v = 1.1m;
            return v;
        }

    }
}
