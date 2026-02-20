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


            // create top button
            Button top = new Button();
            // closed.Height = closed.Width;
            top.Height = 50;
            top.Width = this.Width;
            // top.Location = new Point(this.Width - top.Width, 0);
            // top.Click += new EventHandler(this.topClick);
            top.Text = "";
            top.FlatAppearance.BorderSize = 1;
            top.FlatStyle = FlatStyle.Flat;
            // top.Cursor = Cursors.Hand;
            // top.Focus = None;

            this.Controls.Add(top);


            // create main button
            Button button = new Button();
            button.Location = new Point(this.Width / 2 - button.Width / 2,
                                    this.Height / 2 - button.Height / 2);
            button.Click += new EventHandler(this.buttonClick);
            button.Text = "Привет";
            button.Cursor = Cursors.Hand;

            this.Controls.Add(button);

            // create close button
            Button closed = new Button();
            // closed.Height = closed.Width;
            closed.Height = 50;
            closed.Width = 50;
            closed.Location = new Point(this.Width - closed.Width, 0);
            closed.Click += new EventHandler(this.closedClick);
            closed.Text = "Х";
            closed.FlatAppearance.BorderSize = 0;
            closed.FlatStyle = FlatStyle.Flat;
            closed.Cursor = Cursors.Hand;

            top.Controls.Add(closed);

            // create text box
            TextBox text = new TextBox();
            text.Text = "";
            text.Multiline = true;
            text.Height = 50;
            text.Width = 50;
            text.MouseEnter += new EventHandler(this.textMouseEnter);
            text.MouseLeave += new EventHandler(this.textMouseLeave);

            top.Controls.Add(text);

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

        private void textMouseEnter(object sender, EventArgs e) =>
            Cursor.Hide();

        private void textMouseLeave(object sender, EventArgs e) =>
            Cursor.Show();

    }
}
