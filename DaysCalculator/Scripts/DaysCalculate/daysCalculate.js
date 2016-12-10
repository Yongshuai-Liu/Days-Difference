function calculateDaysDiff() {
    var fromDate = $('#fromDate').val();
    var toDate = $('#toDate').val();
    $.ajax({
        url: '/DaysCalculate/Calculate',
        type: 'POST',
        data: {
            fromDate: fromDate,
            toDate: toDate,
        },
        success: function (response) {
            console.log(response);
            //Display the days difference
            var result = "Days difference between " + fromDate + " and " + toDate + " is: " + response;
            $('#result').text(result);
        }
    });
}

