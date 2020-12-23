﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Life
{
    public partial class Form1 : Form
    {
        public int size = 4;
        private string PreviousText;

        public Form1()
        {
            PreviousText = Convert.ToString(size);
            InitializeComponent();
            GenerateLayout();
#if DEBUG
            File.Delete("debug.log");
            File.AppendAllText("debug.log", $"Avvio l'app");
#endif
        }

        public void GenerateLayout()
        {
#if DEBUG
            File.AppendAllText("debug.log", $"\nRicreo i pulsanti con dimensione griglia {size}");
#endif
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
#if DEBUG
            File.AppendAllText("debug.log", "\nCreo nuova generazione...");
#endif
            bool[,] CurrentCells = new bool[size, size];
            bool[,] NextCells = new bool[size, size];
            foreach (Button button in ButtonPanel.Controls)
            {
                CurrentCells[(int)button.Tag % size, (int)Math.Floor((int)button.Tag / (double)size)] = button.BackColor == Color.Black;
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    int cella = x * size + y;
#if DEBUG
                    File.AppendAllText("debug.log", $"\n[Controllo cella {cella}] ");
#endif
                    int nearcells = 0;
                    if (CheckCell(CurrentCells, x - 1, y - 1, cella))
                        nearcells++;
                    if (CheckCell(CurrentCells, x, y - 1, cella))
                        nearcells++;
                    if (CheckCell(CurrentCells, x + 1, y - 1, cella))
                        nearcells++;
                    if (CheckCell(CurrentCells, x - 1, y, cella))
                        nearcells++;
                    if (CheckCell(CurrentCells, x + 1, y, cella))
                        nearcells++;
                    if (CheckCell(CurrentCells, x - 1, y + 1, cella))
                        nearcells++;
                    if (CheckCell(CurrentCells, x, y + 1, cella))
                        nearcells++;
                    if (CheckCell(CurrentCells, x + 1, y + 1, cella))
                        nearcells++;
#if DEBUG
                    File.AppendAllText("debug.log", $"\n");
#endif
                    if (CurrentCells[x, y])
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
                        if (nearcells == 3)
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

        public bool CheckCell(bool[,] CurrentCells, int x, int y, int cell)
        {
            if (x == -1)
            {
                x = size - 1;
            }
            else if (x == size)
            {
                x = 0;
            }
            if (y == -1)
            {
                y = size - 1;
            }
            else if (y == size)
            {
                y = 0;
            }

            File.AppendAllText("debug.log", $" {CurrentCells[x, y]}");
            return CurrentCells[x, y];
        }

        public void GridButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor == Color.Black)
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
            if (int.TryParse(NumberTextBox.Text, out value))
            {
                if (value > 0 && value < 26)
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
                if (NumberTextBox.Text != "")
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
            foreach (Button button in ButtonPanel.Controls)
            {
                button.BackColor = Color.White;
            }
        }

        private string PreviousTime = "3";

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Disattivata")
            {
                button3.Text = "Attivata";
            }
            else
            {
                button3.Text = "Disattivata";
            }

            bool isEnabled = button3.Text == "Attivata";

            if (isEnabled)
            {
                timer1.Enabled = true;
                timer1.Start();
                timer1.Tick += (s, args) => { button1_Click(e, args); };
                button1.Enabled = false;
                NumberTextBox.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                timer1.Stop();
                button1.Enabled = true;
                NumberTextBox.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBox1.Text, out value))
            {
                PreviousTime = textBox1.Text;
                timer1.Interval = value;
            }
            else
            {
                if (textBox1.Text != "")
                {
                    textBox1.Text = PreviousTime;
                }
                else
                {
                    PreviousTime = textBox1.Text;
                }
            }
        }
    }
}