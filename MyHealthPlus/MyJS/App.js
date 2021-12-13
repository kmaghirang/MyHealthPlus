var App = angular.module('App', [
    'ngAria',
    'ngAnimate',
    'ui.bootstrap',
    'angularSpinners',
    'ngIdle'
    //'ui.calendar'
]);
App.config([
    '$compileProvider',
    function ($compileProvider) {
        $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|javascript|sip):/);
        // Angular before v1.2 uses $compileProvider.urlSanitizationWhitelist(...)
    }
]);
App.config(function (IdleProvider, KeepaliveProvider) {
        // configure Idle settings
        // IdleProvider.idle(300); // in seconds
        IdleProvider.idle(1000); // in seconds
        //IdleProvider.idle(10); 
        IdleProvider.timeout(10); // in seconds
        KeepaliveProvider.interval(1); // in seconds
    })
    .run(function (Idle) {
        // start watching when the app runs. also starts the Keepalive service by default.
        Idle.watch();
    });
App.factory('crudDataFactory', crudDataFactory);
App.factory('dropdownFactory', dropdownFactory);
App.factory('toastFactory', toastFactory);
App.directive('jqDataTable', jqDataTable);