
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
    public partial class Registration : Form
    {
        public static int driverId;
        public static String wanted_path = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\DriverDatabase.mdf;Integrated Security=True;";
        String connectionAddress = wanted_path;
        SqlConnection conn = new SqlConnection(wanted_path);
        /// Load components, populate form if needed///////////////////////////////////////////////////////////

        public Registration(int i)
        {
            InitializeComponent();
            driverId = i;
            if (driverId != 0)
            {
                populateDetails();
            }
            fillDates();
        }

        public void fillDates()
        {
            int year = DateTime.Now.Year;
            for (int i = year; i >= year - 117; i--)
            {

                comboBox4.Items.Add(i.ToString());
            }
        } // fills dates of d.o.b combo box

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        public void Login()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();


            string commandString;
            commandString = "SELECT DriverID FROM MainDriver WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", textBox3.Text);
                // Execute the insert statement and store the result.
                cmd.ExecuteNonQuery();
                conn.Close();


                SqlDataAdapter daDriver = new SqlDataAdapter(cmd);
                DataSet dsDriverSearch = new DataSet("employeeSearch");
                daDriver.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                daDriver.Fill(dsDriverSearch, "EmployeeDetails");

                DataTable tblDriver;
                tblDriver = dsDriverSearch.Tables["EmployeeDetails"];

                int row = dsDriverSearch.Tables["EmployeeDetails"].Rows.Count - 1;
                // Set employeeId so that employee maintenance can grab it to search using the selected Id.


                for (int r = 0; r <= row; r++)
                {
                    // driverId = dsDriverSearch.Tables["EmployeeDetails"].Rows[r].ItemArray[0].ToString(); 
                }
            }

            conn.Close();
            this.Visible = false;
            // Launch MainMenu. 
            MainMenu mainmenuForm = new MainMenu(driverId);
            mainmenuForm.ShowDialog();

        }  //Once form has been filled in/Updated. Exit form by logging user in and opening Main Menu.

        //Button calls & events/////////////////////////////////////////////////////////////////////////////////////////

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } // closes registration Form

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            String dateOfBirth = comboBox4.Text.ToString() + comboBox3.Text.ToString() + comboBox2.Text.ToString();
            int age = (Int32.Parse(DateTime.Today.ToString("yyyyMMdd")) -
           Int32.Parse(dateOfBirth)) / 10000;

            textBox5.Text = age.ToString();
        } // calculates age when d.o.b is selected

        private void button1_Click_1(object sender, EventArgs e)
        {
            Boolean validate = validation();

            if (validate == true)
            {
                save();
            }
        } // saves the details of new/current driver

        //Methods used to execute Sql Executions//////////////////////////////////////////////////////////////////////////////

        public void populateDetails()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();

            string commandString;
            string dob, day, month, year;
            commandString = "SELECT * FROM MainDriver WHERE DriverId = @DriverId";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@DriverId", driverId);
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

                String password;
                for (int r = 0; r <= row; r++)
                {
                    foreach (DataRow drCurrent in tblDriver.Rows)
                    {

                        textBox1.Text = drCurrent["Forename"].ToString();
                        textBox2.Text = drCurrent["Surname"].ToString();
                        dob = drCurrent["DOB"].ToString();
                        day = dob.Substring(0, 2);
                        month = dob.Substring(3, 2);
                        year = dob.Substring(6, 4);
                        comboBox2.Text = day;
                        comboBox3.Text = month;
                        comboBox4.Text = year;
                        textBox5.Text = drCurrent["Age"].ToString();
                        comboBox1.Text = drCurrent["Occupation"].ToString();
                        textBox3.Text = drCurrent["Username"].ToString();
                        textBox3.Enabled = false;
                        password = drCurrent["Password"].ToString();
                        textBox4.Text = password;
                        textBox6.Text = password;

                    }

                }
            }
        } //if the form has been opened from main menu, populate form with current driver details

        public void save()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();
            string query;
            if (driverId != 0)
            {
                query = "UPDATE MainDriver SET Password =@Password, Forename=@Forename, Surname=@Surname, DOB=@DOB, Age=@Age, Occupation=@Occupation WHERE DriverId =" + driverId.ToString();
                // , Photo=@photo
                // BiometricMarker=@bioMarker,
            }
            else
            {
                query = "INSERT INTO MainDriver(Forename, Surname, DOB, Age, Occupation, Username, Password) VALUES(@Forename, @Surname, @DOB,@Age,@Occupation,@Username, @Password)";
            }

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                String dateOfBirth = comboBox4.Text.ToString() + comboBox3.Text.ToString() + comboBox2.Text.ToString();
                cmd.Parameters.AddWithValue("@Forename", textBox1.Text);
                cmd.Parameters.AddWithValue("@Surname", textBox2.Text);
                cmd.Parameters.AddWithValue("@DOB", dateOfBirth);
                cmd.Parameters.AddWithValue("@Age", textBox5.Text);
                cmd.Parameters.AddWithValue("@Occupation", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Username", textBox3.Text);
                cmd.Parameters.AddWithValue("@Password", textBox4.Text);


                // int Biomarker = Int32.Parse(textBox11.Text);

                // Execute the insert statement and store the result.
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success! You will now be taken to the Main Menu");
                conn.Close();
                Login();
            }
        } // save to database

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                comboBox3.Enabled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox3.Text != "")
            {
                comboBox4.Enabled = true;
            }

        }

        //Validation//////////////////////////////////////////////////////////////////////////////

        public Boolean validation()
        {
            int age = Int32.Parse(textBox5.Text);
            if (age < 21)
            {
                MessageBox.Show("Sorry but you must be 21 or over!");
                return false;
            }

            if (textBox4.Text != textBox6.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return false;
            }

            if (driverId == 0)
            {
            conn.ConnectionString = connectionAddress;
            conn.Open();

            string commandString;
            commandString = "SELECT Username FROM MainDriver WHERE DriverId = @DriverId";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@DriverId", driverId);
                // Execute the insert statement and store the result.
                cmd.ExecuteNonQuery();
                conn.Close();

                SqlDataAdapter daDriver = new SqlDataAdapter(cmd);
                DataSet dsDriverSearch = new DataSet("driverSearch");
                daDriver.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                daDriver.Fill(dsDriverSearch, "DriverDetails");

                DataTable tblDriver;
                tblDriver = dsDriverSearch.Tables["DriverDetails"];

                int row = dsDriverSearch.Tables["DriverDetails"].Rows.Count;

                if (row >= 1)
                {
                    MessageBox.Show("Sorry but that username is taken!");
                    return false;
                }
            }
            }

            if(textBox3.Text == "")
            {
                MessageBox.Show("Please enter Username!");
                return false;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter password!");
                return false;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("Please confirm password!");
                return false;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Forname!");
                return false;
            }


            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter Surname!");
                return false;
            }

            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please select day of birth!");
                return false;
            }

            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please select month of birth!");
                return false;
            }

            if (comboBox4.Text == "")
            {
                MessageBox.Show("Please select year of birth!");
                return false;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select Occupation!");
                return false;
            }

            return true;
        }

      
    }
}