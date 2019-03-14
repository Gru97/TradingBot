$(document).ready(function(){
        
        $("#btnGet").click(function(){
            $.ajax({
                type:"Get",
                url:"https://localhost:5001/api/values",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
         
                success:function(data){debugger;alert(data.name+" "+ data.id);}
            
           
            });
        })


        $("#btnPost").click(function(){
       var name=$("#txtValue").val();
       
        debugger;
            $.ajax({
                type:"POST",
                url:"https://localhost:5001/api/values",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data:JSON.stringify(name)           
           
            }).done(function(){alert("success");}).fail(function(){alert("fail");});
        })
      
   })