using AddControlsAtRuntimeWindowsFormsApp.DATA;
using AddControlsAtRuntimeWindowsFormsApp.DataAccess;
using AddControlsAtRuntimeWindowsFormsApp.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AddControlsAtRuntimeWindowsFormsApp
{
    public partial class Form1 : Form
    {
        
        private FlowLayoutPanel flowPanel = new FlowLayoutPanel();
        
       
      
        private string[] projectCost = {"Project Cost", "Approved Budget", "Actual to Date", "Remaining Balance", "WO-based Estimate", "Estimate Variance", "Projected", "Cost Variance"};
        private string[] Schedule = {"Schedule", "Approved End Date", "Projected End Date", "Variance", "WO-based Estimate", "Variance", "Actual End Date", "Variance" };
        private string[] WOSummary = {"Work Order Summary", "WO Completed/Total", "% Completed WO", "Tasks Completed/Total", "% Tasks Completed", "Tracks Completed/Total", "% Tracks Completed", "" };
        private string[] Metrics = {"Metrics", "Date", "WO Completed", "Tracks Completed", "Tasks Completed", "" };
        private ProjectCostDTO pcResult = null;
        private ScheduleDTO schResult = null;
        private WOSummaryDTO wosResult = null;
        private MetricsDTO mResult = null;
        private string[] lblContent = new string[7];
        private int id;

        public Form1()
        {
            InitializeComponent();
            id = 6;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(1000, 600);
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            Button CloseBtn = new Button();
            CloseBtn.SuspendLayout();
            CloseBtn.Size = new Size(120, 22);
            CloseBtn.Text = "Close";
            EventHandler CloseHandler = new EventHandler(CloseBtn_Click);
            CloseBtn.Click += CloseHandler;
            CloseBtn.ResumeLayout();

            TabControl tab = new TabControl();
            tab.SuspendLayout();
            tab.Size = new Size(950, 590);            
            
            TabPage tabPg1 = new TabPage("Projects");
            tabPg1.SuspendLayout();
            tabPg1.Size = new Size(900, 580);
            tabPg1.BackColor = Color.White;
            tab.TabPages.Add(tabPg1);
            tabPg1.ResumeLayout(false);

            TabPage tabPg2 = new TabPage("Budget");
            tabPg2.SuspendLayout();
            tab.TabPages.Add(tabPg2);
            tabPg2.Size = new Size(900, 550);
            tabPg2.BackColor = Color.White;
            tabPg2.ResumeLayout(false);

            //The FlowLayout
            this.flowPanel.SuspendLayout();
            this.flowPanel.AutoScroll = false;            
            this.flowPanel.BackColor = Color.Transparent;
            this.flowPanel.Size = new Size(900, 500);
            this.flowPanel.Location = new Point(10 , 10);
            this.flowPanel.FlowDirection = FlowDirection.LeftToRight;
            this.flowPanel.WrapContents = true;
            this.flowPanel.Dock = DockStyle.Fill;

            loadTopLabels();
            loadTables();

            //this.tab.Controls.Add(this.flowPanel);
            tabPg2.Controls.Add(this.flowPanel);
            tabPg2.ResumeLayout(false);
            this.flowPanel.ResumeLayout(false);
            tab.ResumeLayout(false);

            //Add controls to the form.

            //this.Controls.Add(flowPanel);
            this.Controls.Add(tab);
           
        }

        private void loadTables()
        {

            for (var i = 0; i < 8; i++)
            {
                this.flowPanel.SuspendLayout();

                switch (i)
                {
                    case 0:                          
                        GroupBox gp0 = new GroupBox();
                        gp0.SuspendLayout();
                        
                        gp0.AutoSize = false;
                        gp0.Height = 170;
                        gp0.Width = 210;
                       
                        LoadProjectCostGroupWithParams(gp0, projectCost);
                        this.flowPanel.Controls.Add(gp0);
                        gp0.ResumeLayout(false);
                        break;
                    case 1:                        
                        GroupBox gp1 = new GroupBox();
                        gp1.SuspendLayout();

                        gp1.AutoSize = false;
                        gp1.Height = 170;
                        gp1.Width = 210;
                       
                        LoadProjectCostGroupWithParams(gp1, Schedule);
                        this.flowPanel.Controls.Add(gp1);
                        gp1.ResumeLayout(false);
                        break;
                    case 2:                        
                        GroupBox gp2 = new GroupBox();
                        gp2.SuspendLayout();

                        gp2.AutoSize = false;
                        gp2.Height = 170;
                        gp2.Width = 210;
                       
                        LoadProjectCostGroupWithParams(gp2, WOSummary);
                        this.flowPanel.Controls.Add(gp2);
                        gp2.ResumeLayout(false);
                        break;
                    case 3:                        
                        GroupBox gp3 = new GroupBox();
                        gp3.SuspendLayout();

                        gp3.AutoSize = false;
                        gp3.Height = 170;
                        gp3.Width = 280;
                        
                        LoadProjectCostMetricsGroupWithParams(gp3, Metrics);
                        this.flowPanel.Controls.Add(gp3);
                        gp3.ResumeLayout(false);

                        Label orderDetail = new Label();
                        orderDetail.Size = new Size(930, 20);
                        orderDetail.SuspendLayout();
                        orderDetail.Text = "Work Order Details";
                        orderDetail.BackColor = Color.DarkSlateGray;
                        orderDetail.Font = new Font("Arial", 14, FontStyle.Bold);

                        this.flowPanel.SetFlowBreak(orderDetail, true);
                        this.flowPanel.Controls.Add(orderDetail);
                        orderDetail.ResumeLayout(false);
                        loadBottomLabels();
                        break;
                    case 4:                       
                        GroupBox gp4 = new GroupBox();
                        gp4.SuspendLayout();

                        gp4.AutoSize = false;
                        gp4.Height = 170;
                        gp4.Width = 210;
                        
                        LoadProjectCostGroupWithParams(gp4, projectCost);
                        this.flowPanel.Controls.Add(gp4);
                        gp4.ResumeLayout(false);
                        break;
                    case 5:                       
                        GroupBox gp5 = new GroupBox();
                        gp5.SuspendLayout();

                        gp5.AutoSize = false;
                        gp5.Height = 170;
                        gp5.Width = 210;
                        
                        LoadProjectCostGroupWithParams(gp5, Schedule);
                        this.flowPanel.Controls.Add(gp5);
                        gp5.ResumeLayout(false);
                        break;
                    case 6:                       
                        GroupBox gp6 = new GroupBox();
                        gp6.SuspendLayout();

                        gp6.AutoSize = false;
                        gp6.Height = 170;
                        gp6.Width = 210;
                        //gp0.BackColor = Color.Red;
                        LoadProjectCostGroupWithParams(gp6, WOSummary);
                        this.flowPanel.Controls.Add(gp6);
                        gp6.ResumeLayout(false);
                        break;
                    case 7:                       
                        GroupBox gp7 = new GroupBox();
                        gp7.SuspendLayout();

                        gp7.AutoSize = false;
                        gp7.Height = 170;
                        gp7.Width = 280;
                       
                        LoadProjectCostMetricsGroupWithParams(gp7, Metrics);
                        this.flowPanel.Controls.Add(gp7);
                        gp7.ResumeLayout(false);
                        break;
                }

                this.flowPanel.ResumeLayout();
            }

        }

        private void loadBottomLabels()
        {
            this.flowPanel.SuspendLayout();

            Label wo = new Label();
            wo.SuspendLayout();
            wo.Size = new Size(100, 20);
            wo.Text = "Work Order";
            wo.ForeColor = Color.LightBlue;
            wo.Font = new Font("Arial", 10, FontStyle.Bold);
            wo.BackColor = Color.Transparent;

            this.flowPanel.Controls.Add(wo);
            wo.ResumeLayout();

            ComboBox cbox = new ComboBox();
            cbox.SuspendLayout();
            cbox.Size = new Size(130, 20);
            cbox.BackColor = Color.LightBlue;
            List<string> cboxLst = new List<string>();
            cboxLst.Add("Item#1");
            cboxLst.Add("Item#2");
            cbox.DataSource = cboxLst;

            this.flowPanel.Controls.Add(cbox);
            cbox.ResumeLayout();


            Label bappbdgt = new Label();
            bappbdgt.SuspendLayout();
            bappbdgt.Size = new Size(130, 20);
            bappbdgt.Text = "Approved Project Budget";
            bappbdgt.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(bappbdgt);
            bappbdgt.ResumeLayout();

            TextBox bappbdgttxtbox = new TextBox();
            bappbdgttxtbox.SuspendLayout();
            bappbdgttxtbox.Size = new Size(100, 20);
            bappbdgttxtbox.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(bappbdgttxtbox);
            bappbdgttxtbox.ResumeLayout();

            Label bstartDate = new Label();
            bstartDate.SuspendLayout();
            bstartDate.Size = new Size(75, 20);
            bstartDate.Text = "Start Date";
            bstartDate.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(bstartDate);
            bstartDate.ResumeLayout();

            DateTimePicker bsdate = new DateTimePicker();
            bsdate.SuspendLayout();
            bsdate.Size = new Size(100, 20);
            bsdate.Format = DateTimePickerFormat.Custom;
            bsdate.CustomFormat = "dd/MM/yyyy";

            this.flowPanel.Controls.Add(bsdate);
            bsdate.ResumeLayout();

            Label bendDate = new Label();
            bendDate.SuspendLayout();
            bendDate.Size = new Size(75, 20);
            bendDate.Text = "Start Date";
            bendDate.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(bendDate);
            bendDate.ResumeLayout();

            DateTimePicker bedate = new DateTimePicker();
            bedate.SuspendLayout();
            bedate.Size = new Size(100, 20);
            bedate.Format = DateTimePickerFormat.Custom;
            bedate.CustomFormat = "dd/MM/yyyy";
            this.flowPanel.SetFlowBreak(bedate, true);
            this.flowPanel.Controls.Add(bedate);
            bedate.ResumeLayout();

            this.flowPanel.ResumeLayout();
        }

        private void loadTopLabels()
        {
            this.flowPanel.SuspendLayout();
            LinkLabel link = new LinkLabel();
            link.SuspendLayout();
            link.Size = new Size(75, 20);
            link.Text = "Link Tasks";
            link.BackColor = Color.Transparent;

            this.flowPanel.Controls.Add(link);
            link.ResumeLayout(false);

            Label appbdgt = new Label();
            appbdgt.SuspendLayout();
            appbdgt.Size = new Size(130, 20);
            appbdgt.Text = "Approved Project Budget";
            appbdgt.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(appbdgt);
            appbdgt.ResumeLayout();

            TextBox appbdgttxtbox = new TextBox();
            appbdgttxtbox.SuspendLayout();
            appbdgttxtbox.Size = new Size(100, 20);
            appbdgttxtbox.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(appbdgttxtbox);
            appbdgttxtbox.ResumeLayout();

            Label startDate = new Label();
            startDate.SuspendLayout();
            startDate.Size = new Size(130, 20);
            startDate.Text = "Start Date";
            startDate.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(startDate);
            startDate.ResumeLayout();

            DateTimePicker sdate = new DateTimePicker();
            sdate.SuspendLayout();
            sdate.Size = new Size(130, 20);
            sdate.Format = DateTimePickerFormat.Custom;
            sdate.CustomFormat = "dd/MM/yyyy";

            this.flowPanel.Controls.Add(sdate);
            sdate.ResumeLayout();

            Label endDate = new Label();
            endDate.SuspendLayout();
            endDate.Size = new Size(130, 20);
            endDate.Text = "Start Date";
            endDate.BackColor = Color.LightBlue;

            this.flowPanel.Controls.Add(endDate);
            endDate.ResumeLayout();

            DateTimePicker edate = new DateTimePicker();
            edate.SuspendLayout();
            edate.Size = new Size(130, 20);
            edate.Format = DateTimePickerFormat.Custom;
            edate.CustomFormat = "dd/MM/yyyy";
            this.flowPanel.SetFlowBreak(edate, true);
            this.flowPanel.Controls.Add(edate);
            edate.ResumeLayout();

            this.flowPanel.ResumeLayout(false);
        }

        private void LoadProjectCostGroupWithParams(GroupBox gp, params string[] controlNames)
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.SuspendLayout();
            flow.Height = 170;
            flow.Width = 210;
           
            flow.Dock = DockStyle.Fill;

            Label title = new Label();
            title.SuspendLayout();
            title.Text = controlNames[0];
            title.Size = new Size(210, 20);
            title.BackColor = Color.Gray;
           
            title.ForeColor = Color.White;
            title.Font = new Font("Arial", 10, FontStyle.Regular);

            flow.Controls.Add(title);
            title.ResumeLayout(false);

            TableLayoutPanel tbl = new TableLayoutPanel();
            tbl.SuspendLayout();
            tbl.Size = new Size(210, 150);
          //  tbl.ColumnCount = 2;
           // tbl.BackColor = Color.Green;
           // tbl.AutoSize = true;
           // tbl.Dock = DockStyle.Fill;
            //tbl.Height = 250;
            //tbl.Width = 210;
            //tbl.BorderStyle = BorderStyle.FixedSingle;
            LoadProjectCostTableWithParams(tbl, controlNames[0], id, controlNames);
            flow.Controls.Add(tbl);
            tbl.ResumeLayout(false);
           
            gp.Controls.Add(flow);
            flow.ResumeLayout(false);
        }

        private void LoadProjectCostMetricsGroupWithParams(GroupBox gp, params string[] controlNames)
        {
            string lblName = controlNames[0];
           
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.SuspendLayout();
            flow.Height = 170;
            flow.Width = 280;

            flow.Dock = DockStyle.Fill;

            Label title = new Label();
            title.SuspendLayout();
            title.Text = controlNames[0];
            title.Size = new Size(280, 20);
            title.BackColor = Color.Gray;

            title.ForeColor = Color.White;
            title.Font = new Font("Arial", 10, FontStyle.Regular);

            flow.Controls.Add(title);
            title.ResumeLayout(false);

            if (controlNames[1] == "Date")
            {                
                Panel panel = new Panel();
                panel.SuspendLayout();
                panel.Size = new Size(280, 20);
               // panel.BackColor = Color.Red;

                FlowLayoutPanel dateflow = new FlowLayoutPanel();
                dateflow.SuspendLayout();
                dateflow.Dock = DockStyle.Fill;
                Label c = new Label();
                c.SuspendLayout();
                c.Size = new Size(30, 15);
                c.ForeColor = Color.LightBlue;
                c.Text = "From";
                dateflow.Controls.Add(c);
                c.ResumeLayout(false);

                DateTimePicker dt = new DateTimePicker();
                dt.SuspendLayout();
                dt.Size = new Size(80, 15);
                dt.Format = DateTimePickerFormat.Custom;
                dt.CustomFormat = "dd/MM/yyyy";
                dateflow.Controls.Add(dt);
                dt.ResumeLayout(false);

                Label cV = new Label();
                cV.SuspendLayout();
                cV.Size = new Size(20, 15);
                cV.ForeColor = Color.LightBlue;
                cV.Text = "To";
                dateflow.Controls.Add(cV);
                cV.ResumeLayout(false);
                panel.Controls.Add(dateflow);
                dateflow.ResumeLayout(false);

                DateTimePicker edt = new DateTimePicker();
                edt.SuspendLayout();
                edt.Size = new Size(80, 15);
                edt.Format = DateTimePickerFormat.Custom;
                edt.CustomFormat = "dd/MM/yyyy";
                dateflow.Controls.Add(edt);
                dt.ResumeLayout(false);

                panel.ResumeLayout(false);
                flow.Controls.Add(panel);
            }                      

            TableLayoutPanel tbl = new TableLayoutPanel();
            tbl.SuspendLayout();
            tbl.Size = new Size(280, 150);
           
            //LoadProjectCostTableWithParams(tbl, controlNames[0], id, controlNames);
            flow.Controls.Add(tbl);
            tbl.ResumeLayout(false);

            gp.Controls.Add(flow);
            flow.ResumeLayout(false);
        }

        private void LoadProjectCostTableWithParams(TableLayoutPanel tbl, string tblNameType, int id, params string[] controlNames)
        {
            tblNameType = controlNames[0];
            GetATableData(tblNameType, id, ref lblContent, controlNames);
           
            for (int i = 1; i < controlNames.Length; i++)
            {
                string lblName = controlNames[i];

                if(lblName != "")
                {                    
                Label c = new Label();
                c.SuspendLayout();
                c.Size = new Size(125, 15);
                c.ForeColor = Color.LightBlue;
                if (lblName == "Variance") c.Font = new Font("Arial", 8, FontStyle.Italic);
                if (lblName == "Remaining Balance") c.Font = new Font("Arial", 8, FontStyle.Italic);
                c.Text = lblName;
                tbl.Controls.Add(c, 0, i);
                c.ResumeLayout(false);
                }
                else
                {
                    List<string> lst = new List<string>();
                    lst.Add("Item#1");
                    lst.Add("Item#2");

                    ComboBox c = new ComboBox();
                    c.SuspendLayout();
                    c.Size = new Size(125, 15);
                    c.BackColor = Color.LightBlue;
                    c.DataSource = lst;
                    tbl.Controls.Add(c, 0, i);
                    c.ResumeLayout(false);
                }
                  
                    Label cV1 = new Label();
                    cV1.SuspendLayout();
                    cV1.Size = new Size(75, 15);
                    cV1.ForeColor = Color.LightBlue;
                    cV1.Text = lblContent[i-1];
                    tbl.Controls.Add(cV1, 1, i);
                    cV1.ResumeLayout(false);                                                     
                }                                                                          
                               
        }

        private void GetATableData(string tbl, int id, ref string[] lblCont, params string[] controlNames)
        {
            string tblNane = controlNames[0];
            switch (tblNane)
            {
                case "Project Cost":
                    GetPCData(id, ref pcResult);
                    lblCont[0] = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C}", pcResult.PC_ActualApprovedBudget);
                    lblCont[1] = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C}", pcResult.PC_ActualToDateBudget);
                    lblCont[2] = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C}", pcResult.PC_RemainingCostBudget);
                    lblCont[3] = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C}", pcResult.PC_WorkOrderBaseEstimate);
                    lblCont[4] = string.Format("{0}", pcResult.PC_WorkOrderBaseEstimateVariance);
                    lblCont[5] = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C}", pcResult.PC_ProjectedCost);
                    lblCont[6] = string.Format("{0}", pcResult.PC_ProjectedCostVariance);
                    break;
                case "Schedule":
                    GetSCHData(id, ref schResult);
                    lblCont[0] = (schResult.S_ApprovedEndDate).ToString();
                    lblCont[1] = (schResult.S_ProjectedEndDate).ToString();
                    lblCont[2] = (schResult.S_EndDateVariance).ToString();
                    lblCont[3] = (schResult.S_WorkOrder_BaseEstimateDate).ToString();
                    lblCont[4] = string.Format("{0}", schResult.S_WorkOrder_BaseEstimateDateVariance);
                    lblCont[5] = (schResult.S_ActualWorkEndDate).ToString();
                    lblCont[6] = string.Format("{0}", schResult.S_ActualWorkEndDateVariance);
                    break;
                case "Work Order Summary":
                    GetWOSData(id, ref wosResult);
                    lblCont[0] = string.Format("{0}/{1}", wosResult.WO_TotalWorkCompleted, wosResult.WO_TotalWorkOrder);
                    lblCont[1] = string.Format("{0}", wosResult.WO_percentCompleteWO);
                    lblCont[2] = string.Format("{0}/{1}", wosResult.WO_TotalTaskCompleted, wosResult.WO_TotalTask);
                    lblCont[3] = string.Format("{0}", wosResult.WO_percentTaskComplete);
                    lblCont[4] = string.Format("{0}/{1}", wosResult.WO_TotalTracksCompleted, wosResult.WO_TotalTracks);
                    lblCont[5] = string.Format("{0}", wosResult.WO_percentTrackComplete);
                    break;
                case "Metrics":
                    GetMData(id, ref mResult);
                    lblCont[0] = string.Format("{0}", mResult.M_TotalWorkCompleted);
                    lblCont[1] = string.Format("{0}", mResult.M_TotalTracksCompleted);
                    lblCont[2] = string.Format("{0}", mResult.M_TotalTaskCompleted);
                    break;

            }
                   

        }

        private void GetPCData(int id,  ref ProjectCostDTO result)
        {
             PopulateDataInForm data = new PopulateDataInForm();
             Project project = data.GetProject(id);
                          
                    result = PCostI(project);              
        }
        private void GetSCHData(int id, ref ScheduleDTO result)
        {
            PopulateDataInForm data = new PopulateDataInForm();
            Project project = data.GetProject(id);
           
            result = ScheduleI(project);
        }
        private void GetWOSData(int id, ref WOSummaryDTO result)
        {
            PopulateDataInForm data = new PopulateDataInForm();
            Project project = data.GetProject(id);

            result = WOSummaryI(project);
        }
        private void GetMData(int id, ref  MetricsDTO result)
        {
            PopulateDataInForm data = new PopulateDataInForm();
            Project project = data.GetProject(id);

            result = MetricsI(project);
        }

        //Return Data from query result  methods
        public ScheduleDTO ScheduleI(Project project)
        {
            return new ScheduleDTO(project);
        }
        public ProjectCostDTO PCostI(Project project)
        {
            return new ProjectCostDTO(project);
        }
        public WOSummaryDTO WOSummaryI(Project project)
        {
            return new WOSummaryDTO(project);
        }
        public MetricsDTO MetricsI(Project project)
        {
            return new MetricsDTO(project);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
