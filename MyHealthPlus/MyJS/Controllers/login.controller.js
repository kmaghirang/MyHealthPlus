App.controller('userLoginCtrl', userLoginCtrl);
function userLoginCtrl($scope, $http, $window, $interval, crudDataFactory, toastFactory, dropdownFactory, spinnerService) {

    function globalExceptionHandler(err) {
        const data = $(err.data);
        if (err && data) {
            const ex = data.filter("title").text();
            toastFactory.error("Error", ex);
        }
    }


    ///////////////////////////////////////////////////////////////////////////
    // 
    //      Modal Functions

    $scope.modalOpen = function (modal, title) {
        $scope.modalTitle = title;
        var modal_popup = angular.element(modal);
        modal_popup.modal("show");
    };

    $scope.modalClose = function (modal) {
        var modal_popup = angular.element(modal);
        modal_popup.modal("hide");
    };

    $scope.modalPreventDismiss = function (data) {
        $(data).modal({
            backdrop: 'static',
            keyboard: false
        });
    };

    ///////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////
    // 
    //      Save Registration


    $scope.onCancel = function () {
        $scope.register = [];
    };

    $scope.Save = function () {

        spinnerService.show('html5spinner');
        crudDataFactory.save('registration', $scope.register)
            .then(function (res) {
                toastFactory.success('Success!', 'Registration Successful!');
            }).catch(globalExceptionHandler)
            .finally(function () {
                $scope.onCancel();
                $scope.modalClose('#dataModal');
                spinnerService.hide('html5spinner');
            });
    };

    $scope.checkUsername = function (username) {
        if (username !== "") {
            spinnerService.show('html5spinner');
            crudDataFactory.getById('registration', username)
                .then(function (res) {
                    if (res.data === false) {
                        toastFactory.warning('Warning!', 'Username Already Exist!');
                        $scope.register.UserName = "";
                    }
                }).catch(globalExceptionHandler)
                .finally(function () {
                    spinnerService.hide('html5spinner');
                });
        }
    };

    ///////////////////////////////////////////////////////////////////////////

    $scope.data = {
        UserName: "",
        Password: ""
    };

    $scope.Login = function () {
        spinnerService.show('html5spinner');
        crudDataFactory.Post("Login/ValidateUser", $scope.data)
            .then(function (res) {
                console.log(res.data);
                if (res.data === "no users") {
                    toastFactory.warning('Warning!', 'No Account found.');
                    spinnerService.hide('html5spinner');
                } else if (res.data === 0) {
                    toastFactory.warning('Warning!', 'Password did not match with username.');
                    spinnerService.hide('html5spinner');
                } else {
                    toastFactory.success('Success!', 'Logging in...');
                    setTimeout(function () {
                            if (res.data !== 2) {
                                $window.location.href = url + "Home/MyAppointments";
                            } else {
                                $window.location.href = url + "Home/MySchedule";
                            }
                        },
                        2500);
                }
            }).catch(globalExceptionHandler)
            .finally(function () {
                spinnerService.hide('html5spinner');
            });
    };


    
}