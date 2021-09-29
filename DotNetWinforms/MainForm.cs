using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetWinforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.LightGray;
            // this.BackColor=ColorTranslator.FromHtml("#FFFFFF"); 

            Button button = new Button();
            button.Location = new Point(this.Width / 2 - button.Width / 2,
                                    this.Height / 2 - button.Height / 2);
            button.Click += new EventHandler(this.buttonClick);
            button.Text = "Привет";
            button.MouseEnter += new EventHandler(this.buttonMouseEnter);
            button.MouseLeave += new EventHandler(this.buttonMouseLeave);

            this.Controls.Add(button);


            Button closed = new Button();
            closed.Location = new Point(this.Width - closed.Width, 0);
            closed.Click += new EventHandler(this.closedClick);
            closed.Height = closed.Width;
            closed.Text = "(Х)";
            closed.FlatAppearance.BorderSize = 0;
            closed.FlatStyle = FlatStyle.Flat;
            closed.Cursor = Cursors.Hand;

            this.Controls.Add(closed);

        }

        private void buttonClick(object sender, EventArgs e) {
            
            Form form = new Form();

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Width / 2 - form.Width / 2 + this.Location.X,
                                    this.Height / 2 - form.Height / 2 + this.Location.Y);
            form.Show();

        }

         private void closedClick(object sender, EventArgs e) {
            
           this.Close();

        }

        private void buttonMouseEnter(object sender, EventArgs e) =>
            Cursor.Hide();

        private void buttonMouseLeave(object sender, EventArgs e) =>
            Cursor.Show();

    }
}
