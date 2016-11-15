using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Logan Sirdevan
//COP 2020 Project 3
//Create a random number generator and store data in an array. 
//Nov 9, 2016

namespace Project3LSirdevan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int intLower, intUpper, intGenerate, intCount;
        int[] intArray;
        Random randomNum = new Random();

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ValidateNumbers();
            intArray = new int[intUpper];

            while(intCount<intGenerate)
            {
                int generatedNums = randomNum.Next(intLower,intUpper);
                intArray[generatedNums]++;
                intCount++;
            }//end while

            int intArrayCounter=intLower;
            foreach (int item in intArray)
            {
                lstOutput.Items.Add("The number " + intArrayCounter + " was generated " + item + " times");
                intArrayCounter++;
            }//end foreach

        }//end method

        private void ValidateNumbers()
        {
            try
            {
                intGenerate = int.Parse(txtGenerate.Text);
            }
            catch
            {
                MessageBox.Show("Enter a valid number for the Generate Number feild");
            }//end trycatch

            try
            {
                intUpper = int.Parse(txtUpper.Text);
            }
            catch
            {
                MessageBox.Show("Enter a valid number for the Upper Bound");
            }//end trycatch

            try
            {
                intLower = int.Parse(txtLower.Text);
            }
            catch
            {
                MessageBox.Show("Enter a valid number for the Lower Bound");
            }//end trycatch

            if (intUpper < intLower)
            {
                MessageBox.Show("Upper bound must be greater than or equal to Lower Bound");
            }

            if(intGenerate<1)
            {
                MessageBox.Show("The Generate Number feild must be greater than or equal to 1");
            }
        }//end method

        private void btnReset_Click(object sender, EventArgs e)
        {
            intGenerate = 0;
            txtGenerate.Clear();
            txtGenerate.Focus();
            lstOutput.Items.Clear();
        }//end method

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end method
    }


}
