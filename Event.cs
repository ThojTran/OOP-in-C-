using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiKy
{
    internal class JobEventChange
    {
        public event EventHandler Edited;
        public event EventHandler Deleted;

        public void OnEdited(object sender, EventArgs e)
        {
            Edited?.Invoke(sender, e);
        }

        public void OnDeleted(object sender, EventArgs e)
        {
            Deleted?.Invoke(sender, e);
        }
    }
}
