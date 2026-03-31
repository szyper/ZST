const express = require("express");

const app = express();

app.get("/", (teq, res) => {
    res.send("SERWER DZIAŁA");
});

app.listen(3001, () => {
    console.log("SERVER START");
    
});