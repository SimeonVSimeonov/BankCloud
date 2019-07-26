
//.on("change paste keyup", function)

$(this).keyup(function () {
            calc();
       });

function calc() {
    var period = parseFloat(document.getElementById('period').value);
    var amount = parseFloat(document.getElementById('amount').value);
    var intRate = parseFloat(document.getElementById('intRate').value);

    document.getElementById('fee').value = ((amount / period) * ((intRate / 100) + 1)).toFixed(2);
}