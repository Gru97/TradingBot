$(document).ready(function() {
        $('#Create_Files').click(function(error, result) {
            alert();
            var config = {
                Trading_Secret: $('#Trading_Secret').val(),
                Source_Secret: $('#Source_Secret').val(),
                Asset_Code_A: $('#Asset_Code_A').val(),
                Issuer_A: $('#Issuer_A').val(),
                Asset_Code_B: $('#Asset_Code_B').val(),
                Issuer_B: $('#Issuer_B').val(),
                Tick_Interval_Second: $('#Tick_Interval_Second').val(),
                Random_Delay: $('#Random_Delay').val(),
                Data_Feed_A_URL: $('#Data_Feed_A_URL').val(),
                Data_Feed_B_URL: $('#Data_Feed_B_URL').val(),
                Price_Tolerance: $('#Price_Tolerance').val(),
                Amount_Tolerance: $('#Amount_Tolerance').val(),
                
                
                
                
            };
           
            $.ajax({
                type:"POST",
                url:"https://localhost:5001/api/values/CreateConfig",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data:JSON.stringify(config)           
           
            }).done(function(data){
                console.log(data);
                }).fail(function(data){alert("fail"); console.log(data);});
              

            

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
        
        
        $("#Start_Trading").click(function(){
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