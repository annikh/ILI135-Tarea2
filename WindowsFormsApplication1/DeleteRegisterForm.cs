using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// The controller of the DeleteRegister-Form
    /// </summary>
    public partial class DeleteRegisterForm : Form
    {
        public DeleteRegisterForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Validates the input data and sets the primary key of the register to delete to null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int line = -1;
            String key = textBox1.Text;
            int keyValue;
            int pos = 0;
            if (!Int32.TryParse(key, out keyValue))
            {
                MessageBox.Show("The key must be a numeric value between 0 and 100. Please insert value again.");
            }
            else
            {
                List<String> fileContent = File.ReadAllLines("Datos.txt").ToList(); //Makes a list with the whole file content
                for (int i = 0; i < fileContent.Count; i++)
                {
                    pos = fileContent[i].IndexOf(",");
                    if (fileContent[i].Substring(0,pos).Equals(key))
                    {
                        line = i;
                        break;
                    }
                }
                if (line == -1)
                {
                    MessageBox.Show("The register does not exist in the file. Are you sure this was the right value?");
                }
                else
                {
                    String reg = fileContent[line];
                    reg = null + reg.Substring(pos);
                    fileContent[line] = reg;
                    File.WriteAllLines("Datos.txt", fileContent);
                    MessageBox.Show("The register was successfully deleted");
                    this.Hide();
                }
            }

        }
        
    }
}
