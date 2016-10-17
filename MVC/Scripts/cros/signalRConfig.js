//后台UI的SignalR
var _signalrStatus = {
    init: "init",
    start: "start",
    error: "error"
}
var _signalrIsStart = _signalrStatus.init;//{"init","start","error"}
var _signalrHub = undefined;
var _signalrCallBack = function () { };
$(function () {
    //signalr
    $.connection.hub.url = _signalrUrl;//这个在外面用@ViewBag方式赋值的。故在js文件外面Home/Index.cshtml
    $.connection.logging = true;
    _signalrHub = $.connection.userTaskHub;
    $.connection.hub.received(function (data) {
        _signalrCallBack();
    });
    $.connection.hub.start().done(function (data) {
        _signalrIsStart = _signalrStatus.start;
    }).fail(function (err) {
        _signalrIsStart = _signalrStatus.error;
        alert("signalr启动失败。失败原因：" + err);
    });
    //signalr
});
var signalrFunction = function () {

    function signalrBasics(fun) {
        if (_signalrIsStart == _signalrStatus.init) {
            setTimeOut(function () {
                signalrBasics(fun);
            }, 5000);
        } else if (_signalrIsStart == _signalrStatus.start) {
            fun();
        }
    };
    return {
        signalrCallBack: function (callback) {
            if (typeof (callback) == "function") {
                _signalrCallBack = callback;
            }
        },
        sendMessage: function (userId, messageNum) {
            signalrBasics(function () {
                _signalrHub.server.sendMessage(userId, messageNum);
            });
        },
        login: function (userId) {
            signalrBasics(function () {
                _signalrHub.server.login(userId);
            });
        }
        //假设在UserTaskHub里新建了新的方法。只需在这里建一个对外方法。然后
        //自定义方法: function (参数1,参数2) {
        //signalrBasics(function () {
        //    _signalrHub.server.新的方法(参数1,参数2);
        //});然后使用getSignalr().自定义方法即可执行。
    }
}();