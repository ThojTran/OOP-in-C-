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
        public partial class NotifyForm : Form
        {
            public NotifyForm(string message)
            {
                InitializeComponent();
                lbNotify.Text = message; 
                btnOK.Click += new EventHandler(btnOK_Click);
            }

            // Đóng thông báo khi nhấn nút OK
            private void btnOK_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        private void lbNotify_Click(object sender, EventArgs e)
        {

        }
    }
}
