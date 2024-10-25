using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiKy
{

    public interface IPlanItem
    {
        DateTime Date { get; set; }
        string Job { get; set; }
        Point FromTime { get; set; }
        Point ToTime { get; set; }
        string Status { get; set; }
        string Note1 { get; set; }
    }

    [Serializable]
    public class PlanItem : IPlanItem
    {
        private DateTime date;
        private string job;
        private Point fromTime;
        private Point toTime;
        private string status;
        private string Note;

        public static List<string> liststatus = new List<string>() { "Done", "Late", "Coming", "Doing" };

        public DateTime Date { get => date; set => date = value; }
        public string Job { get => job; set => job = value; }
        public Point FromTime { get => fromTime; set => fromTime = value; }
        public Point ToTime { get => toTime; set => toTime = value; }
        public string Status { get => status; set => status = value; }
        public string Note1 { get => Note; set => Note = value; }

    }
    public enum StatusEnum
    {
        Done,
        Late,
        Coming,
        Doing,
    }
}
