$(document).ready(function() 
{
    var counter=1;
    var lstLevels=[];
    var selected_Data_Type_A;
    var selected_Data_Type_B;
    $("#Horizen_Url").change(function()
    {
        
        var selectedUrl = $(this).children("option:selected").val();
        //alert("You have selected the Url - " + selectedUrl);
    });
   
    $("#Data_Type_A").change(function(){
        selected_Data_Type_A = $(this).children("option:selected").val();
        //alert("You have selected the Data_Type_A - " + selected_Data_Type_A);
    });
    
    $("#Data_Type_B").change(function(){
        selected_Data_Type_B = $(this).children("option:selected").val();
        //alert("You have selected the Data_Type_A - " + selected_Data_Type_B);
    });
    
    
    $("#btnAddLevel").click(function(){
        debugger;
        counter++;
        var html=' <div> <div class="column"> <input class="input100" type="number" id="Spread'+counter+'" name="Spread" placeholder="Spread"> <span class="focus-input100"></span> </div>'+
        '<div class="column"> <input class="input100" type="number" step="0.1" min="0" max="1.00" id="Amount'+counter+'" name="Amount" placeholder="Amount"> <span class="focus-input100"></span></div> </div>';
        $(".level").append(html);
        
    
    });
    
    $('#btnShowOffers').click(function()
    {
        //alert("Show offers");
        $('#offerstable').empty();
        //var publicKey="GBRPDD7WJNXZKX6VHUSX3BIXXS65MCDZZ2ERMA5GQDUEDPE2RRGTGU4K";
        var publicKey=$("#Public_Key").val();
        if(publicKey==null)
            alert("Enter your public key");
        
        $.ajax({
        type:"Get",
        url:"https://horizon.kuknos.org:8000/accounts/"+publicKey+"/offers?limit=10&order=asc",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
         

        }).done(function(data) {   
        var offers=data["_embedded"]["records"];
        var Asset_Code_A="PMN";
        //var Asset_Code_A=$('#Asset_Code_A').val();
        var Asset_Code_B="KELP";
        //var Asset_Code_B=$('#Asset_Code_B').val();
        
        var tableHeader="<tr><td>"+Asset_Code_A+"</td><td>"+Asset_Code_B+"</td><td>Price</td></tr>";
        $('#offerstable').append(tableHeader);

        offers.forEach(element => {
            console.log(element);
            //console.log(element["amount"]);
            console.log(element["selling"]["asset_type"]);
            //console.log(element["buying"]["asset_type"]);
            //console.log(element["buying"]["asset_code"]);
            //console.log(element["buying"]["asset_issuer"]);
    
    
            //td1
            var buying_asset_code=element["buying"]["asset_code"];
    
            var selling_asset_code=element["selling"]["asset_code"];
    
            //filtering based on assets choosen
            if(element["buying"]["asset_type"]=="native")
                buying_asset_code="PMN";
            if(element["selling"]["asset_type"]=="native")
                selling_asset_code="PMN";

            if(buying_asset_code==Asset_Code_A && selling_asset_code==Asset_Code_B || buying_asset_code==Asset_Code_B && selling_asset_code==Asset_Code_A)
            {       
                var amout_selling_asset=element["amount"];        
                var price=element["price"];

                var html="<tr><td>"+amout_selling_asset+"</td><td>"+price+"</td><td>"+price*amout_selling_asset+"</td></tr>";
                $('#offerstable').append(html);
            }
   
        });
        //console.log(data["_embedded"]["records"]);
    }).fail(function(data){ console.log(data.responseText);});
    });
    
    $("#Run_Kelp").click(function(){
        //alert("Run_Kelp");
        $.ajax({
            type:"Get",
            url:"/api/values",
            contentType: "application/json; charset=utf-8",
            dataType: "json",                                 
        }).done(function(data){
        console.log(data);
        if(data==true) 
            alert("kelp started successfully");
        else
            alert("kelp failed to start ");    
        })
      .fail(function(data){console.log(data.responseText);});
    });
           
    $("#btnStopBot").click(function(){
        //alert("StopBot");
        $.ajax({
            type:"Get",
            url:"/api/values/StopBot",
            contentType: "application/json; charset=utf-8",
            dataType: "json",                                 
        }).done(function(data){
        console.log(data);
        })
      .fail(function(data){console.log(data);});
    });
   
    $("#btnStartTrading").click(function(){
        //alert("Start_Trading");
        $.ajax({
            type:"Get",
            url:"/api/values/Trade",
            contentType: "application/json; charset=utf-8",
            dataType: "json",                                 
        }).done(function(data){
                console.log(data);    
            })
            .fail(function(data){alert("fail");console.log(data);});
       });
       
    $('#btnCreateFile').click(function(error, result) {
    
        for(var i=1;i<=counter;i++)
        {
            var id1="#Spread"+i;
            var id2="#Amount"+i;
            let level={number:i,spread:$(id1).val(), amount:$(id2).val()};
            lstLevels.push(level);
            debugger;
           
        }
        //var level1={number:1,spread:$("#Spread1").val(), amount:$("#Amount1").val()}
        //var level2={number:2,spread:0.002, amount:2}
        //var lstLevels=[level1];
        //alert("btnCreateFile");
        var config = {
            Trading_Secret: $('#Trading_Secret').val(),
            //Trading_Secret: "SA3EQID43UQLQDUBOAMUE5OE2IZGETA52TVILMHDLRP62ZACTW7OZRHH",
            Source_Secret: $('#Source_Secret').val(),
            //Source_Secret: "SA3EQID43UQLQDUBOAMUE5OE2IZGETA52TVILMHDLRP62ZACTW7OZRHH",
            Asset_Code_A: $('#Asset_Code_A').val(),
            //Asset_Code_A:"KELP",
    
            Issuer_A: $('#Issuer_A').val(),
            //Issuer_A:"GCU4L3C4P4VAD6ML6N4SXPKOXFHJUVYTE5EOQWTZMPRUXUGD72K5TYGY",
           
            Asset_Code_B: $('#Asset_Code_B').val(),
            //Asset_Code_B: "PMN",
            
            Issuer_B: $('#Issuer_B').val(),
            //Issuer_B: "",
            
            Tick_Interval_Second: $('#Tick_Interval_Second').val(),
            //Tick_Interval_Second: "20",
            
            Random_Delay: $('#Random_Delay').val(),
            //Random_Delay: "20",
            
            Data_Feed_A_URL: $('#Data_Feed_A_URL').val(),    
            //Data_Feed_A_URL: "2.5",
            
            DATA_TYPE_A:selected_Data_Type_A,
            //DATA_TYPE_A:"fixed",
            
            Data_Feed_B_URL: $('#Data_Feed_B_URL').val(),
            //Data_Feed_B_URL:"1.5",
            
            DATA_TYPE_B:selected_Data_Type_B,
            //DATA_TYPE_B:"fixed",
             
            Price_Tolerance: $('#Price_Tolerance').val(),
            //Price_Tolerance: "0.001",
            Amount_Tolerance: $('#Amount_Tolerance').val(),
            //Amount_Tolerance: "0.001",
            
            
            AMOUNT_OF_A_BASE:$('#Amount_Of_A_Base').val(),
            //AMOUNT_OF_A_BASE:"1.0",
            
            //HORIZON_URL:selectedUrl,
            HORIZON_URL:"https://horizon.kuknos.org:8000",
            
            Levels:lstLevels,
            
            
        };
        console.log(config);
        debugger;
        console.log(lstLevels);
        $.ajax({
            type:"POST",
            url:"/api/values/CreateConfig",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data:JSON.stringify(config)           
       
        }).done(function(data){
            console.log(data);
            }).fail(function(data){ console.log(data.responseText);});
          
    
        
    
    });

})