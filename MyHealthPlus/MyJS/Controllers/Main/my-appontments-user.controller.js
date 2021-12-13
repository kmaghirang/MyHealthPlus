App.controller('myAppointmentsCtrl', myAppointmentsCtrl);

function myAppointmentsCtrl($scope, $http, $window, $interval, crudDataFactory, toastFactory, dropdownFactory, spinnerService) {

    function globalExceptionHandler(err) {
        const data = $(err.data);
        if (err && data) {
            const ex = data.filter("title").text();
            toastFactory.error("Error", ex);
        }
    }
    // initialize dropdowns
    $scope.CheckUpTypesDd();
    $scope.TimeRangeList2Dd();
    $scope.StatusDd();

    $scope.data = {
        AppointmentDate: "",
        CheckUpTypeId: "",
        TimeRangeId: ""
    }

    $scope.onCancel = function() {
        $scope.data = {
            CheckDate: "",
            AppointmentDate: "",
            CheckUpTypeId: "",
            TimeRangeId: ""
        }
        $scope.TimeRangeListDisable = false;
    }

    $scope.Save = function (user) {

        spinnerService.show('html5spinner');
        $scope.data.UserId = user;
        crudDataFactory.save('appointments/save', $scope.data)
            .then(function (res) {
                toastFactory.success('Success!', 'Data Saved!');
            }).catch(globalExceptionHandler)
            .finally(function () {
                $scope.initialize($scope.userid);
                $scope.onCancel();
                $scope.modalClose("#dataModal");
            });
    };

    $scope.updateModal = function (id, disabled) {
        spinnerService.show('html5spinner');
        crudDataFactory.getById('appointments/getappointmentbyid', id)
            .then(function (res) {
                $scope.disabledField = disabled;
                $scope.dataUpdate = res.data;
                $scope.dataUpdate.AppointmentDate = new Date(moment(res.data.AppointmentDate).format("DD-MMMM-YYYY"));
                $scope.modalOpen('#dataModal2', 'Update Data');
            }).catch(globalExceptionHandler)
            .finally(function () {
                spinnerService.hide('html5spinner');
            });
    };

    $scope.cancel = function (id) {
        if (confirm('Are you sure you want to cancel this appointment?')) {
            spinnerService.show('html5spinner');
            crudDataFactory.getById('appointments/cancel', id)
                .then(function (res) {
                    toastFactory.success('Success!', 'Appointment Cancelled!');
                    $scope.initialize($scope.userid);
                }).catch(globalExceptionHandler)
                .finally(function () {
                    spinnerService.hide('html5spinner');
                });
        }
    };

    $scope.dataTable = {
        options: {
            aoColumns: [
                { 'sTitle': 'ID', 'visible': false },
                { 'sTitle': 'NAME', "width":"25%" },
                { 'sTitle': 'CHECK-UP TYPE', "width": "20%"},
                { 'sTitle': 'DATE', "width": "20%" },
                { 'sTitle': 'TIME', "width":"20%"},
                { 'sTitle': 'STATUS', "width": "10%" },
                { 'sTitle': 'OPTIONS', "width": "5%" }
            ],
            aoColumnDefs: [{
                'bSortable': false,
                'aTargets': [-1]
            }],
            bJQueryUI: true,
            bDestroy: true,
            aaData: null,
            order: [[0, "desc"]]
        },
        data: []
    };

    $scope.initialize = function (userid) {
        $scope.userid = userid;
        spinnerService.show('html5spinner');
        crudDataFactory.getById('appointments/myappointments', userid)
            .then(function (res) {
                $scope.dataTable.data = [];
                for (var i = 0; i < res.data.length; i++) {
                    if (res.data[i].StatusId === 1) {
                        $scope.button =
                            "<button class='btn btn-danger btn-sm shadow btn-manage table-button-size ' data-toggle='modal' data-target='#modal-default' onclick=\"angular.element(this).scope().cancel(" +
                        res.data[i].AppointmentId +
                            ")\"><i class='fas fa-ban'></i>&nbsp; CANCEL </button>";
                    } else {
                        $scope.button = "";
                    }
                    $scope.dataTable.data.push([
                        res.data[i].AppointmentId,
                        res.data[i].FullName,
                        res.data[i].CheckUpType,
                        res.data[i].AppointmentDate,
                        moment(res.data[i].StartRange, ["HH:mm"]).format("h:mm A") + "-" + moment(res.data[i].EndRange, ["HH:mm"]).format("h:mm A"),
                        res.data[i].Status,
                        "<button class='btn btn-success btn-sm shadow btn-manage table-button-size' data-toggle='modal' data-target='#modal-default' onclick=\"angular.element(this).scope().updateModal(" +
                        res.data[i].AppointmentId +
                        ", true)\"><i class='fas fa-eye'></i>&nbsp; VIEW </button>&nbsp;" + $scope.button
                    ]);
                }
            }).catch(globalExceptionHandler)
            .finally(function () {
                spinnerService.hide('html5spinner');
            });
    };

}