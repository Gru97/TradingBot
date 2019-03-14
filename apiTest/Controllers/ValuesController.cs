using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace apiTest.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Models.Person p = new Models.Person();
        // GET api/values
        [HttpGet]
        public ActionResult<Models.Person> Get()
        {
            //Read from a file
            string path = @"/home/lenovo/Documents/MyDotNetWorkPlace/apiTest/apiTest/MyTest.txt";
            if (System.IO.File.Exists(path))
            { string r = System.IO.File.ReadAllText(path);
                p.Name = r + "new read";
            }

            //p.Name = "Ali";
            p.ID = 1;
            string s=Trade();
            return p;
            //return new string[] { "value1", "value2" ,s};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string name)
        {

            //Write to file
            string path = @"/home/lenovo/Documents/MyDotNetWorkPlace/apiTest/apiTest/MyTest.txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.File.Create(path)))
            {
                file.WriteLine(name);
            }

            //p.Name = "zara";
            p.Name = name;

            return p.Name;

        }


        private string Trade()
        {
            string command = "dotnet --version";
            string result = "";
            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.Start();

                result += proc.StandardOutput.ReadToEnd();
                result += proc.StandardError.ReadToEnd();

                proc.WaitForExit();
            }
            return result;
        }

    }
}
