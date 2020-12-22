using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Life
{
    public partial class Form1 : Form
    {
        public int size = 4;
        string PreviousText;
        public Form1()
        {
            PreviousText = Convert.ToString(size);
            InitializeComponent();
            GenerateLayout();
        }

        public void GenerateLayout()
        {
            for (int i = 0; i < (size * size); i++)
            {
                CreateButton(400 / size, i, new Point((400 / size) * (i % size), (400 / size) * (int)Math.Floor((double)i / (double)size)), "GridButton" + i);
            }
        }

        public void CreateButton(int size, int tag, Point location, string name)
        {
            Button button = new Button()
            {
                Width = size,
                Height = size,
                Tag = tag,
                Location = location,
                Name = name,
                BackColor = Color.White
            };
            button.Click += GridButton_Click;
            ButtonPanel.Controls.Add(button);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool[,] CurrentCells = new bool[size,size];
            bool[,] NextCells = new bool[size, size];
            foreach(Button button in ButtonPanel.Controls)
            {
                CurrentCells[(int)button.Tag % size, (int)Math.Floor((int)button.Tag / (double)size)] = button.BackColor == Color.Black;
            }

            for(int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    int nearcells = 0;
                    if(CheckCell(CurrentCells, x - 1, y - 1))
                        nearcells++;
                    if (CheckCell(CurrentCells, x, y - 1))
                        nearcells++;
                    if (CheckCell(CurrentCells, x + 1, y - 1))
                        nearcells++;
                    if (CheckCell(CurrentCells, x - 1, y))
                        nearcells++;
                    if (CheckCell(CurrentCells, x + 1, y))
                        nearcells++;
                    if (CheckCell(CurrentCells, x - 1, y + 1))
                        nearcells++;
                    if (CheckCell(CurrentCells, x, y + 1))
                        nearcells++;
                    if (CheckCell(CurrentCells, x + 1, y + 1))
                        nearcells++;

                    if(CurrentCells[x, y])
                    {
                        if (nearcells == 2 || nearcells == 3)
                        {
                            NextCells[x, y] = true;
                        }
                        else
                        {
                            NextCells[x, y] = false;
                        }
                    }
                    else
                    {
                        if(nearcells == 3)
                        {
                            NextCells[x, y] = true;
                        }
                        else
                        {
                            NextCells[x, y] = false;
                        }
                    }

                }
            }


            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    int i = y * size + x;

                    ButtonPanel.Controls[i].BackColor = NextCells[x, y] ? Color.Black : Color.White;
                }
            }
        }

        public bool CheckCell(bool [,] CurrentCells, int x, int y)
        {
            try
            {
                return CurrentCells[x, y];
            }
            catch
            {
                return false;
            }
            
        }

        public void GridButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.BackColor == Color.Black)
            {
                button.BackColor = Color.White;
            }
            else
            {
                button.BackColor = Color.Black;
            }

        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;
            if(int.TryParse(NumberTextBox.Text, out value))
            {
                if(value > 0 && value < 26)
                {
                    PreviousText = NumberTextBox.Text;
                    size = value;
                    ButtonPanel.Controls.Clear();
                    GenerateLayout();
                }
                else
                {
                    NumberTextBox.Text = PreviousText;
                }
            }
            else
            {
                if(NumberTextBox.Text != "")
                {
                    NumberTextBox.Text = PreviousText;
                }
                else
                {
                    PreviousText = NumberTextBox.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Button button in ButtonPanel.Controls)
            {
                button.BackColor = Color.White;
            }
        }
    }
}
