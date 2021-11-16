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
    public partial class FormPopup : Form
    {
        #region Setting background click

        //폼에 속한 컨트롤 클릭시 배경 이동으로 포함
        public delegate void GlobalMouseClickEventHander(object sender, MouseEventArgs e);

        private void BindControlMouseClicks(Control con)
        {
            if (con != this)
            {
                con.MouseDown += delegate (object sender, MouseEventArgs e)
                {
                    TriggerMouseDowned(sender, e);
                };
                con.MouseMove += delegate (object sender, MouseEventArgs e)
                {
                    TriggerMouseMoved(sender, e);
                };
            }
            foreach (Control i in con.Controls)
            {
                //배경에 속하지 않는 컨트롤
                if ((i != textBox1) && (i != button1))
                {
                    BindControlMouseClicks(i);
                }
            }
            con.ControlAdded += delegate (object sender, ControlEventArgs e)
            {
                BindControlMouseClicks(e.Control);
            };
        }

        private void TriggerMouseDowned(object sender, MouseEventArgs e)
        {
            FormPopup_MouseDown(sender, e);
        }

        private void TriggerMouseMoved(object sender, MouseEventArgs e)
        {
            FormPopup_MouseMove(sender, e);
        }

        //폼 배경클릭 이동
        private Point mousePoint;

        //폼 클릭
        private void FormPopup_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void FormPopup_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        #endregion Setting background click

        private new readonly Form1 Parent;
        public FormPopup(Form1 parent)
        {
            Parent = parent;
            InitializeComponent();

            //setting background click
            BindControlMouseClicks(this);
        }

        //Send Data to Parent
        private void Button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            if (data.Length > 0)
            {
                Parent.SetText(data);
            }
        }

        //Close
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
