using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiCuoiKy
{
    [Serializable]
    public partial class DailyPlan : Form
    {
        private Jobstatic jobstatic;
        private DateTime date;
        private PlanData job;

        public DateTime Date { get => date; set => date = value; }
        internal PlanData Job { get => job; set => job = value; }
        public Jobstatic Jobstatic { get => jobstatic; set => jobstatic = value; }

        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        public DailyPlan(DateTime date, PlanData job)
        {
            InitializeComponent();

            this.Date = date;
            this.Job = job;


            fPanel.Width = pnlJob.Width;
            fPanel.Height = pnlJob.Height;
            pnlJob.Controls.Add(fPanel);

            fPanel.AutoScroll = true;

            dtpkDate.Value = Date;

            ShowJob(Date);
            UpdateJob();

        }
        public void ShowJob(DateTime date)
        {
            fPanel.Controls.Clear();
            if (job != null && Job.Job != null)
            {
                List<PlanItem> today = GetJobByDate(date);
                for (int i = 0; i < today.Count; i++)
                {
                    AddJob(today[i]);
                    
                }
            }
        }
        void AddJob(PlanItem job)
        {
            AJob dayJob = new AJob(job);
            dayJob.Edited += DayJob_Edited;
            dayJob.Deleted += DayJob_Deleted;

            fPanel.Controls.Add(dayJob);

        }
        private void DayJob_Deleted(object sender, EventArgs e)
        {
            AJob uc = (AJob)sender;
            PlanItem job = uc.Job;

            fPanel.Controls.Remove(uc);

            Job.Job.Remove(job);
            UpdateJob();
        }

        private void DayJob_Edited(object sender, EventArgs e)
        {

            UpdateJob();
        }
        public void UpdateJob()
        {
            if (Jobstatic == null)
            {
                Jobstatic = new Jobstatic();
            }

            if (Job == null)
            {
                Job = new PlanData();
            }
            string statistic = Jobstatic.DailyJob(Job, dtpkDate.Value);
            toolStripStatusLabel1.Text = statistic;
        }
        public List<PlanItem> GetJobByDate(DateTime date)
        {
            List<PlanItem> result = new List<PlanItem>();

            foreach (PlanItem job in Job.Job)
            {
                if (job.Date.Year == date.Year && job.Date.Month == date.Month && job.Date.Day == date.Day)
                {
                    result.Add(job);
                }
            }

            return result;
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowJob((sender as DateTimePicker).Value);
            UpdateJob();
        }

        private void pnlJob_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);
        }

        private void mnsiToDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void mnsiAddJob_Click(object sender, EventArgs e)
        {
            PlanItem item = new PlanItem() { Date = dtpkDate.Value };
            Job.Job.Add(item);
            AddJob(item);
            UpdateJob();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(jobstatic.DailyJob(Job, dtpkDate.Value));
        }

        private void tsslTotal_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(jobstatic.DailyJob(Job, dtpkDate.Value));
        }
    }
}
