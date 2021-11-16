using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleNoTitlePopup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //팝업 위치 설정 : 중앙
        private Point GetPopupLocation(FormPopup form)
        {
            const int AxisYCorrection = 30;
            int X = this.Location.X + (this.Width / 2 - form.Width / 2);
            int Y = this.Location.Y + (this.Height / 2 - form.Height / 2);
            return new Point(X, Y + AxisYCorrection);
        }

        //팝업 위치 설정 : 패널 끝
        private Point GetPopupLocationUtil(FormPopup form)
        {
            const int AxisYCorrection = 30;
            int X = this.Location.X + this.Location.X + this.Location.X;
            int Y = this.Location.Y + (this.Height / 2 - form.Height / 2);
            return new Point(X, Y + AxisYCorrection);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormPopup popup = new (this);
            popup.Owner = this;
            popup.Location = GetPopupLocation(popup);
            popup.ShowDialog();
        }

        public void SetText(string data)
        {
            textBox1.Text = data;
        }
    }
}
