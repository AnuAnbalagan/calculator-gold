var gold = $("#Gold").val();


$("#calculate").click(function (event) {
    event.preventDefault();
    var myHeaders = new Headers();
    myHeaders.append("x-access-token", "goldapi-agkgplotl7a7fy9d-io");
    myHeaders.append("Content-Type", "application/json");
    var input = parseFloat($("#Gold").val());
    var requestOptions = {
        method: 'GET',
        headers: myHeaders,
        redirect: 'follow'
    };

    fetch("https://www.goldapi.io/api/XAU/INR", requestOptions)
        .then(response => response.text())
        .then(result => result.split(",")[15])
        .then(res => parseFloat(res.substring(17)))
        .then(r => console.log( r * input))
});