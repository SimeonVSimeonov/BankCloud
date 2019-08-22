$(this).on("change paste keyup", function () {
    depositCalc();
});

function depositCalc() {
    var amount = parseFloat(document.getElementById('saveAmount').value);
    var intRate = parseFloat(document.getElementById('saveIntRate').value);

    document.getElementById('saveIncome').value = ((amount / 100) * intRate).toFixed(2);
}