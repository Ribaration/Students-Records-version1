using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;//helps to load files

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public object OpenFileDialog1 { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentsRecordsDataSet.StudentsData' table. You can move, or remove it, as needed.
            this.studentsDataTableAdapter.Fill(this.studentsRecordsDataSet.StudentsData);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentsDataBindingSource.AddNew();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentsDataBindingSource.EndEdit();
            studentsDataTableAdapter.Update(studentsRecordsDataSet.StudentsData);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studentsDataBindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentsDataTableAdapter.Search(studentsRecordsDataSet.StudentsData, textBox1.Text);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            studentsDataBindingSource.MoveFirst();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            studentsDataBindingSource.MovePrevious();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            studentsDataBindingSource.MoveNext();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            studentsDataBindingSource.MoveLast();
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsDataTableAdapter.Search(this.studentsRecordsDataSet.StudentsData, param1ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox5.Text))
            {
                pictureBox1.Image = Image.FromFile(textBox5.Text);
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                pictureBox1.Image = null; // Clear any existing image
                pictureBox1.Text = "Picture not available";
                //pictureBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                pictureBox1.Show();
            }



        }


        private void button11_Click(object sender, EventArgs e)
        {

        }

        /*private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Please upload your profile picture";
            opf.Filter = "Image File (*.jpg; *.jpeg;*.gif;*.bmp) |*.jpg; *.jpeg;*.gif;*.bmp";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(opf.FileName);
                pictureBox1.Image = image;
                pictureBox1.Image.Dispose();

            }
        }*/
        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Please upload your profile picture";
            opf.Filter = "Image File (*.jpg; *.jpeg;*.gif;*.bmp) |*.jpg; *.jpeg;*.gif;*.bmp";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(opf.FileName);
                pictureBox1.Image = image;

                // Save the inserted picture into a byte array
                byte[] imageData = ConvertImageToByteArray(image);

                // You can now use the 'imageData' byte array as needed (e.g., save to a database)
            }
            // Assuming dataGridView1 is your DataGridView
            if (dataGridView1.Rows.Count == 0)
            {
                // If DataGridView is empty, prompt the user to enter a picture path in TextBox5
                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    // Display the picture from the entered path in the PictureBox
                    pictureBox1.ImageLocation = textBox5.Text;
                    pictureBox1.Show();

                }
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            pictureBox1.Show();

        }

        private void searchToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an image file";
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg; *.gif; *.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into PictureBox
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
