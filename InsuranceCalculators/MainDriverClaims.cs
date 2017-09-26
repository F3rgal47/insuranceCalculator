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
    public partial class MainDriverClaims : Form
    {
        public static int MaindriverId;
        public static String policyStartDate, claimId;
        public Boolean editing = false;
        public static String wanted_path = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\DriverDatabase.mdf;Integrated Security=True;";
        String connectionAddress = wanted_path;
        SqlConnection conn = new SqlConnection(wanted_path);
        public MainDriverClaims(int id, String startDate)
        {
            policyStartDate = startDate;
            MaindriverId = id;
            InitializeComponent();
            fillDates();
            dataGridView1.Rows.Clear();
            populateDataGrid();

            panel12.AutoScroll = false;
            panel12.HorizontalScroll.Enabled = false;
            panel12.HorizontalScroll.Visible = false;
            panel12.HorizontalScroll.Maximum = 0;
            panel12.AutoScroll = true;
                   
        }

//Methods used to populate Form///////////////////////////////////////////////////////////////////////////
        public void fillDates()
        {
            int year = DateTime.Now.Year;
            for (int i = year; i >= year - 5; i--)
            {
                comboBox6.Items.Add(i.ToString());

            }

        }

//Button clicks and Event Handlers////////////////////////////////////////////////////////////////////////
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
            comboBox7.Enabled = true;
            comboBox8.Enabled = true;
            button2.Enabled = true;
            dataGridView1.Enabled = true;
        } // enables the textboxes/comboboxes in the form for editing

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
            comboBox8.Enabled = false;
            button2.Enabled = false;
        } // disables the textboxes/comboboxes 

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String dateOfClaim = comboBox6.Text.ToString() + comboBox7.Text.ToString();
            DateTime dt = Convert.ToDateTime(policyStartDate);
            //calculate year based on claimdate fields
            int year = (Int32.Parse(dt.ToString("yyyyMM")) -
            Int32.Parse(dateOfClaim)) / 100;

            textBox2.Text = year.ToString();
        }// calculates age once d.o.b is selected

        private void button2_Click(object sender, EventArgs e)
        {

            Boolean validate = validation();

            if (validate == true)
            {
            AddClaimToDB();
            populateDataGrid();
            cleanUp();
            }
        }// launches addClaimToDb method and repopulates with new data

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

        }// grabs the details of current selected claim in the grid and populates form for editing

        private void button1_Click(object sender, EventArgs e) // close Form
        {
            this.Close();
        }

//Methods used to execute SQL Commands///////////////////////////////////////////////////////////////////

        public void AddClaimToDB()
        {
            conn.ConnectionString = connectionAddress;
            conn.Open();
            string query = "";


            if (editing == true)
            {
                query = "UPDATE Claims SET DriverId = @DriverId, ClaimRank=@ClaimRank, TypeOfIncident=@TypeOfIncident, Date=@Date, DamageSuffered=@DamageSuffered,YearsSinceClaim=@YearsSince WHERE ClaimId =" + claimId;
                // , Photo=@photo
                // BiometricMarker=@bioMarker,
            }
            else if (editing == false)
            {
                query = "INSERT INTO Claims(DriverId, ClaimRank, TypeOfIncident, Date, DamageSuffered,YearsSinceClaim) VALUES(@DriverId, @ClaimRank, @TypeOfIncident, @Date, @DamageSuffered,@YearsSince)";
                // , @photo , Photo
                // BiometricMarker, @bioMarker,
            }
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                String dateOfClaim = comboBox7.Text.ToString() + "/" + comboBox6.Text.ToString();
                cmd.Parameters.AddWithValue("@DriverId", MaindriverId);
                cmd.Parameters.AddWithValue("@ClaimRank", "Main");
                cmd.Parameters.AddWithValue("@TypeOfIncident", comboBox5.Text);
                cmd.Parameters.AddWithValue("@Date", dateOfClaim);
                cmd.Parameters.AddWithValue("@DamageSuffered", comboBox8.Text);
                cmd.Parameters.AddWithValue("@YearsSince", textBox2.Text);

                // int Biomarker = Int32.Parse(textBox11.Text);

                // Execute the insert statement and store the result.
                cmd.ExecuteNonQuery();
                conn.Close();
                editing = false;
                claimId = "";
               
            }
        } // adds claim to database

        public void populateDataGrid()
        {
            dataGridView1.Rows.Clear();
            conn.ConnectionString = connectionAddress;
            conn.Open();
       
            String commandString;
          
            commandString = "SELECT * FROM Claims WHERE DriverID = @DriverId AND ClaimRank = @ClaimRank";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                cmd.Parameters.AddWithValue("@DriverId", MaindriverId);
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

    
            
            } // populates form if user has attempted to edit a claim from Main Menu

//Validate and Cleanup//////////////////////////////////////////////////////////////////////////////////

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
            textBox2.Text = "";
            button2.Enabled = false;

        }

        public Boolean validation()
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

        
      }         

    }

