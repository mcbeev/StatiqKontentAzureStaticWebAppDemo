const fetch = require("node-fetch");

module.exports = async function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    const codeName = (req.query.codename || (req.body && req.body.codename));

    const url = process.env.KontentDeliveryAPIEndpoint 
                    + process.env.KontentProjectID 
                    + "/items/"
                    + codeName; 

    context.log("url:" + url);

    await fetch(url)
        .then(response => response.json())
        .then(response => context.res.json(response.item.elements.content.value)); 
    
}