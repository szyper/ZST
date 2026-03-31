const express = require("express");

const app = express();

app.use((req, res, next) => {
    res.setHeader("Access-Control-Allow-Origin", "*");
    next();
});

app.get("/api/stats", (req, res) => {
    res.json({
        users: 1100,
        posts: 45
    });
});