//var ctx = document.getElementById("Score");

//var scores = [100, 66];
//var categories = ["dCC", "C#"];

//var Score = new Chart(ctx, {
//    type: "pie",
//    data: {
//        labels: frameworks,
//        datasets: [
//            {
//                label: "Technical Skills",
//                data: stars,
//                backgroundColor: [
//                    "rgba(255, 99, 132, 0.2)",
//                    "rgba(54, 162, 235, 0.2)",
//                    "rgba(255, 206, 86, 0.2)",
//                    "rgba(75, 192, 192, 0.2)",
//                    "rgba(153, 102, 255, 0.2)"
//                ],
//                borderColor: [
//                    "rgba(255, 99, 132, 1)",
//                    "rgba(54, 162, 235, 1)",
//                    "rgba(255, 206, 86, 1)",
//                    "rgba(75, 192, 192, 1)",
//                    "rgba(153, 102, 255, 1)",
//                ],
//                borderWidth: 1
//            }
//        ]
//    }
//});

var ctx = document.getElementById('Score').getContext('2d');
var chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'bar',

    // The data for our dataset
    data: {
        labels: ['dCC', 'C#'],
        datasets: [{
            label: 'Technical Skills',
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: [100, 66] //data
        }]
    },

    // Configuration options go here
    options: {
        maintainAspectRatio: false,
        responsive: false
    }
});