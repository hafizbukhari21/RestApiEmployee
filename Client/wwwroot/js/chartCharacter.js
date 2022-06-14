function showChart(param) {

    var marksCanvas = document.getElementById("showChart");

    var marksData = {
        labels: ["HP", "Attack", "Defense","Spescial-Attack","Special-Defense","Speed"],
        datasets: [{
            label: param.name,
            backgroundColor: "rgba(0,88,113,0.5)",
            pointBackgroundColor: 'rgba(0,88,113,0.5)',
            pointBorderColor: 'rgba(0,88,113,0.5)',
            data: [
              param.stats[0].base_stat,
              param.stats[1].base_stat,
              param.stats[2].base_stat,
              param.stats[3].base_stat,
              param.stats[4].base_stat,
              param.stats[5].base_stat,
            ]
        }]
    };

    var radarChart = new Chart(marksCanvas, {
        type: 'radar',
        data: marksData,
        options: {
            animation: true,
            maintainAspectRatio: false,
            responsive: false,
            scales: {
                r: {
                    angleLines: {
                        display:false
                    },
                    suggestedMin: 0,
                    suggestedMax:120
                }
            }


        }
    });

    setTimeout(() => {
       
        document.querySelector(".ShowChartWrapper").style.display="block"
    },1000)

    return radarChart;
}

