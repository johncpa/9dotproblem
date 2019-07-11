var express = require("express");
var mysql = require("mysql");
var bodyParser = require("body-parser");
var app = express();
var apiRoutes = express.Router();
app.use(bodyParser.json()); // for å tolke JSON
app.use(express.static('./public'));

//app.use(express.static(public_path));
var config = require('./config');

const DaoWrapper = require("./daowrapper.js");

var pool = mysql.createPool({
  connectionLimit: 5,
  host: config.DATABASE_HOST,
  user: config.DATABASE_USER,
  password: config.DATABASE_PASS,
  database: config.DATABASE_DB,
  debug: false,
  multipleStatements: true
});

app.post("/api/9dotproblem", (req, res) => {
  console.log("/api/9dotproblem got POST request from client");
  new DaoWrapper(pool).createOne(req.body, (status, data) => {
    res.status(status);
    res.json(data);
  });
});

app.get("/game/StreamingAssets", (req, res) => {
  console.log("/9dotproblem got GET request from client");
  res.status(200);
  res.json(config.URL);
});

//TESTING
app.post("/9dotproblem", (req, res) => {
  console.log("/9dotproblem got POST request from client");
  new DaoWrapper(pool).createOne(req.body, (status, data) => {
    res.status(status);
    res.json(data);
  });
});

var fs = require("fs");

app.post("/9dotproblem/write", (req, res) => {
  console.log("/9dotproblem/write got POST request from client");
  var data = req.body.text;
  console.log("Got data: " + data);

  var prevData = "";
  fs.readFile("./logging/log.txt", "utf-8", (err, readData) => {
    if(err) {
      console.log(err);
      fs.writeFile("./logging/log.txt", data, (err) => {
        if(err) console.log(err);
        else console.log("Successfully written to file!");
      });
    }
    else{
      prevData = readData;
      fs.writeFile("./logging/log.txt", prevData + data, (err) => {
        if(err) console.log(err);
        else console.log("Successfully written to file!");
      });
    }
  });
});

app.get("/9dotproblem", (req, res) => {
  console.log("/9dotproblem got GET request from client");
});

const PORT = process.env.PORT || 3000;
app.listen(PORT, function() {
  console.log(`App listening on port ${PORT}`);
});
