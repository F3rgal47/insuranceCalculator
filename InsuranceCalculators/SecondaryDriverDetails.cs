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
       
    public partial class SecondaryDriverDetails : Form
    {
        public static int MaindriverId, SecondDriverId;
        public static String policyStartDate, claimId;
        public Boolean editing = false;
        public static String wanted_path = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\DriverDatabase.mdf;Integrated Security=True;";
        String connectionAddress = wanted_path;
        SqlConnection conn = new SqlConnection(wanted_path);
        public SecondaryDriverDetails(int id, int secondId, string startDate)
        {
            policyStartDate = startDate;
            MaindriverId = id;
            SecondDriverId = secondId;
            InitializeComponent();
            fillDates();

            if (secondId != 0)
            {
            populateDetails();
            dataGridView1.Rows.Clear();
            populateDataGrid();
            }

            panel8.AutoScroll = false;
            panel8.HorizontalScroll.Enabled = false;
            panel8.HorizontalScroll.Visible = false;
            panel8.HorizontalScroll.Maximum = 0;
            panel8.AutoScroll = true;
                   
        }

        //Methods used to populate Form//////////////////////////////////////////////////////////////////////////

        public void fillDates()
        {
            int year = DateTime.Now.Year;
            for (int i = year; i >= year - 117; i--)
            {

                comboBox4.Items.Add(i.ToString());
            }
            for (int i = year; i >= year - 5; i--)
            {
                comboBox6.Items.Add(i.ToString());

            }

        }

        //Button clicks and Event Handlers///////////////////////////////////////////////////////////////////////

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dateOfBirth = comboBox4.Text.ToString() + "/" + comboBox3.Text.ToString() + "/" + comboBox2.Text.ToString();
            DateTime bd = Convert.ToDateTime(dateOfBirth);
            DateTime pd = Convert.ToDateTime(policyStartDate);
            //calculate year based on policy start date
            int age = pd.Year - bd.Year;
            if (pd.Month < bd.Month)
            {
                age--;
            }
            else if (pd.Month == bd.Month &&
              pd.Day > bd.Day)
            {
                age--;
            }

            textBox5.Text = age.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Boolean validate = claimValidation();

            if (validate == true)
            {
            AddClaimToDB();
            populateDataGrid();

            cleanUp();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                removeClaimFromDb();
                dataGridView1.Rows.Clear();
                populateDataGrid();
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
            comboBox7.Enabled = true;
            comboBox8.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
            comboBox8.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Boolean validate = driverValidation();

            if (validate == true)
            {
                addDriverToDb();
            }          
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dateOfClaim = comboBox6.Text.ToString() + comboBox7.Text.ToString();
            DateTime dt = Convert.ToDateTime(policyStartDate);
            //calculate year based on claimdate fields
            int year = (Int32.Parse(dt.ToString("yyyyMM")) -
            Int32.Parse(dateOfClaim)) / 100;

            textBox3.Text = year.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string doc, month, year;
            editing = true;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                claimId = row.Cells[0].Value.ToString();
                comboBox5.Text = row.Cells[4].Value.ToString();

                doc = row.Cells[5].Value.ToString(); ;
                month = doc.Substring(0, 2);
                year = doc.Substring(3, 4);


                comboBox7.Text = month;
                comboBox6.Text = year;

                comboBox8.Text = row.Cells[6].Value.ToString();
                checkBox2.Checked = false;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
                button2.Enabled = true;
                dataGridView1.Enabled = true;
            }


        }


        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                comboBox4.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                comboBox3.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Methods used to execute SQL Commands///////////////////////////////////////////////////////////////////
        public void populateDataGrid()
        {
            dataGridView1.Rows.Clear();
            conn.ConnectionString = connectionAddress;
            conn.Open();

            String commandString;

            commandString = "SELECT * FROM Claims WHERE DriverID = @DriverId AND SecondaryDriverId = @SecondaryDriverId";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@DriverId", MaindriverId);
                cmd.Parameters.AddWithValue("@SecondaryDriverId", SecondDriverId);
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
                }
            }



        }

        public void populateDetails()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();


            string commandString;
            string dob, day, month, year;
            commandString = "SELECT * FROM SecondaryDrivers WHERE DriverId = @DriverId";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@DriverId", SecondDriverId.ToString());
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
                    foreach (DataRow drCurrent in tblDriver.Rows)
                    {
                        textBox1.Text = drCurrent["Forename"].ToString();
                        textBox2.Text = drCurrent["Surname"].ToString();
                        dob = drCurrent["DOB"].ToString();
                        day = dob.Substring(6, 2);
                        month = dob.Substring(4, 2);
                        year = dob.Substring(0, 4);

                        comboBox2.Text = day;
                        comboBox3.Text = month;
                        comboBox4.Text = year;

                        textBox5.Text = drCurrent["Age"].ToString();
                        comboBox1.Text = drCurrent["Occupation"].ToString();

                    }

                }
                panel12.Enabled = true;
            }
        }

        public void AddClaimToDB()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();
            string query;


            if (editing == true)
            {
                query = "UPDATE Claims SET DriverId = @DriverId, SecondaryDriverId=@SecondaryDriverId, ClaimRank=@ClaimRank, TypeOfIncident=@TypeOfIncident, Date=@Date, DamageSuffered=@DamageSuffered,YearsSinceClaim=@YearsSince WHERE ClaimId =" + claimId;
                // , Photo=@photo
                // BiometricMarker=@bioMarker,
            }
            else
            {
                query = "INSERT INTO Claims(DriverId, SecondaryDriverId, ClaimRank, TypeOfIncident, Date, DamageSuffered,YearsSinceClaim) VALUES(@DriverId,@SecondaryDriverId, @ClaimRank, @TypeOfIncident, @Date, @DamageSuffered,@YearsSince)";
                // , @photo , Photo
                // BiometricMarker, @bioMarker,
            }

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                String dateOfClaim = comboBox7.Text.ToString() + "/" + comboBox6.Text.ToString();
                cmd.Parameters.AddWithValue("@DriverId", MaindriverId);
                cmd.Parameters.AddWithValue("@SecondaryDriverId", SecondDriverId);
                cmd.Parameters.AddWithValue("@ClaimRank", "Secondary");
                cmd.Parameters.AddWithValue("@TypeOfIncident", comboBox5.Text);
                cmd.Parameters.AddWithValue("@Date", dateOfClaim);
                cmd.Parameters.AddWithValue("@DamageSuffered", comboBox8.Text);
                cmd.Parameters.AddWithValue("@YearsSince", textBox3.Text);

                // int Biomarker = Int32.Parse(textBox11.Text);

                // Execute the insert statement and store the result.
                cmd.ExecuteNonQuery();
                conn.Close();
                editing = false;
                claimId = "";
            }
        }

        public void removeClaimFromDb()
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

        }

        public void addDriverToDb()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();
            string query;
            if (SecondDriverId != 0)
            {
                query = "UPDATE SecondaryDrivers SET MainDriverId = @MainDriverId, Forename=@Forename, Surname=@Surname, DOB=@DOB, Age=@Age, Occupation=@Occupation WHERE DriverId =" + SecondDriverId.ToString();
                // , Photo=@photo
                // BiometricMarker=@bioMarker,
            }
            else
            {

                query = "INSERT INTO SecondaryDrivers(MainDriverId, Forename, Surname, DOB, Age, Occupation)output INSERTED.DriverId VALUES(@MainDriverId, @Forename, @Surname, @DOB,@Age,@Occupation)";
            }

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                String dateOfBirth = comboBox4.Text.ToString() + comboBox3.Text.ToString() + comboBox2.Text.ToString();
                cmd.Parameters.AddWithValue("@MainDriverId", MaindriverId);
                cmd.Parameters.AddWithValue("@Forename", textBox1.Text);
                cmd.Parameters.AddWithValue("@Surname", textBox2.Text);
                cmd.Parameters.AddWithValue("@DOB", dateOfBirth);
                cmd.Parameters.AddWithValue("@Age", textBox5.Text);
                cmd.Parameters.AddWithValue("@Occupation", comboBox1.Text);

                // Execute the insert statement and store the result, return Id for claims.
                if (SecondDriverId == 0)
                {
                    int returnNewId = (int)cmd.ExecuteScalar();
                    SecondDriverId = returnNewId;
                    MessageBox.Show("Successfully Added! You may now add this drivers Claims!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated!");
                }

                panel12.Enabled = true;
                conn.Close();

            }
        }

        //Validate and Cleanup//////////////////////////////////////////////////////////////////////////////////

        public void claimCleanup()
        {

        }

        public void cleanUp()
        {
            checkBox1.Checked = false;
            comboBox5.Enabled = false;
            comboBox5.Text = "";
            comboBox6.Enabled = false;
            comboBox6.Text = "";
            comboBox7.Enabled = false;
            comboBox7.Text = "";
            comboBox8.Enabled = false;
            comboBox8.Text = "";
            button2.Enabled = false;
            textBox3.Text = "";

        }

        public Boolean claimValidation()
        {

            if (comboBox5.Text == "")
            {
                MessageBox.Show("Please Select Type of Incident");
                return false;
            }

            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please Select Month of Incident");
                return false;
            }

            if (comboBox6.Text == "")
            {
                MessageBox.Show("Please Select Year of Incident");
                return false;
            }

            if (comboBox8.Text == "")
            {
                MessageBox.Show("Please Select Damage Suffered");
                return false;
            }

            return true;
        }

        public Boolean driverValidation()
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Forename!");
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
