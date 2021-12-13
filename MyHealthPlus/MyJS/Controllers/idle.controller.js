App.controller('idleCtrl', idleCtrl);
function idleCtrl($scope, $http, $window, crudDataFactory, toastFactory, spinnerService, dropdownFactory, Idle, Keepalive) {

    function globalExceptionHandler(err) {
        const data = $(err.data);
        if (err && data) {
            const ex = data.filter("title").text();
            toastFactory.error("Error", ex);
        }
    }

    /////// idle 
    $scope.started = false;
    function closeModals() {
        if ($scope.warning) {
            $scope.warning.close();
            $scope.warning = null;
        }
        if ($scope.timedout) {
            $scope.timedout.close();
            $scope.timedout = null;
        }
    }

    $scope.$on('IdleStart', function () {
        closeModals();
        swal({
            title: "You're Idle too much.",
            text: "You will be re-logged in 10 second(s).",
            timer: 10000,
            showConfirmButton: false
        });
        console.log("Informing");
    });

    $scope.$on('IdleEnd', function () {
        closeModals();
    });

    $scope.$on('IdleTimeout', function () {
        closeModals();
        swal({
            title: "Session Expired.",
            text: "Your session has been expired. You will be re-logged in.",
            timer: 10000,
            showConfirmButton: false
        });
        $scope.sendLogout();
    });

    $scope.start = function () {
        closeModals();
        Idle.watch();
        $scope.started = true;
    };

    $scope.stop = function () {
        closeModals();
        Idle.unwatch();
        $scope.started = false;

    };

    $scope.sendLogout = function () {
        $window.location.href = url + "Login/ValidateUser";
    };
}