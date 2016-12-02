using System;
using System.IO;
using System.Collections.Generic;
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
    /// The controller of the AddRegister-Form
    /// </summary>
    public partial class AddRegisterForm : Form
    {

        public AddRegisterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Writes a register to file, at the right place according to the primary key
        /// </summary>
        /// <param name="reg"></param>
        public void writeRegisterToFile(Register reg)
        {
            String filename = "Datos.txt";
            if (File.Exists(filename) && (new FileInfo(filename).Length > 0))
            {
                List<String> fileContent = File.ReadAllLines(filename).ToList(); //Makes a list with the whole file content
                int line = fileContent.Count;
                for (int i = 0; i < line; i++) 
                {
                    int pos = fileContent[i].IndexOf(",");
                    if (pos == 0)
                    {
                        continue;
                    }
                    else if (Int32.Parse(fileContent[i].Substring(0,pos)) > reg.getCampo1())
                    {
                        line = i;
                        break;
                    }
                }
                fileContent.Insert(line, reg.ToString());
                File.WriteAllLines(filename, fileContent.ToArray());
            }
            else
            {
                using (TextWriter file = new StreamWriter(filename, true))
                {
                    file.WriteLine(reg);
                }
            }
            
        }
        


        /// <summary>
        /// Validates the input values from the user, and makes a register with the fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Register register;
            string[] fields = new string[]{textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text};
            
            int[] intFields = new int[6];
            bool correctValues = true;
            // TODO: Check if primary key is unique
            // TODO: Check that no more han 100 elements are contained in the file
            for (int i = 0; i < 6; i++)
            {
                if (!Int32.TryParse(fields[i], out intFields[i]))
                {
                    MessageBox.Show("Campo" + (i+1).ToString() + " must have a value that is numeric. Please enter the value again.");
                    correctValues = false;
                    break;
                }
                else if (!(intFields[i] <= 100 && intFields[i] >= 0))
                {
                    MessageBox.Show("Campo" + (i+1).ToString() + " must be a number between 0 and 100. Please enter the value again.");
                    correctValues = false;
                    break;
                }
            }
            if (correctValues)
            {
                MessageBox.Show("The register was added successfully");
                register = new Register(intFields[0], intFields[1], intFields[2], intFields[3], intFields[4], intFields[5]);
                writeRegisterToFile(register);
                this.Hide();
            }
            
        }
    }
}
