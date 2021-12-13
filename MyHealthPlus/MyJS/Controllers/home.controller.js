App.controller('homeCtrl', homeCtrl);

function homeCtrl($scope, $http, $window, $interval, crudDataFactory, toastFactory, dropdownFactory, spinnerService) {

    function globalExceptionHandler(err) {
        const data = $(err.data);
        if (err && data) {
            const ex = data.filter("title").text();
            toastFactory.error("Error", ex);
        }
    }

    $scope.altInputFormats = ['M!/d!/yyyy'];
    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];

    $scope.dateOptions = [
        date1 = {
            formatYear: 'yy'
        }
    ];

    $scope.open1 = function() {
        $scope.popup1.opened = true;
    };
    $scope.popup1 = {
        opened: false
    };

    $scope.open2 = function() {
        $scope.popup2.opened = true;
    };
    $scope.popup2 = {
        opened: false
    };

    $scope.open3 = function() {
        $scope.popup3.opened = true;
    };
    $scope.popup3 = {
        opened: false
    };

    ///////////////////////////////////////////////////////////////////////////
    // 
    //      Modal Functions

    $scope.logout = function () {
        spinnerService.show('html5spinner');
        crudDataFactory.Get('Login/Logout')
            .then(function (res) {
                if (res.data === 1) {
                    toastFactory.success('Success!', 'Logging out...');
                    setTimeout(function () {
                            $window.location.href = url + "Login/Index";
                        },
                        2500);
                } else if (res.data === 0) {
                    toastFactory.error('Error!', 'Error logging out.');
                    spinnerService.hide('html5spinner');
                }
            }).catch(globalExceptionHandler)
            .finally(function () {
            });
    };

    ///////////////////////////////////////////////////////////////////////////



    ///////////////////////////////////////////////////////////////////////////
    // 
    //      Modal Functions

    $scope.modalOpen = function(modal, title) {
        $scope.modalTitle = title;
        var modal_popup = angular.element(modal);
        modal_popup.modal("show");
    };

    $scope.modalClose = function(modal) {
        var modal_popup = angular.element(modal);
        modal_popup.modal("hide");
    };

    $scope.modalPreventDismiss = function(data) {
        $(data).modal({
            backdrop: 'static',
            keyboard: false
        });
    }

    ///////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////
    // 
    //      Dropdown Functions


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    $scope.RolesList = [];

    $scope.RolesDd = function() {
        dropdownFactory.Roles()
            .then(function(res) {
                $scope.RolesList = res.data;
            }).catch(globalExceptionHandler)
            .finally(function() {
            });
    };

    $scope.CheckUpTypesList = [];

    $scope.CheckUpTypesDd = function () {
        dropdownFactory.CheckUpTypes()
            .then(function (res) {
                $scope.CheckUpTypesList = res.data;
            }).catch(globalExceptionHandler)
            .finally(function () {
            });
    };

    $scope.CheckDate = {
        CheckDate: ""
}

    $scope.TimeRangeListList = [];
    $scope.TimeRangeListDisable = true;
    $scope.TimeRangeListDd = function (data) {
        if (data !== "") {
            spinnerService.show('html5spinner');
            $scope.CheckDate.CheckDate = moment(data).format('YYYY-MM-DDTHH:mm:ss');
            dropdownFactory.TimeRangeList($scope.CheckDate)
                .then(function (res) {
                    if (res.data === null) {
                        toastFactory.warning('Warning!', 'No available slot for today!');
                    } else {
                        for (var i = 0; i < res.data.length; i++) {
                            var timeList = res.data[i];
                            timeList.StartRange = moment(timeList.StartRange, ["HH:mm"]).format("h:mm A");
                            timeList.EndRange = moment(timeList.EndRange, ["HH:mm"]).format("h:mm A");
                        }
                        $scope.TimeRangeListList = res.data;
                        $scope.TimeRangeListDisable = false;
                    }
                    
                }).catch(globalExceptionHandler)
                .finally(function () {
                    spinnerService.hide('html5spinner');
                });
        }
        
    };

    $scope.TimeRangeList2List = [];

    $scope.TimeRangeList2Dd = function () {
        dropdownFactory.TimeRangeList2()
            .then(function (res) {
                for (var i = 0; i < res.data.length; i++) {
                    var timeList = res.data[i];
                    timeList.StartRange = moment(timeList.StartRange, ["HH:mm"]).format("h:mm A");
                    timeList.EndRange = moment(timeList.EndRange, ["HH:mm"]).format("h:mm A");
                }
                $scope.TimeRangeList2List = res.data;
            }).catch(globalExceptionHandler)
            .finally(function () {
            });
    };

    $scope.StatusList = [];

    $scope.StatusDd = function () {
        dropdownFactory.Status()
            .then(function (res) {
                $scope.StatusList = res.data;
            }).catch(globalExceptionHandler)
            .finally(function () {
            });
    };

    //$scope.List = [];

    //$scope.Dd = function () {
    //    dropdownFactory.()
    //        .then(function (res) {
    //            $scope.List = res.data;
    //        }).catch(globalExceptionHandler)
    //        .finally(function () {
    //        });
    //};

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}