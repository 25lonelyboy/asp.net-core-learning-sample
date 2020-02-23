module.exports = function (callback, a, b) {
    var result = a + b;
    callback(null, result);  //异步编程、每个方法都有回调
}