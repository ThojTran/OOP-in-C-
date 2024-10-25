using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace ThiCuoiKy
{
    [Serializable]
    public partial class Form1 : Form
    {
        NotifyIcon notify;
        private List<List<Button>> matrix;

        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private Jobstatic jobstatic;
        private DateTime date;
        private PlanData job;
        private int time;
        private int appTime;

        public int AppTime
        {
            get { return appTime; }
            set { appTime = value; }
        }
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        public NotifyIcon Notify
        {
            get { return notify; }
            set { notify = value; }
        }

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public DateTime Date { get => date; set => date = value; }
        public PlanData Job { get => job; set => job = value; }
        public Jobstatic Jobstatic { get => jobstatic; set => jobstatic = value; }

        private string filePath = "data.xml";

        public Form1()
        {
            InitializeComponent();

            Notify = new NotifyIcon();

            appTime = 0;
            LoadMtrix();
            try
            {
                Job = DeserializeFromXML(filePath) as PlanData;
            }
            catch
            {
                SetDefualData();

            }

        }
        private void SerializeToXML(object data, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            XmlSerializer sr = new XmlSerializer(typeof(PlanData));

            sr.Serialize(fs, data);

            fs.Close();
        }

        private object DeserializeFromXML(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(PlanData));

                object result = sr.Deserialize(fs);
                fs.Close();
                return result;
            }
            catch (Exception)
            {
                fs.Close();
                throw new NotImplementedException();
            }
        }



        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            SerializeToXML(Job, filePath);
        }


        void SetDefualData()
        {
            Job = new PlanData();
            Job.Job = new List<PlanItem>();
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "test",
                Status = PlanItem.liststatus[(int)StatusEnum.Coming]
            });

            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "test",
                Status = PlanItem.liststatus[(int)StatusEnum.Coming]
            });

            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "test",
                Status = PlanItem.liststatus[(int)StatusEnum.Coming]
            });

            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "test",
                Status = PlanItem.liststatus[(int)StatusEnum.Coming]
            });


        }

        void LoadMtrix()
        {

            Matrix = new List<List<Button>>();
            Button preBtn = new Button() { Width = 40, Height = 40, Location = new Point(-Cons.margin, 0) };
            for (int i = 0; i < Cons.Row; i++)
            {

                Matrix.Add(new List<Button>());

                for (int j = 0; j < Cons.Column; j++)
                {

                    Button button = new Button() { Width = Cons.sizeBtnWidth, Height = Cons.sizeBtnHeight };
                    button.Location = new Point(preBtn.Location.X + preBtn.Width + Cons.margin, preBtn.Location.Y);

                    pnlMatrix.Controls.Add(button);
                    button.Click += btn_Click;

                    Matrix[i].Add(button);

                    preBtn = button;
                }
                preBtn = new Button()
                {
                    Width = 40,
                    Height = 40,
                    Location = new Point(-Cons.margin, preBtn.Location.Y + Cons.sizeBtnHeight)
                };
            }
            DefualtDate();
            // AddNunmberMatrixByDate(dtpkDate.Value);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as Button).Text))
                return;
            DailyPlan daily = new DailyPlan(new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month, Convert.ToInt32((sender as Button).Text)), Job);
            daily.ShowDialog();
        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;

                default:
                    return 30;

            }
        }

        void DefualtDate()
        {
            dtpkDate.Value = DateTime.Now;
        }

        bool cmpDate(DateTime a, DateTime b)
        {
            return a.Year == b.Year && a.Month == b.Month && a.Day == b.Day;
        }

        List<PlanItem> JobByDay(DateTime date)
        {
            List<PlanItem> result = new List<PlanItem>();

            foreach (PlanItem item in Job.Job)
            {
                if (item.Date.Year == date.Year && item.Date.Month == date.Month && item.Date.Day == date.Day)
                {
                    result.Add(item);
                }
            }

            return result;
        }
        void AddNunmberMatrixByDate(DateTime date)
        {
            ClearMatrix();

            DateTime useDate = new DateTime(date.Year, date.Month, 1);

            int line = 0;
            for (int i = 1; i <= DayOfMonth(date); i++)
            {

                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button button = Matrix[line][column];
                button.Text = i.ToString();

                if (cmpDate(useDate, DateTime.Now))
                {
                    button.BackColor = Color.DeepPink;
                }
                if (cmpDate(useDate, date))
                {
                    button.BackColor = Color.Aqua;
                }

                if (column >= 6)
                    line++;

                useDate = useDate.AddDays(1);
            }

        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";

                    btn.BackColor = Color.Silver;
                }

            }
        }
        private void tmNotify_Tick(object sender, EventArgs e)
        {
            // Nếu checkbox thông báo không được chọn thì không chạy thông báo
            if (!ckbNotify.Checked)
            {
                return;
            }

            // Tăng biến đếm thời gian
            AppTime++;

            // Nếu chưa đến thời gian thông báo, thoát ra khỏi hàm
            if (AppTime < Cons.notifyTime)
            {
                return;
            }

            DateTime currentDate = DateTime.Now;

            // Kiểm tra các công việc trong ngày hiện tại
            List<PlanItem> todayJobs = new List<PlanItem>();
            foreach (PlanItem job in Job.Job)
            {
                if (job.Date.Year == currentDate.Year && job.Date.Month == currentDate.Month && job.Date.Day == currentDate.Day)
                {
                    if (job.Status == PlanItem.liststatus[(int)StatusEnum.Coming] || job.Status == PlanItem.liststatus[(int)StatusEnum.Doing])
                    {
                        todayJobs.Add(job);
                    }
                }
            }

            // Nếu có công việc, hiển thị Form thông báo
            if (todayJobs.Count > 0)
            {
                string message = $"Bạn có {todayJobs.Count} việc cần làm trong ngày hôm nay";
                NotifyForm notifyForm = new NotifyForm(message);
                notifyForm.ShowDialog();  // Hiển thị Form thông báo
            }

            // Reset lại biến đếm thời gian sau khi thông báo
            AppTime = 0;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AddNunmberMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnMonday_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            nmNotify.Enabled = ckbNotify.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(jobstatic.DailyJob(Job, date));
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

            MessageBox.Show(jobstatic.DailyJob(Job, date));
        }

        private void btnTuesday_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nmNotify_ValueChanged(object sender, EventArgs e)
        {
            Cons.notifyTime = (int)nmNotify.Value;
        }
    }

    //public Form1()
    //{
    //    InitializeComponent();

    //    RegistryKey regkey = Registry.CurrentUser.CreateSubKey("Software\\Calendar");
    //    //mo registry khoi dong cung win
    //    RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
    //    string keyvalue = "1";
    //    //string subkey = "Software\\ManhQuyen";
    //    try
    //    {
    //        //chen gia tri key
    //        regkey.SetValue("Index", keyvalue);
    //        //regstart.SetValue("taoregistrytronghethong", "E:\\Studing\\Bai Tap\\CSharp\\Channel 4\\bai temp\\tao registry trong he thong\\tao registry trong he thong\\bin\\Debug\\tao registry trong he thong.exe");
    //        regstart.SetValue("Calendar", Application.StartupPath + "\\BTL_Lich.exe");
    //        ////dong tien trinh ghi key
    //        //regkey.Close();
    //    }
    //    catch (System.Exception ex)
    //    {
    //    }

    //}

    //private void tmNotify_Tick(object sender, EventArgs e)
    //{

    //    if (!ckbTB.Checked)
    //        return;
    //    Time++;
    //    if (time < Cons.notifyTime)
    //        return;
    //    if (Job == null || Job.ListJob == null || Job.ListJob.Count == 0)
    //        return;
    //    DateTime current = DateTime.Now;
    //    DateTime tomorrow = DateTime.Now.AddDays(1);
    //    //MessageBox.Show(current.Minute.ToString());
    //    if (dtpkDate.Value.Year != current.Year || dtpkDate.Value.Month != current.Month || dtpkDate.Value.Day != current.Day)
    //        return;
    //    for (int i = 0; i < Job.ListJob.Count; i++)
    //    {
    //        //if (  current.Hour >= Job.ListJob[i].ToTime.X && current.Minute >= Job.ListJob[i].ToTime.Y)
    //        if (Job.ListJob[i].ToTime.X * 3600 + Job.ListJob[i].ToTime.Y * 60 < current.Hour * 3600 + current.Minute * 60
    //            && Job.ListJob[i].Status != "Done" && Job.ListJob[i].Date.Year == current.Year
    //            && Job.ListJob[i].Date.Month == current.Month && Job.ListJob[i].Date.Day == current.Day
    //            && Job.ListJob[i].Job != null)
    //        {
    //            Job.ListJob[i].Status = "Missed";


    //        }
    //    }

    //    int dem = 0;
    //    for (int i = 0; i < Job.ListJob.Count; i++)
    //    {
    //        if (Job.ListJob[i].Status == "Doing")
    //        {
    //            dem++;
    //        }

    //    }
    //    if (dem == 0)
    //    {
    //        return;
    //    }


    //    /* List<PlanItem> listTodayDone = Job.ListJob.Where
    //     (p => p.Date.Year == current.Year && p.Date.Month == current.Month
    //     && p.Date.Day == current.Day && PlanItem.list.IndexOf(p.Status) == (int)ePlanItem.Done).ToList();

    //     List<PlanItem> listTodayMissed = Job.ListJob.Where
    //     (p => p.Date.Year == current.Year && p.Date.Month == current.Month
    //     && p.Date.Day == current.Day && PlanItem.list.IndexOf(p.Status) == (int)ePlanItem.Missed).ToList();

    //     List<PlanItem> listTomorrow = Job.ListJob.Where
    //     (p => p.Date.Year == tomorrow.Year && p.Date.Month == tomorrow.Month
    //     && p.Date.Day == tomorrow.Day).ToList();*/

    //    //List<PlanItem> listTen = Job.ListJob.Where(p=>p.Date.Year)

    //    //////////////////////////////////////////////////////////////////////////////////
    //    List<PlanItem> listTodayDoing = Job.ListJob.Where
    //    (p => p.Date.Year == current.Year && p.Date.Month == current.Month
    //    && p.Date.Day == current.Day && PlanItem.list.IndexOf(p.Status) == (int)ePlanItem.Doing
    //    && p.FromTime.X * 3600 + p.FromTime.Y * 60 <= current.Hour * 3600 + current.Minute * 60
    //    && p.ToTime.X * 3600 + p.ToTime.Y * 60 >= current.Hour * 3600 + current.Minute * 60).ToList();

    //    string tam = "";
    //    for (int i = 0; i < listTodayDoing.Count; i++)
    //    {
    //        tam += "- " + listTodayDoing[i].Job + "\n";
    //    }

    //    notifyIcon1.ShowBalloonTip(Cons.timeOut, "Lịch công việc",
    //   string.Format("Bạn đang có {0} công việc cần làm: \n", listTodayDoing.Count) + tam, ToolTipIcon.Info);



    //    /* notifyIcon1.ShowBalloonTip
    //     (Cons.timeOut, "Lịch công việc",
    //     string.Format("Bạn có {0} công việc đang làm, {1} đã hoàn thành," +
    //     " {2} bỏ lỡ trong ngày hôm nay \n" +
    //     "Ngày mai bạn có {3} công việc cần làm", 
    //     listTodayDoing.Count,listTodayDone.Count,listTodayMissed.Count,listTomorrow.Count),
    //     ToolTipIcon.Info);*/

    //}



    //private void nmTB_ValueChanged(object sender, EventArgs e)
    //{
    //    Cons.notifyTime = (int)nmNotify.Value;
    //}

    //private void ckbTB_CheckedChanged(object sender, EventArgs e)
    //{
    //    nmNotify.Enabled = ckbTB.Checked;
    //}

    //private void Calender_FormClosed(object sender, FormClosedEventArgs e)
    //{
    //    Application.Exit();

    //}

    //private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
    //{
    //    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.AboveRight);
    //}

    //private void tsmnJob_Click(object sender, EventArgs e)
    //{

    //    WindowState = FormWindowState.Normal;
    //    this.ShowInTaskbar = true;
    //    DailyPlan plan = new DailyPlan(dtpkDate.Value, Job);
    //    plan.Show();

    //}

    //private void tsmnExit_Click(object sender, EventArgs e)
    //{
    //    Application.Exit();
    //}

    //private void notifyIcon1_Click(object sender, EventArgs e)
    //{
    //    WindowState = FormWindowState.Normal;
    //    this.ShowInTaskbar = true;
    //        DailyPlan plan = new DailyPlan(dtpkDate.Value, Job);
    //    plan.Show();
    //}

    //private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
    //{
    //    WindowState = FormWindowState.Normal;
    //    this.ShowInTaskbar = true;
    //    DailyPlan plan = new DailyPlan(dtpkDate.Value, Job);
    //    plan.Show();
    //}
}
