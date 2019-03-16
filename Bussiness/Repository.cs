using System;
using System.Threading.Tasks;
using FrameWork;
namespace Bussiness
{
    public class Repository
    {

        //@/home/lenovo/Downlaods/kelp
        readonly string CurrentDirectory = @"/home/lenovo/Documents/MyDotNetWorkPlace/apiTest/apiTest/";
     

        public bool CreateTraderConfig(Config config)
        {
            string TraderString = "";
            //trader
            TraderString += string.Format("TRADING_SECRET_SEED='{0}'\n", config.Trading_Secret);
            TraderString += string.Format("SOURCE_SECRET_SEED='{0}'\n", config.Source_Secret);
            TraderString += string.Format("ASSET_CODE_A='{0}'\n", config.Asset_Code_A);
            TraderString += string.Format("ISSUER_A='{0}'\n", config.Issuer_A);
            TraderString += string.Format("ASSET_CODE_B='{0}'\n", config.Asset_Code_B);
            TraderString += string.Format("ISSUER_B='{0}'\n", config.Issuer_B);
            TraderString += string.Format("TICK_INTERVAL_SECONDS='{0}'\n", config.Tick_Interval_Second);
            TraderString += string.Format("MAX_TICK_DELAY_MILLIS='{0}'\n", config.Random_Delay);

            //create trader.cfg
            //Write to file
            return Utility.WriteToFile("Trader.cfg", CurrentDirectory, TraderString);
        }
        public bool CreateStategyConfig(Config config)
        {
            //create sell.cfg
            //Write to file
            string SellString = "";
            SellString += string.Format("DATA_FEED_A_URL='{0}'\n", config.Data_Feed_A_URL);
            SellString += string.Format("DATA_FEED_B_URL='{0}'\n", config.Data_Feed_B_URL);
            SellString += string.Format("AMOUNT_TOLERANCE='{0}'\n", config.Amount_Tolerance);
            SellString += string.Format("PRICE_TOLERANCE='{0}'\n", config.Price_Tolerance);

            return Utility.WriteToFile("Sell.cfg", CurrentDirectory, SellString);
        }
        public string RunCommand(string command)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            string result = "";

            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + command + " \"";

            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();

            result += proc.StandardOutput.ReadToEnd();
            result += proc.StandardError.ReadToEnd();

            proc.WaitForExit();

            return result;
        }
    }
}
