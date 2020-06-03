using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dacanvas
{
    public partial class Form1 : Form
    {

        string currentDir = "";

        public Form1()
        {
            InitializeComponent();
            
        }
       
        









        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pictureBox1.Image = null;
            pictureBox1.Update();
            textBox1.Clear();
            try
            {
                var fb = new FolderBrowserDialog();
                if (fb.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {
                    currentDir = fb.SelectedPath;
                    textBox1.Text = currentDir;
                    var dirInfo = new DirectoryInfo(currentDir);
                    var files = dirInfo.GetFiles().Where(c => (c.Extension.Equals(".jpg") || c.Extension.Equals(".jpeg") || c.Extension.Equals(".png") || c.Extension.Equals(".bmp") || c.Extension.Equals(".gif") || c.Extension.Equals("")));
                    foreach (var image in files)
                    {
                        listBox1.Items.Add(image.Name);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error:" + ex.Message + "" + ex.Source);

              
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedImage = listBox1.SelectedItems[0].ToString();
                if (!string.IsNullOrEmpty(selectedImage) && !string.IsNullOrEmpty(currentDir))
                {
                    var fullPath = Path.Combine(currentDir, selectedImage);
                    pictureBox1.Image = Image.FromFile(fullPath);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}


