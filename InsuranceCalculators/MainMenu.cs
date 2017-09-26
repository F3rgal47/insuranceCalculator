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
    public partial class MainMenu : Form
    {
        public static int driverId,secondaryDriverID = 0, incidentsInLastYear, incidentsWithinTwoFiveYears;
        public static String startDate;
        String foreName, surName, dob, age, occupation = "";
        public static String wanted_path = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\DriverDatabase.mdf;Integrated Security=True;";
        String connectionAddress = wanted_path;
        SqlConnection conn = new SqlConnection(wanted_path);

        public MainMenu(int id)
        {
            driverId = id;
            InitializeComponent();

            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
            fillDates();

        }

//Methods used to populate Form//////////////////////////////////////////////////////////////////////////////////
        public void PopulateForm()
         {
             populateMainDriverDetails();
             dataGridView1.Rows.Clear();
             dataGridView2.Rows.Clear();
             populateDataGrid1();
             populateDataGrid2();
             populateSummary();
         } // populates form when form opens/ when form is updated

        public void fillDates()
        {
            var today = DateTime.Now;
            for (int i = 0; i <= 30; i++)
            {

                comboBox3.Items.Add(today.AddDays(i).ToString("dd/MM/yyyy"));
            }
        }// fills relevant comboboxes with dates, in this case the next 30 days for policy start

        public void populateSummary()
        {
            //StartDate//////////////////////////////////////////////////////////////////////////////////////////////////
            textBox13.Text = startDate;
            int totalDrivers = 1 + dataGridView2.Rows.Count;
            textBox8.Text = totalDrivers.ToString();

            int sumofClaims = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sumofClaims += Convert.ToInt32(dataGridView2.Rows[i].Cells[7].Value);
            }
            sumofClaims += dataGridView1.Rows.Count;
            textBox5.Text = sumofClaims.ToString();


            //Toatl CLAIMS/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int maxClaims = 0;
            String maxClaimName = "";
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                if (i == 0)
                {
                    maxClaims = int.Parse(dataGridView2.Rows[i].Cells[7].Value.ToString());
                    maxClaimName = dataGridView2.Rows[i].Cells[2].Value.ToString() + " " + dataGridView2.Rows[i].Cells[3].Value.ToString();
                }

                if (maxClaims < int.Parse(dataGridView2.Rows[i].Cells[7].Value.ToString()))
                {
                    maxClaims = int.Parse(dataGridView2.Rows[i].Cells[7].Value.ToString());
                    maxClaimName = dataGridView2.Rows[i].Cells[2].Value.ToString() + " " + dataGridView2.Rows[i].Cells[3].Value.ToString();
                }
            }
            if (maxClaims > dataGridView1.Rows.Count)
            {
                textBox12.Text = maxClaims.ToString();
                textBox11.Text = maxClaimName;
            }
            else
            {
                textBox12.Text = dataGridView1.Rows.Count.ToString();
                textBox11.Text = foreName + " " + surName;
            }

            //TOTAL CLAIMS WITHIN 2-5 YEARS/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int totalClaimWithinTwoFive = 0;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                totalClaimWithinTwoFive += Convert.ToInt32(r.Cells[8].Value);
            }

            foreach (DataGridViewRow t in dataGridView2.Rows)
            {

                totalClaimWithinTwoFive += Convert.ToInt32(t.Cells[8].Value);
            }

            textBox3.Text = totalClaimWithinTwoFive.ToString();


            //TOTAL CLAIMS IN PAST YEAR//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////            

            int totalClaimWithinPastYear = 0;

            foreach (DataGridViewRow y in dataGridView1.Rows)
            {

                totalClaimWithinPastYear += Convert.ToInt32(y.Cells[9].Value);
            }

            foreach (DataGridViewRow u in dataGridView2.Rows)
            {

                totalClaimWithinPastYear += Convert.ToInt32(u.Cells[9].Value);
            }

            textBox6.Text = totalClaimWithinPastYear.ToString();


            //YOUNGEST DRIVER////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int min = 0;
            String name = "";
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                if (i == 0)
                {
                    min = int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                    name = dataGridView2.Rows[i].Cells[2].Value.ToString() + " " + dataGridView2.Rows[i].Cells[3].Value.ToString();
                }

                if (min > int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()))
                {
                    min = int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                    name = dataGridView2.Rows[i].Cells[2].Value.ToString() + " " + dataGridView2.Rows[i].Cells[3].Value.ToString();
                }
            }
            if (min < Convert.ToInt32(age) && dataGridView2.Rows.Count != 0)
            {
                textBox2.Text = min.ToString();
                textBox1.Text = name;
            }
            else
            {
                textBox2.Text = age;
                textBox1.Text = foreName + " " + surName;
            }

            //OLDEST DRIVER//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int max = 0;
            String oldName = "";
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                if (i == 0)
                {
                    max = int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                    oldName = dataGridView2.Rows[i].Cells[2].Value.ToString() + " " + dataGridView2.Rows[i].Cells[3].Value.ToString();
                }

                if (max < int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()))
                {
                    max = int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                    oldName = dataGridView2.Rows[i].Cells[2].Value.ToString() + " " + dataGridView2.Rows[i].Cells[3].Value.ToString();
                }
            }
            if (max > Convert.ToInt32(age))
            {
                textBox4.Text = max.ToString();
                textBox7.Text = oldName;
            }
            else
            {
                textBox4.Text = age;
                textBox7.Text = foreName + " " + surName;
            }

            //CHAUFFEUR?/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Boolean chauffeur = false;

            if (occupation == "Chauffeur")
            {
                chauffeur = true;
            }
            foreach (DataGridViewRow y in dataGridView2.Rows)
            {
                string chubbadub = y.Cells[6].Value.ToString();
                if (y.Cells[6].Value.ToString() == "Chauffeur ")
                {
                    chauffeur = true;
                }
            }

            if (chauffeur == true)
            {
                textBox9.Text = "Y";
            }
            else
            {
                textBox9.Text = "N";
            }

            //ACCOUNTANT?///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Boolean accountant = false;

            if (occupation == "Accountant")
            {
                accountant = true;
            }
            foreach (DataGridViewRow y in dataGridView2.Rows)
            {

                if (y.Cells[6].Value.ToString() == "Accountant")
                {
                    accountant = true;
                }
            }

            if (accountant == true)
            {
                textBox10.Text = "Y";
            }
            else
            {
                textBox10.Text = "N";
            }

        } // reads the information of main and second drivers in the form and populates the summary panel

        public string workOutAgeAtPolicyStart(string x)
        {
            String dateOfBirth,day,month,year;
            if(x != "")
            {
                day = x.Substring(6, 2);
                month = x.Substring(4, 2);
                year = x.Substring(0, 4);
                dateOfBirth = day + "/" + month + "/" + year;
            }
            else 
            {
             dateOfBirth = dob;
            }
            DateTime bd = Convert.ToDateTime(dateOfBirth);
            DateTime pd = Convert.ToDateTime(startDate);
            //calculate year based on policy start date
            int getAge = pd.Year - bd.Year;
            if (pd.Month < bd.Month)
            {
                getAge--;
            }
            else if (pd.Month == bd.Month &&
              pd.Day > bd.Day)
            {
                getAge--;
            }

            return getAge.ToString();
        } // works out age of a driver at the start of policy date



          

//Button clicks and Event Handlers//////////////////////////////////////////////////////////////////////////////////

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                startDate = comboBox3.Text;
                panel7.Enabled = true;
                panel8.Enabled = true;
                panel9.Enabled = true;
                PopulateForm();
                
            }
            else 
            {
                MessageBox.Show("Please Select Policy Start Date!");
            }
        } // once user has selected ploicy start date the form populates with users info

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainDriverClaims mainClaimsForm = new MainDriverClaims(driverId, startDate);
            mainClaimsForm.ShowDialog();
            PopulateForm();
            this.Visible = true;
        } // opens the MainDriverClaims form

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                String getSecondaryId = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                secondaryDriverID = Int32.Parse(getSecondaryId);
                this.Visible = false;
                SecondaryDriverDetails secondaryDriverForm = new SecondaryDriverDetails(driverId, secondaryDriverID, startDate);
                secondaryDriverForm.ShowDialog();
                PopulateForm();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("No Drivers To Edit!");
            }

        } // opens the SecondarydriverDetails form, passing along the selected second driver id for editing

        private void button6_Click(object sender, EventArgs e)
        {
            secondaryDriverID = 0;
            this.Visible = false;
            SecondaryDriverDetails secondaryDriverForm = new SecondaryDriverDetails(driverId, secondaryDriverID, startDate);
            secondaryDriverForm.ShowDialog();
            PopulateForm();
            this.Visible = true;
        } // opens a blank SecondarydriverDetails form for adding new driver

        private void button8_Click(object sender, EventArgs e)
        {
            deleteSecondaryDrivers();
        } // Execute delete driver sql method for removing selected secondary drivers

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        } // returns to login form

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Registration registrationForm = new Registration(driverId);
            registrationForm.ShowDialog();
            PopulateForm();
            this.Visible = true;

        } // opens registration, and passes main driver id for editing

        private void button3_Click_1(object sender, EventArgs e)
        {
            Boolean vallidate = validation();

            if (vallidate == true)
            {
                int youngestAge = Int32.Parse(textBox2.Text);
                int claimsOneYear = Int32.Parse(textBox6.Text);
                int claimsTwoFive = Int32.Parse(textBox3.Text);
                QuoteResult quoteResultsForm = new QuoteResult(textBox9.Text, textBox10.Text, youngestAge, claimsOneYear, claimsTwoFive);
                quoteResultsForm.ShowDialog();
                PopulateForm();
            }
        } // opens QuoteResult form

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No Claim to Delete!");
            }
            else
            {
            deleteClaims();
            PopulateForm();
            }
        } // Deletes claims from main driver claims

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                deleteSecondaryDrivers();
                PopulateForm();
            }
            else 
            {
                MessageBox.Show("No Drivers to Delete!");
            }
        }


//Methods used to execute SQL Commands//////////////////////////////////////////////////////////////////////////////////

        public void populateMainDriverDetails()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();


            string commandString;
            commandString = "SELECT * FROM MainDriver WHERE DriverId = @DriverId";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@DriverId", driverId.ToString());
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
                //
                

                for (int r = 0; r <= row; r++)
                {
                    foreach (DataRow drCurrent in tblDriver.Rows)
                    {
                        foreName = drCurrent["Forename"].ToString();
                        surName = drCurrent["Surname"].ToString();
                        dob = drCurrent["DOB"].ToString();
                        age = workOutAgeAtPolicyStart("");
                        occupation = drCurrent["Occupation"].ToString();

                    }

                }
            }

            label9.Text = "Hello " + foreName + "!";
            label19.Visible = true;
        } //Loads MainDriver details when form opens
        
        public void populateDataGrid1()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();

            String commandString;
            String getClaimId;
            int claimId;
         
            commandString = "SELECT * FROM Claims WHERE DriverID = @DriverId AND ClaimRank = @ClaimRank";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@DriverId", driverId);
                cmd.Parameters.AddWithValue("@ClaimRank", "Main");

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

                if (row+1 > 0)
                {
                    dataGridView1.Visible = true;
                    label10.Visible = false;
                }

                for (int r = 0; r <= row; r++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[r].Cells[0].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[0];
                    dataGridView1.Rows[r].Cells[1].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[1];
                    dataGridView1.Rows[r].Cells[2].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[2];
                    dataGridView1.Rows[r].Cells[3].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[3];
                    dataGridView1.Rows[r].Cells[4].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[4];
                    dataGridView1.Rows[r].Cells[5].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[5];
                    dataGridView1.Rows[r].Cells[6].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[6];
                    dataGridView1.Rows[r].Cells[7].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[7];

                    getClaimId = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    claimId = Int32.Parse(getClaimId);
                    getClaims(claimId, "Main");
                    dataGridView1.Rows[r].Cells[8].Value = incidentsWithinTwoFiveYears;
                    dataGridView1.Rows[r].Cells[9].Value = incidentsInLastYear;
                    incidentsInLastYear = 0;
                    incidentsWithinTwoFiveYears = 0;
                    
                }
            }



        } //populates main drivers claims when form opens

        public void populateDataGrid2()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();

            String getSecondaryId;
            String commandString;

            commandString = "SELECT * FROM SecondaryDrivers WHERE MainDriverId = @MainDriverId";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@MainDriverId", driverId);

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

                if (row +1 > 0)
                {
                    dataGridView2.Visible = true;
                    label11.Visible = false;
                }

                for (int r = 0; r <= row; r++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[r].Cells[0].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[0];
                    dataGridView2.Rows[r].Cells[1].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[1];
                    dataGridView2.Rows[r].Cells[2].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[2];
                    dataGridView2.Rows[r].Cells[3].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[3];
                    dataGridView2.Rows[r].Cells[4].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[4];
                    dataGridView2.Rows[r].Cells[5].Value = workOutAgeAtPolicyStart(dataGridView2.Rows[r].Cells[4].Value.ToString());
                    dataGridView2.Rows[r].Cells[6].Value = dsDriverSearch.Tables["DriverDetails"].Rows[r].ItemArray[6];


                    getSecondaryId = dataGridView2.Rows[r].Cells[0].Value.ToString();
                    secondaryDriverID = Int32.Parse(getSecondaryId);
                    getClaims(secondaryDriverID, "Secondary");
                    dataGridView2.Rows[r].Cells[7].Value = incidentsInLastYear + incidentsWithinTwoFiveYears;
                    dataGridView2.Rows[r].Cells[8].Value = incidentsWithinTwoFiveYears;
                    dataGridView2.Rows[r].Cells[9].Value = incidentsInLastYear;
                    incidentsInLastYear = 0;
                    incidentsWithinTwoFiveYears = 0;
                }
            }

            
        } // populates second drivers when form opens

        public void getClaims(int x, string y)
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();

            String commandString = "";
            String getYearsString;
            int getYears;
            if (y == "Secondary")
            {
                commandString = "SELECT * FROM Claims WHERE SecondaryDriverId = @Id AND ClaimRank = @ClaimRank";
            }
            else if (y == "Main")
            {
                commandString = "SELECT * FROM Claims WHERE ClaimId = @Id AND ClaimRank = @ClaimRank";
            }


                using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@Id", x);
                cmd.Parameters.AddWithValue("@ClaimRank", y);

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


                    foreach (DataRow drCurrent in tblDriver.Rows)
                    {
                        getYearsString = drCurrent["YearsSinceClaim"].ToString();
                        getYears = Int32.Parse(getYearsString);

                        if (getYears == 1 || getYears == 0) 
                        {
                            incidentsInLastYear++;
                        }
                        else if (getYears > 1)
                        {
                            incidentsWithinTwoFiveYears++;
                        }
                    }              
            }
        } //this method gathers the claims of each secondary driver and adds them to the secondary driver grid

        public void deleteSecondaryDrivers()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                conn.ConnectionString = connectionAddress;
                conn.Open();

                String getSecondaryId = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                secondaryDriverID = Int32.Parse(getSecondaryId);

                string deleteClaimQuery = "DELETE FROM Claims WHERE SecondaryDriverId = @id";

                using (SqlCommand cmd = new SqlCommand(deleteClaimQuery, conn))
                {


                    cmd.Parameters.AddWithValue("@id", getSecondaryId);

                    cmd.ExecuteNonQuery();

                }


                string deleteSecondaryDriverQuery = "DELETE FROM SecondaryDrivers WHERE driverId = @id";

                using (SqlCommand cmd = new SqlCommand(deleteSecondaryDriverQuery, conn))
                {


                    cmd.Parameters.AddWithValue("@id", getSecondaryId);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Driver successfully deleted");
                    }
                    else
                    {
                        MessageBox.Show("Error deleting driver");
                    }
                }
                conn.Close();
                PopulateForm();
            }
        } // removes Second drivers from db

        public void deleteClaims()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                int selectedClaimId;
                conn.ConnectionString = connectionAddress;
                conn.Open();

                String getSelectedClaimId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                selectedClaimId = Int32.Parse(getSelectedClaimId);

                string deleteClaimQuery = "DELETE FROM Claims WHERE ClaimId = @id";

                using (SqlCommand cmd = new SqlCommand(deleteClaimQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@id", selectedClaimId);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            PopulateForm();
        } // removes main Driver claims from db

//Validation////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        public Boolean validation()
        {
            int yougestDriverAge = Int32.Parse(textBox2.Text);
            int oldestDriverAge = Int32.Parse(textBox4.Text);
            int numberOfClaimsByDriver = Int32.Parse(textBox12.Text);
            int totalClaims = Int32.Parse(textBox5.Text);

            if (yougestDriverAge < 21)
            {
                MessageBox.Show("Sorry but " + textBox1.Text +  "is only " + textBox2.Text + "! All Drivers must be 21 or over");
                return false;
            }

            if (yougestDriverAge > 75)
            {
                MessageBox.Show("Sorry but " + textBox7.Text + "is only " + textBox4.Text + "! All Drivers must be under 75");
                return false;
            }

            if (numberOfClaimsByDriver > 2)
            {
                MessageBox.Show("Sorry but " + textBox11.Text + " has " + textBox12.Text + " claims! Each driver may only have a maximum of two claims.");
                return false;
            }

            if (totalClaims > 3)
            {
                MessageBox.Show("Policy has more than 3 claims");
                return false;
            }

            return true;
        }



    }
}
