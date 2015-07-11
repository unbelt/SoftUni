namespace DistanceCalculatorWebClinet
{
    using System;
    using System.Net;
    using System.Web.UI;

    public partial class Index : Page
    {
        private const string URL = "http://localhost:10114/"; // Change to your port

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Calculate_Click(Object sender, EventArgs e)
        {
            Result.Visible = true;
            Result.Text = "Calculating...";

            using (var client = new WebClient())
            {
                var response = client.UploadString(
                    URL + string.Format("CalculateDistance?aX={0}&aY={1}&bX={2}&bY={3}",
                    AX.Value, AY.Value, BX.Value, BY.Value), "POST", "");
                
                Result.Text = response;
            }
        }
    }
}