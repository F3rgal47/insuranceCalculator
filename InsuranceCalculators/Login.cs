/*
 * Created By Fergal O'Neill
 * Insurance Calculator
 * August 2017
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsuranceCalculators
{
    public partial class Login : Form
    {
        public static int driverId;

        public static String wanted_path = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\DriverDatabase.mdf;Integrated Security=True;";
        String connectionAddress = wanted_path;
        SqlConnection conn = new SqlConnection(wanted_path);
        //String connectionAddress = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\FERGAL O NEILL\\Documents\\Applied\\InsuranceCalculators\\InsuranceCalculators\\DriverDatabase.mdf;Integrated Security=True";
        //SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\FERGAL O NEILL\\Documents\\Applied\\InsuranceCalculators\\InsuranceCalculators\\DriverDatabase.mdf;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Registration registrationForm = new Registration(0);
            registrationForm.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            conn.ConnectionString = connectionAddress;
            conn.Open();
       
            String commandString;
            String password = "";
            String driverIdString = "";
            commandString = "SELECT DriverID, Password FROM MainDriver WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", textBox6.Text);
                // Execute the insert statement and store the result.
                cmd.ExecuteNonQuery();
                conn.Close();
           

            SqlDataAdapter daDriver = new SqlDataAdapter(cmd);
            DataSet dsDriverSearch = new DataSet("driverSearch");
            daDriver.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daDriver.Fill(dsDriverSearch, "DriverDetails");

            DataTable tblDriver;
            tblDriver = dsDriverSearch.Tables["DriverDetails"];

            int row = dsDriverSearch.Tables["DriverDetails"].Rows.Count - 1;
            // Set employeeId so that employee maintenance can grab it to search using the selected Id.
          

                 for (int r = 0; r <= row; r++)
                 {
                     driverIdString = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[0].ToString();
                     password = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[1].ToString();
                 }
            }

            driverId = Int32.Parse(driverIdString);
         
            if (textBox1.Text != password)
            {
                label1.Visible = true;
            }
            else
            {
            // Launch MainMenu. 
            this.Visible = false;
            MainMenu mainmenuForm = new MainMenu(driverId);
            mainmenuForm.ShowDialog();
            textBox1.Text = "";
            textBox6.Text = "";
            this.Visible = true;
            }
        }
    }
}
