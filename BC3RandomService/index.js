//Load express module with `require` directive
var express = require('express')
var httpRequest = require('xmlhttprequest').XMLHttpRequest
var app = express()
var innerRequest = new httpRequest() 

//Define request response in root URL (/)
app.get('/', function (req, res) {
    res.header('Access-Control-Allow-Origin', req.headers.origin || "*");
    res.header('Access-Control-Allow-Methods', 'GET,POST,PUT,HEAD,DELETE,OPTIONS');
    res.header('Access-Control-Allow-Headers', 'content-Type,x-requested-with');

    innerRequest.open('GET', "http://localhost:8088/all", false);
    innerRequest.send();
    var rando = Math.floor(Math.random() * 3);

    if (innerRequest.status >= 200 && innerRequest.status < 300) {
      console.log(innerRequest.responseText);
    } else {
        console.warn(innerRequest.statusText, innerRequest.responseText);
    }

    var result = JSON.parse(innerRequest.responseText)[rando];
    res.send(result);
})

//Launch listening server on port 8080
app.listen(8080, function () {
  console.log('App listening on port 8080!')
})