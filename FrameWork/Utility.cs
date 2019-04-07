using System;
namespace FrameWork
{
    public static class Utility
    {
        public static bool WriteToFile(string FileName,string Path, string Content)
        {
            bool result = true;
            if (!System.IO.File.Exists(Path))
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.File.Create(Path + FileName)))
                    {
                        file.WriteLine(Content);
                        result = true;
                    }
                }
                catch (Exception)
                {
                    result = false;
                }

            }
            //else
                //System.IO.File.AppendAllText(Path + FileName, Content);
            return result;
        }
        public static string ReadFromFile(string FileName ,string Path)
        {
            string Content = "";
            if (System.IO.File.Exists(Path))
            {
                try
                {
                    Content = System.IO.File.ReadAllText(Path+FileName);
                }
                catch (Exception)
                {
                    //
                }
               
            }
            return Content;
        }
    }

}
