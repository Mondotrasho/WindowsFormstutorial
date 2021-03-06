﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormstutorial
{

    public partial class Form1 : Form
    {
        public Creator store;
        public Form1()
        {
            store = new Creator();
            store.Box = new List<int[]>();
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs me = e as MouseEventArgs;
                
                if (string.IsNullOrWhiteSpace(textOutput.Text)) // for first case
                {
                    textOutput.Text += me.Location.ToString();
                    store.Add(me.Location.X, me.Location.Y);
                    store.DrawPoint(this.pictureBox1);
                    return;
                }
                textOutput.Text += System.Environment.NewLine  +  me.Location.ToString();
                store.Add(me.Location.X, me.Location.Y);
                store.DrawPoint(this.pictureBox1);
            }

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                   // myStream = saveFileDialog1.OpenFile();
                    var writer = new StreamWriter(myStream);
                    {
                        writer.WriteLine(textOutput.Text);
                    }
                    writer.Close();
                    myStream.Dispose();
                    myStream.Close();
                }
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textOutput.Text = "";
            store.Box.Clear();
            store.DrawPoint(this.pictureBox1);

        }
    }
}
