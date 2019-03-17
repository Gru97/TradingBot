using System;
using System.Threading.Tasks;
using FrameWork;
namespace Bussiness
{
    public class Repository
    {

        //@/home/lenovo/Downlaods/kelp
        //@/home/lenovo/Documents/MyDotNetWorkPlace/apiTest/apiTest/
        //@/home/lenovo/Documents/kelp/bin
        readonly string CurrentDirectory = @"/home/lenovo/Documents/kelp/bin/";
     

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
            TraderString += string.Format("TICK_INTERVAL_SECONDS={0}\n", config.Tick_Interval_Second);
            TraderString += string.Format("MAX_TICK_DELAY_MILLIS={0}\n", config.Random_Delay);
            TraderString += string.Format("HORIZON_URL='{0}'", config.HORIZON_URL);
            //create trader.cfg
            //Write to file
            return Utility.WriteToFile("sample_trader.cfg", CurrentDirectory, TraderString);
        }
        public bool CreateStategyConfig(Config config)
        {
            //create sell.cfg
            //Write to file
            string SellString = "";
            SellString += string.Format("DATA_TYPE_A='{0}'\n", config.DATA_TYPE_A);
            SellString += string.Format("DATA_TYPE_B='{0}'\n", config.DATA_TYPE_B);

            SellString += string.Format("DATA_FEED_A_URL='{0}'\n", config.Data_Feed_A_URL);
            SellString += string.Format("DATA_FEED_B_URL='{0}'\n", config.Data_Feed_B_URL);
            SellString += string.Format("AMOUNT_TOLERANCE={0}\n", config.Amount_Tolerance);
            SellString += string.Format("PRICE_TOLERANCE={0}\n", config.Price_Tolerance);
            SellString += string.Format("AMOUNT_OF_A_BASE={0}\n", config.AMOUNT_OF_A_BASE);

            foreach(var level in config.Levels)
            {
                SellString += "# " +level.Number +" level\n";
                SellString += "[[LEVELS]]\n";
                SellString += string.Format("SPREAD={0}\n", level.Spread);
                SellString += string.Format("AMOUNT={0}\n", level.Amount);

            }
            return Utility.WriteToFile("sample_buysell.cfg", CurrentDirectory, SellString);
        }
        public  string RunCommand(string command)
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
            int id= proc.Id;
            return result;
        }
    }
}
