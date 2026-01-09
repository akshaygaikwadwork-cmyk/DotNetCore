using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OTP_Generate_SMS
{
    public partial class Two_Step_Verification : System.Web.UI.Page
    {
        static int sentOtp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenOTP_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            string apikey = "your api key";
            long numbers = Convert.ToInt64(txtPhoneNumber.Text);
            sentOtp = rand.Next(1000, 9999);
            string senders = "TXTLCL";
            if (numbers > 0)
            {
                String url = "https://api.textlocal.in/send/?apikey=" + apikey + "&numbers=" + numbers + "&message=" + sentOtp + "&sender=" + senders;

                StreamWriter mywriter = null;
                HttpWebRequest objrequest = (HttpWebRequest)WebRequest.Create(url);

                objrequest.Method = "POST";
                objrequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                objrequest.ContentType = "application/x-www-form-urlencoded";

                try
                {
                    mywriter = new StreamWriter(objrequest.GetRequestStream());
                    mywriter.Write(url);

                    lblMsg.Text = "OTP Sent Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }

                catch (Exception)
                {
                    lblMsg.Text = "OTP could not sent";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

                finally
                {
                    mywriter.Close();
                }
            }
            else
            {
                lblMsg.Text = "This Phone Number is not valid";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}