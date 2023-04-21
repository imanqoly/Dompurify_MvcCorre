const dmp = require('dompurify');
const {JSDOM } = require('jsdom')

module.exports = function (callback, name) {

    const window = new JSDOM('').window;
    const DOMpurify = dmp(window)
    let res = DOMpurify.sanitize(name)
    callback(null, res) 
};

