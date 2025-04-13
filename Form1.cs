namespace WinFormsApp1;
using System;
using System.Windows.Forms;
using System.Data;
partial class MyForm : Form
{
    public TextBox tb;

    public MyForm()
    {
        var pos = new Point(10, 200);

        Button Zero = new Button();
        Zero.Text = "0";
        Zero.Location = pos; // Позиция на форме
        Zero.Size = new Size(40, 40); // Размеры

        // Добавляем обработчик нажатия
        Zero.Click += new EventHandler(NumberButtonCLicked);
        pos.Y -= 50;
        Controls.Add(Zero);
        int c = 1;
        for (int i = 1; i < 4; i++)
        {
            pos.X = 10;
       
            for (int j = 0; j < 3; j++)
            {
                Button myButton = new Button();
                myButton.Text = (c++).ToString();
                myButton.Location = pos; // Позиция на форме
                myButton.Size = new Size(40, 40); // Размеры

                // Добавляем обработчик нажатия
                myButton.Click += new EventHandler(NumberButtonCLicked);
                pos.X += 50;
                Controls.Add(myButton);
                
            }
            pos.Y -= 50;
        }

        pos.Y = 200;

        foreach(var i in "+-*/")
        {
            Button myButton = new Button();
            myButton.Text = i.ToString();
            myButton.Location = pos; // Позиция на форме
            myButton.Size = new Size(40, 40); // Размеры

            // Добавляем обработчик нажатия
            myButton.Click += new EventHandler(NumberButtonCLicked);
            pos.Y -= 50;
            Controls.Add(myButton);
        }
        Button EqualButton = new Button();
        EqualButton.Text = "=";
        EqualButton.Location = pos; // Позиция на форме
        EqualButton.Size = new Size(40, 40); // Размеры

        // Добавляем обработчик нажатия
        EqualButton.Click += new EventHandler(EqualButtonCLicked);
        pos.Y -= 50;
        Controls.Add(EqualButton);

        pos.X = 10;
        pos.Y = 20;

        tb = new TextBox();

        tb.Location = pos;
        tb.Size = new Size(200, 50);

        Controls.Add(tb);
    }

    private void NumberButtonCLicked(object sender, EventArgs e)
    {
        tb.Text += (sender as Button).Text;
    }

    private void EqualButtonCLicked(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        tb.Text = dt.Compute(tb.Text, "").ToString();
    }
}
