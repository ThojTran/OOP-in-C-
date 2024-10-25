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
    public partial class AJob : UserControl
    {

        private PlanItem job;
        private DailyPlan daily;
        public PlanItem Job { get => job; set => job = value; }
        public DailyPlan Daily { get => daily; set => daily = value; }

        private JobEventChange eventHandler;

        public event EventHandler Edited
        {
            add { eventHandler.Edited += value; }
            remove { eventHandler.Edited -= value; }
        }
        public event EventHandler Deleted
        {
            add { eventHandler.Deleted += value; }
            remove { eventHandler.Deleted -= value; }
        }
        public AJob(PlanItem job)
        {
            InitializeComponent();
            cbStatus.DataSource = PlanItem.liststatus;
            this.Job = job;
            this.eventHandler = new JobEventChange();
            ShowInfo();
        }
        void ShowInfo()
        {
            txbJob.Text = Job.Job;
            nmFromHour.Value = Job.FromTime.X;
            nmFromMinute.Value = Job.FromTime.Y;
            nmToHour.Value = Job.ToTime.X;
            nmToMinute.Value = Job.ToTime.Y;
            textBox2.Text = Job.Note1;
            cbStatus.SelectedIndex = PlanItem.liststatus.IndexOf(Job.Status);
            ckbDone.Checked = PlanItem.liststatus.IndexOf(Job.Status) == (int)StatusEnum.Done ? true : false;
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = ckbDone.Checked ? (int)StatusEnum.Done : (int)StatusEnum.Doing;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            eventHandler.OnDeleted(this, EventArgs.Empty);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Job.Note1 = textBox2.Text;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Job.Job = txbJob.Text;
            Job.FromTime = new Point((int)nmFromHour.Value, (int)nmFromMinute.Value);
            Job.ToTime = new Point((int)nmToHour.Value, (int)nmToMinute.Value);
            Job.Status = PlanItem.liststatus[cbStatus.SelectedIndex];
            eventHandler.OnEdited(this, EventArgs.Empty);

            if (!ckbDone.Checked && DateTime.Now.Year == Job.Date.Year && DateTime.Now.Month == Job.Date.Month && DateTime.Now.Day == Job.Date.Day)
            {
                if ((DateTime.Now.Hour < nmFromHour.Value && DateTime.Now.Minute < nmFromMinute.Value) || (DateTime.Now.Hour < nmFromHour.Value) || (DateTime.Now.Hour == nmFromHour.Value && DateTime.Now.Minute < nmFromMinute.Value ))
                {
                    cbStatus.SelectedIndex = (int)StatusEnum.Coming;
                }
                else if ((DateTime.Now.Hour > nmToHour.Value && DateTime.Now.Minute > nmToMinute.Value) || (DateTime.Now.Hour > nmToHour.Value) || (DateTime.Now.Hour == nmToHour.Value && DateTime.Now.Minute > nmToMinute.Value)) 
                {
                    cbStatus.SelectedIndex = (int)StatusEnum.Late;
                }
                else
                    checkBox1_CheckedChanged(this, EventArgs.Empty);
            }

        }

        private void nmFromHour_ValueChanged(object sender, EventArgs e)
        {
            if (nmFromHour.Value == 24 )
            {
                nmFromHour.Value = 0;
            }    

        }

        private void nmFromMinute_ValueChanged(object sender, EventArgs e)
        {
            if(nmFromMinute.Value == 60 )
            {
                nmFromMinute.Value = 0;
            }
        }

        private void nmToHour_ValueChanged(object sender, EventArgs e)
        {
            if (nmToHour.Value == 24)
            {
                nmToHour.Value = 0;
            }
        }

        private void nmToMinute_ValueChanged(object sender, EventArgs e)
        {
            if (nmToMinute.Value == 60)
            {
                nmToMinute.Value = 0;
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
