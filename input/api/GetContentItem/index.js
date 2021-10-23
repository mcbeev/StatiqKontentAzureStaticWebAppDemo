const fetch = require("node-fetch");

module.exports = async function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    const codeName = (req.query.codeName || (req.body && req.body.codeName));

    const url = process.env.KontentDeliveryAPIEndpoint + process.env.KontentProjectID + "/items/"; 
    
    await fetch(url + codeName)
        .then(response => response.json())
        .then(response => context.res.json(response.item.elements.content.value)); 
    
}