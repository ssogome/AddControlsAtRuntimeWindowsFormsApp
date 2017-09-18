namespace AddControlsAtRuntimeWindowsFormsApp.DATA
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Project
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        [Column(TypeName = "money")]
        public decimal? ApprovedBudget { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualToDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? ProjectedBudget { get; set; }

        [Column(TypeName = "money")]
        public decimal? ProjectedCostVariance { get; set; }

        [Column("WorkOrder-BaseEstimate", TypeName = "money")]
        public decimal? WorkOrder_BaseEstimate { get; set; }

        [Column("WorkOrder-BaseEstimateVariance", TypeName = "money")]
        public decimal? WorkOrder_BaseEstimateVariance { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ApprovedEndDate { get; set; }

        public DateTime? ProjectedEndDate { get; set; }

        public int? EndDateVariance { get; set; }

        [Column("WorkOrder-BaseEstimateDate")]
        public DateTime? WorkOrder_BaseEstimateDate { get; set; }

        [Column("WorkOrder-BaseEstimateDateVariance")]
        public int? WorkOrder_BaseEstimateDateVariance { get; set; }

        public DateTime? ActualWorkEndDate { get; set; }

        public int? ActualWorkEndDateVariance { get; set; }

        public int? TotalWorkOrder { get; set; }

        public int? TotalWorkCompleted { get; set; }

        public int? TotalTask { get; set; }

        public int? TotalTaskCompleted { get; set; }

        public int? TotalTracks { get; set; }

        public int? TotalTracksCompleted { get; set; }
    }
}
