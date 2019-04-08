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
            /*
            string result = repo.RunCommand("cd ~/Documents/kelp/bin && ./kelp");
            if (result.Contains("  __ "))            
                return true;         
            else
                return false;  
            //return result;
            */
            return null;
        }
              
        // POST api/values
        [HttpPost]
        [Route("CreateConfig")]
        public OperationResult CreateConfig([FromBody]Config config)
        {
            OperationResult op = new OperationResult();
          
            if (config != null)
            {
                if (repo.CreateTraderConfig(config))
                {
                    op.Message += "Trader config file created successfully.";
                    if (repo.CreateStategyConfig(config))
                    {
                        op.Message += "Strategy config file created successfully.";
                        op.Success = true;
                    }
                    else
                    {
                        op.Message += "Strategy config file failed to create.";
                        op.Success = false;
                    }                           
                }
                else
                {
                    op.Message += "Trader confiig file failed to create.";
                    op.Success = false;
                }
            }
            else
            { 
                op.Message = "Config properties are empty.";
                op.Success = false;
            }
            return op;

        }

        [HttpGet]
        [Route("Trade")]
        public ActionResult<OperationResult> Trade()
        {
         
            string command = "cd ~/Documents/kelp/bin && ./kelp trade --botConf ./sample_trader.cfg --strategy buysell --stratConf ./sample_buysell.cfg";
            return repo.RunCommand(command);
        }

        [HttpGet]
        [Route("StopBot")]
        public ActionResult<OperationResult> StopTrading()
        {

            return repo.StopBot();
        }

    }
}
