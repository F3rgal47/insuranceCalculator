/*
 * Created By Fergal O'Neill
 * Insurance Calculator
 * August 2017
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsuranceCalculators
{
    public partial class QuoteResult : Form
    {
        String chauffeur, accountant;
        double getClaimCost, getClaimCosttwo;
        public static int youngestAge,claimsOneYear, claimsTwoFive;


        public QuoteResult(String x, String y, int z, int i, int p)
        {
           chauffeur = x;
           accountant = y;
           youngestAge = z;
           claimsOneYear = i;
           claimsTwoFive = p;
           InitializeComponent();
           calculateQuote();
        }

//Calculate Quote////////////////////////////////////////////////////////////////////////////////////////

        public void calculateQuote()
        {
            double basePreium = 500, quotePremium = 500;
            double oneYearPrice = 0, twoFiveYearPrice = 0;

            if (chauffeur == "Y")
            {
                double getchuffCost = quotePremium * 0.1;
                getchuffCost = Math.Round(getchuffCost, 2);
                string chuafCost = getchuffCost.ToString();
                quotePremium += quotePremium * 0.1;
               
                label2.Text = "Chauffeur Present: ";
                label8.Text = "+£" + chuafCost;
            }
            else 
            {
                label2.Text = "No Chauffeur on Policy";
                label8.Visible = false;

            }

            if(accountant == "Y")
            {
                double getAccountantCost = quotePremium * 0.1;
                getAccountantCost = Math.Round(getAccountantCost, 2);
                string accountCost = getAccountantCost.ToString();
                quotePremium -= quotePremium * 0.1;              
                label3.Text = "Accountant Present: ";
                label9.Text = "-£" + accountCost;
            }
            else
            {
                label3.Text = "No Accountant on Policy";
                label9.Visible = false;
            }

            if(youngestAge >= 21 && youngestAge<=25)
            {
                double getAgeCost = quotePremium * 0.2;
                getAgeCost = Math.Round(getAgeCost, 2);
                string ageCost = getAgeCost.ToString();
                quotePremium += quotePremium * 0.2;
                label4.Text = "Youngest Driver is Between 21 -25: ";
                label10.Text = "+£" +ageCost;
            }

            if (youngestAge >= 26 && youngestAge <= 75)
            {
                double getAgeCost = quotePremium * 0.1;
                getAgeCost = Math.Round(getAgeCost, 2);
                string ageCost = getAgeCost.ToString();
                quotePremium -= quotePremium * 0.1;
               
                label4.Text = "Youngest Driver is Between 26-75:";
                label10.Text = "-£" + ageCost;
            }

          
            for(int i = 1; i <= claimsOneYear; i++)
            {
               getClaimCost += quotePremium * 0.2;
                quotePremium += quotePremium * 0.2;
             
            }
            //quotePremium += oneYearPrice;
            getClaimCost = Math.Round(getClaimCost, 2);
            string ageCLAIMCost = getClaimCost.ToString();
            label5.Text = "Claims within one year:";
            label11.Text = "+£" + ageCLAIMCost;

            for (int i = 1; i <= claimsTwoFive; i++)
            {
                getClaimCosttwo += quotePremium * 0.1;
                quotePremium += quotePremium * 0.1;
               
            }
            getClaimCosttwo = Math.Round(getClaimCosttwo, 2);
            string ageCLAIMCosttwo = getClaimCosttwo.ToString();
            quotePremium += twoFiveYearPrice;
            label6.Text = "Claims within two-five years: ";
            label13.Text = "+£" + ageCLAIMCosttwo;
            textBox3.Text = "£" + Math.Round(quotePremium, 2);
        }

    }
}
