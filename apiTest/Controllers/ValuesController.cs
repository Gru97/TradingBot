using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Bussiness;


namespace apiTest.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Repository repo = new Repository();
        //@/home/lenovo/Documents/MyDotNetWorkPlace/apiTest/apiTest/
        // GET api/values
        [HttpGet]
        public ActionResult<bool> Get()
        {
            //"cd ~/Downloads/kelp && ./kelp
            string result = repo.RunCommand("cd ~/Documents/kelp/bin && ./kelp");
            if (result.Contains("  __ "))            
                return true;         
            else
                return false;  
            //return result;      
        }
              
        // POST api/values
        [HttpPost]
        [Route("CreateConfig")]
        public string CreateConfig([FromBody]Config config)
        {

            bool result = false;
            string res = "nothing. ";
            if(config!=null)
            {
                res += "config not null. " ;
                result= repo.CreateTraderConfig(config);
                if (result)
                {
                    res += "true";
                    result = repo.CreateStategyConfig(config);
                    res += result.ToString();
                }
            }
            return res;

        }

        [HttpGet]
        [Route("Trade")]
        public ActionResult<string> Trade()
        {

            string command = "cd ~/Documents/kelp/bin && ./kelp trade --botConf ./sample_trader.cfg --strategy buysell --stratConf ./sample_buysell.cfg";
            return repo.RunCommand(command).Substring(0,100);
        }



    }
}
