//$(document).ready(function () {

//    //iterate through each textboxes and add keyup
//    //handler to trigger sum event
//    $(".form-control").each(function () {

//        $(this).keyup(function () {
//            calculateSum();
//        });
//    });

//});

//function calculateSum() {

//    var sum = 0;
//    //iterate through each textboxes and add the values
//    $(".form-control").each(function () {

//        //add only if the value is number
//        if (!isNaN(this.value) && this.value.length != 0) {
//            sum -= parseFloat(this.value);
//        }

//    });
//    //.toFixed() method will roundoff the final sum to 2 decimal places
//    $("#sum").html(sum.toFixed(2));
//}

$(this).keyup(function () {
            calc();
       });

function calc() {
    var period = parseFloat(document.getElementById('period').value);
    var amount = parseFloat(document.getElementById('amount').value);
    var intRate = parseFloat(document.getElementById('intRate').value);

    document.getElementById('fee').value = ((amount / period) * ((intRate / 100) + 1)).toFixed(2);
}