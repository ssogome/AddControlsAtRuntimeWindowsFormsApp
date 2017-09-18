using System;
using System.Linq;
using AddControlsAtRuntimeWindowsFormsApp.DATA;
using AddControlsAtRuntimeWindowsFormsApp.Model;

namespace AddControlsAtRuntimeWindowsFormsApp.DataAccess
{
    public  class PopulateDataInForm
    {
       
       //public ProjectCostDTO PopulateProjectCost(int id)
       // {
       //     ProjectCostDTO _pCost;

       //     using (var ctx = new ProjectModel())
       //     {
       //         //Query the table
       //         var result =(from t in ctx.Projects
       //                      where t.Id == id 
       //                      select t).Single();              

       //         //Create the DTO
       //         _pCost = new ProjectCostDTO()
       //         {
       //             Id = result.Id,
       //             ProjectName = result.ProjectName,
       //             ApprovedBudget = result.ApprovedBudget,
       //             ActualToDate = result.ActualToDate,
       //             RemainingBudget = result.ApprovedBudget - result.ActualToDate,
       //             WorkOrder_BaseEstimate = result.WorkOrder_BaseEstimate,
       //             ActualToDateVariance = ( result.WorkOrder_BaseEstimate - result.ActualToDate),
       //             WorkOrder_BaseEstimateVariance = result.WorkOrder_BaseEstimateVariance,
       //             ProjectedBudget = result.ProjectedBudget,
       //             ProjectedCostVariance =Math.Abs((decimal)(result.ApprovedBudget- result.ProjectedBudget))
       //         };
       //     }

       //     return _pCost;
       // }

       // public ScheduleDTO PopulateSchedule(int id)
       // {
       //     ScheduleDTO _sch;

       //     using (var ctx = new ProjectModel())
       //     {
       //         //Query the table
       //         var result = (from t in ctx.Projects
       //                       where t.Id == id 
       //                       select t).Single();
       //         //Create the DTO
       //         _sch = new ScheduleDTO()
       //         {
       //             Id = result.Id,
       //             ProjectName = result.ProjectName,
       //             ApprovedEndDate = result.ApprovedEndDate,
       //             ProjectedEndDate = result.ProjectedEndDate,
       //             EndDateVariance =  result.EndDateVariance ,
       //             WorkOrder_BaseEstimateDate = result.WorkOrder_BaseEstimateDate,
       //             WorkOrder_BaseEstimateDateVariance = result.WorkOrder_BaseEstimateDateVariance,
       //             ActualWorkEndDate = result.ActualWorkEndDate,
       //             ActualWorkEndDateVariance = result.ActualWorkEndDateVariance
       //         };
       //     }

       //     return _sch;
       // }

       // public WOSummaryDTO PopulateWOSummary(int id)
       // {
       //     WOSummaryDTO _summary;

       //     using (var ctx = new ProjectModel())
       //     {
       //         //Query the table
       //         var result = (from t in ctx.Projects
       //                       where t.Id == id 
       //                       select t).Single();
       //         //Create the DTO
       //         _summary = new WOSummaryDTO()
       //         {
       //             Id = result.Id,
       //             ProjectName = result.ProjectName,
       //             TotalWorkCompleted = result.TotalWorkCompleted,
       //             TotalWorkOrder = result.TotalWorkOrder,
       //             percentCompleteWO = (result.TotalWorkCompleted*100/result.TotalWorkOrder),
       //             TotalTaskCompleted = result.TotalTaskCompleted,
       //             TotalTask = result.TotalTask,
       //             percentTaskComplete = (result.TotalTaskCompleted*100/result.TotalTask),
       //             TotalTracks = result.TotalTracks,
       //             TotalTracksCompleted = result.TotalTracksCompleted,
       //             percentTrackComplete = (result.TotalTracksCompleted*100/result.TotalTracks)
       //         };
       //     }

       //     return _summary;
       // }

       // public MetricsDTO PopulateMetrics(int id)
       // {
       //     MetricsDTO _metrics;

       //     using (var ctx = new ProjectModel())
       //     {
       //         //Query the table
       //         var result = (from t in ctx.Projects
       //                       where t.Id == id 
       //                       select t).Single();
       //         //Create the DTO
       //         _metrics = new MetricsDTO()
       //         {
       //             Id = result.Id,
       //             ProjectName = result.ProjectName,
       //             TotalWorkCompleted = result.TotalWorkCompleted,
       //            TotalTracksCompleted = result.TotalTracksCompleted,
       //            TotalTaskCompleted = result.TotalTaskCompleted
       //         };
       //     }

       //     return _metrics;
       // }

        public Project GetProject(int id)
        {
            Project _project;

            using (var ctx = new ProjectModel())
            {
                //Query the table
                var result = (from t in ctx.Projects
                              where t.Id == id
                              select t).Single();
                _project = result;
            }

            return _project;
        }

    }
}
