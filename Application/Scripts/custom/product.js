var product = (function(){

    function createproduct() {

        if($('#name').val() == "" || $('#category').val() == "" || $('#price').val() == "" || $('#count').val()=="")
        {
            alert('Please complete all fields to complete this action.');
            return false; 
        }


        var data = {
            Id: $('#Id').val(),
            Name: $('#name').val(),
            Category: $('#category').val(),
            Price: $('#price').val(),
            StockCount: $('#count').val()
        };

        $.ajax({
            type: "POST",
            url: "/Product/Create",
            data: data,
            success: success
        });
    };

    function success() {
       window.location.href="/Product/Index"
    }


    return {
        createproduct: createproduct
    };

})();