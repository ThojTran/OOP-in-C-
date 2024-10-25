using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiKy
{
    [Serializable]
    public class Jobstatic
    {
        private DateTime date;
        private PlanData job;

        public PlanData Job { get => job; set => job = value; }
        public DateTime Datetime { get => date; set => date = value; }
        public static int jobByDay(PlanData job, DateTime date)
        {
            int count = 0;
            foreach (PlanItem item in job.Job)
            {
                if (item.Date.Year == date.Year &&
                    item.Date.Month == date.Month &&
                    item.Date.Day == date.Day)
                {
                    count++;
                }
            }
            return count;
        }
        public static int jobDone(PlanData job, DateTime date)
        {
            int count = 0;
            foreach (PlanItem item in job.Job)
            {
                if (item.Date.Year == date.Year && item.Date.Month == date.Month && item.Date.Day == date.Day)
                {
                    if (PlanItem.liststatus.IndexOf(item.Status) == (int)StatusEnum.Done)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static int jobCoimg(PlanData job, DateTime date)
        {
            int count = 0;
            foreach (PlanItem item in job.Job)
            {
                if (item.Date.Year == date.Year && item.Date.Month == date.Month && item.Date.Day == date.Day)
                {
                    if (PlanItem.liststatus.IndexOf(item.Status) == (int)StatusEnum.Coming)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static int jobLate(PlanData job, DateTime date)
        {
            int count = 0;
            foreach (PlanItem item in job.Job)
            {
                if (item.Date.Year == date.Year && item.Date.Month == date.Month && item.Date.Day == date.Day)
                {
                    if (PlanItem.liststatus.IndexOf(item.Status) == (int)StatusEnum.Late)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static int jobDoing(PlanData job, DateTime date)
        {
            int count = 0;
            foreach (PlanItem item in job.Job)
            {
                if (item.Date.Year == date.Year && item.Date.Month == date.Month && item.Date.Day == date.Day)
                {
                    if (PlanItem.liststatus.IndexOf(item.Status) == (int)StatusEnum.Doing)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public string DailyJob(PlanData job, DateTime date)
        {
            return $"Tong: {jobByDay(job, date)} viec || " +
                   $"Done: {jobDone(job, date)} || " +
                   $"Doing: {jobDoing(job, date)} || " +
                   $"Missed: {jobLate(job, date)} || " +
                   $"Comming: {jobCoimg(job, date)} || ";
        }
    }
}
