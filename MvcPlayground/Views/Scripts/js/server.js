
 $("#table").DataTable({
         processing: true,
         serverSide: true,
         //scrollY: 200,  // set true for deffered rows
         deferRender: false, // set true for deffered rows
         scroller: false, // set true for deffered rows
         ajax: {
             type: "POST",
             contentType: "application/json",
             url: '@Url.Action("GetData", "Home")',
             data: function (d,settings) {
                console.log(JSON.stringify(d));
                console.log(settings);
                return JSON.stringify(d);
            }
        }
    });