﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FrameWork;
namespace Bussiness
{
    public class Repository
    {
             
        readonly string CurrentDirectory = @"/home/lenovo/Documents/kelp/bin/";

        public static int ProcessID;
        public EventHandler<string> Updated;
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
            OperationResult op = new OperationResult();
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
        public OperationResult RunCommand(string command)
        {
            OperationResult op = new OperationResult();

            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                string result = "";

                proc.StartInfo.FileName = "/bin/bash";

                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                //proc.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                //proc.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);

                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.Start();
                op.Message = "Process started. ";
                ProcessID = proc.Id;
                /*
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();

                    Utility.WriteToFile("output", CurrentDirectory,line);
                }
                */
                result += proc.StandardOutput.ReadToEnd();
                result += proc.StandardError.ReadToEnd();
                //proc.BeginErrorReadLine();
                //proc.BeginOutputReadLine();
                proc.WaitForExit();
                op.Success = true;
                op.Message+= result;
            }
            catch (Exception ex)
            {
                op.Message = "Starting process failed. " + ex.Message;
            }
           
            return op;
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            //Utility.WriteToFile("output", CurrentDirectory, e.Data);
        }

        public OperationResult StopBot()
        {
            OperationResult op = new OperationResult();
            try
            {
                string ProcessName = System.Diagnostics.Process.GetProcessById(ProcessID).ProcessName;

                if (ProcessName == "kelp")
                {
                    try
                    {
                        System.Diagnostics.Process.GetProcessById(ProcessID).Kill();
                        op.Success = true;
                        op.Message = "Kelp Process Stopped Successfully";
                    }
                    catch (Exception ex)
                    {
                        op.Message = "Kelp Process Failed To Stop. " + ex.Message;
                    }
                }
                else
                {
                    op.Message = "No such process is running.";
                    op.Success = false;
                }
            }
            catch (Exception ex)
            {
                op.Message += ex.Message;
                op.Success = false;
            }

            return op;

        }



    }
}
