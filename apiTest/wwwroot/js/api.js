$(document).ready(function() {
            var counter=1;
            var lstLevels=[];
            /*
            $("#Horizen_Url").change(function(){
                var selectedUrl = $(this).children("option:selected").val();
                alert("You have selected the Url - " + selectedUrl);
            });
            */
            $("#btnAddLevel").click(function(){
                
                counter++;
                var html=' <div> <div class="column"> <input class="input100" type="number" id="Spread'+counter+'" name="Spread" placeholder="Spread"> <span class="focus-input100"></span> </div>'+
                '<div class="column"> <input class="input100" type="number" id="Amount'+counter+'" name="Amount" placeholder="Amount"> <span class="focus-input100"></span></div> </div>';
                $(".level").append(html);
                
            
            });
        $('#btnTest').click(function(){
            alert("btnTest");
            debugger;
            for(var i=1;i<=counter;i++)
            {
                var id1="#Spread"+i;
                var id2="#Amount"+i;
                var level={number:i,spread:$(id1).val(), amount:$(id2).val()}
                debugger;
                lstLevels.push(level);
             
            }
        });   
        $('#btnCreateFile').click(function(error, result) {
            
            for(var i=1;i<=counter;i++)
            {
                var id1="#Spread"+i;
                var id2="#Amount"+i;
                let level={number:i,spread:$(id1).val(), amount:$(id2).val()}
                lstLevels.push(level);
                debugger;
               
            }
            //var level1={number:1,spread:$("#Spread1").val(), amount:$("#Amount1").val()}
            //var level2={number:2,spread:0.002, amount:2}
            //var lstLevels=[level1];
            alert("btnCreateFile");
            var config = {
                //Trading_Secret: $('#Trading_Secret').val(),
                Trading_Secret: "SBCYQ43L3MBH6Z3W3VNUCJG2KKKQIQIEPE52XX6O4X4P2OZX5S6XPVOS",
                //Source_Secret: $('#Source_Secret').val(),
                Source_Secret: "SBCYQ43L3MBH6Z3W3VNUCJG2KKKQIQIEPE52XX6O4X4P2OZX5S6XPVOS",
                //Asset_Code_A: $('#Asset_Code_A').val(),
                Asset_Code_A:"KELP",

                //Issuer_A: $('#Issuer_A').val(),
                Issuer_A:"GCU4L3C4P4VAD6ML6N4SXPKOXFHJUVYTE5EOQWTZMPRUXUGD72K5TYGY",
               
                //Asset_Code_B: $('#Asset_Code_B').val(),
                Asset_Code_B: "PMN",
                //Issuer_B: $('#Issuer_B').val(),
                Issuer_B: "",
                //Tick_Interval_Second: $('#Tick_Interval_Second').val(),
                Tick_Interval_Second: "20",
                //Random_Delay: $('#Random_Delay').val(),
                Random_Delay: "20",
                
                //Data_Feed_A_URL: $('#Data_Feed_A_URL').val(),    
                Data_Feed_A_URL: "2.5",
                
                //DATA_TYPE_B:$('#Data_Type_A').val(),
                DATA_TYPE_A:"fixed",
                
                //Data_Feed_B_URL: $('#Data_Feed_B_URL').val(),
                Data_Feed_B_URL:"1.5",
                
                //DATA_TYPE_B:$('#Data_Type_B').val(),
                DATA_TYPE_B:"fixed",
                 
                //Price_Tolerance: $('#Price_Tolerance').val(),
                Price_Tolerance: "0.001",
               //Amount_Tolerance: $('#Amount_Tolerance').val(),
                Amount_Tolerance: "0.001",
                
                
                //AMOUNT_OF_A_BASE=$('#"Amount_Of_A_Base').val(),
                AMOUNT_OF_A_BASE:"1.0",
                
                //HORIZON_URL:selectedUrl,
                HORIZON_URL:"https://horizon.kuknos.org:8000",
                
                Levels:lstLevels,
                
                
            };
            console.log(config);
            debugger;
           console.log(lstLevels);
            $.ajax({
                type:"POST",
                url:"https://localhost:5001/api/values/CreateConfig",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data:JSON.stringify(config)           
           
            }).done(function(data){
                console.log(data);
                }).fail(function(data){alert("fail"); console.log(data.responseText);});
              

            

        })
        $("#Run_Kelp").click(function(){
            alert("Run_Kelp");
            $.ajax({
                type:"Get",
                url:"https://localhost:5001/api/values",
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                 
            }).done(function(data){
            console.log(data);
                if(data==true) 
                    alert("kelp started successfully");
                else
                    alert("kelp failed to start ");    
                })
              .fail(function(data){alert("fail");console.log(data.responseText);});
        });
        
        
        $("#btnStartTrading").click(function(){
            alert("Start_Trading");
            $.ajax({
                type:"Get",
                url:"https://localhost:5001/api/values/Trade",
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                 
            }).done(function(data){
                if(data==true) 
                    alert("Trade started successfully");
                else
                    alert("Trade failed to start ");    
                })
              .fail(function(data){alert("fail");console.log(data.responseText);});
        });
    }

)