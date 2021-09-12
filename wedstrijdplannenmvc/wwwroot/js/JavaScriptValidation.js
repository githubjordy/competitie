function JavaScriptValidation(F) {

    let G = F.name;  
    let x = document.forms[G]["inputthuisteam"].value;
    let y = document.forms[G]["inputuitteam"].value;
    

    if (x == "" || y=="" ){
        alert("vul een integer in aub");
        return false;
    }

    //if (x.includes(",") || y.includes(",") || x.includes(".") || y.includes(".")) {
    //    alert("vul een integer in aub");
    //    return false;
    //}

    var reg = /^\d+$/;
    var xisint =reg.test(x);
    var yisint =reg.test(y);


    if (!xisint || !yisint) {
        alert("vul een integer in");
        return false;
    }

    x = Number.parseInt(x);
    y = Number.parseInt(y);
    //let isxinteger = Number.isInteger(x);
    //let isyinteger = Number.isInteger(y);


    //x = Number.parseFloat(x);
    //y = Number.parseFloat(y);

   //x = parseInt(x);
   //y = parseInt(y);

   //isxinteger = Number.isInteger(x);
   //isyinteger = Number.isInteger(y);

   




   //if ((isNaN(x) == true) || (isNaN(y) == true)) {

   //     alert("vul een integer in");
   //     return false;
   // }
        

    
   
       
    
   
    
}