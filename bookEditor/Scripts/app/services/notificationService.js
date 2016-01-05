angular.module('bookEditApp').factory('notificationService', function () {
    var successMessageType = "alert-success";
    var errorMessageType = "alert-danger";

    var _showMessageFlag = false;
    var _messageType = successMessageType;
    var _infoMessage = "";

    var _init = function (notification) {
        notification.infoMessage = _infoMessage;
        notification.messageType = _messageType;
        notification.showMessageFlag = _showMessageFlag;
    };

    var _setErrorInitMessage = function (message) {
        _infoMessage = message;
        _messageType = errorMessageType;
        _showMessageFlag = false;
    };

    var _setSuccessInitMessage = function (message) {
        _infoMessage = message;
        _messageType = successMessageType;
        _showMessageFlag = true;
    };

    var _setErrorInitMessage = function (message) {
        _infoMessage = message;
        _messageType = errorMessageType;
        _showMessageFlag = true;
    };

    var _setEmptyInitMessage = function () {
        _infoMessage = "";
        _messageType = successMessageType;
        _showMessageFlag = false;
    }

    var _showErrorMessage = function (message, notification) {
        notification.infoMessage = message;
        notification.messageType = errorMessageType;
        notification.showMessageFlag = true;
    };

    var _showSuccessMessage = function (message, notification) {
        notification.infoMessage = message;
        notification.messageType = successMessageType;
        notification.showMessageFlag = true;
    };

    var _hideNotification = function (notification) {
        notification.showMessageFlag = false;
        _setEmptyInitMessage();
    };

    return {
        init: _init,
        setEmptyInitMessage: _setEmptyInitMessage,
        setSuccessInitMessage: _setSuccessInitMessage,
        setErrorInitMessage: _setErrorInitMessage,        
        showErrorMessage: _showErrorMessage,
        showSuccessMessage: _showSuccessMessage,
        hideNotification: _hideNotification,
    };
})