App.controller('myScheduleCtrl', myScheduleCtrl);

function myScheduleCtrl($scope, $http, $window, $interval, crudDataFactory, toastFactory, dropdownFactory, spinnerService) {

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
        DateAppointment: "",
        Date: ""
    }

    $scope.dataUpdate = {
        AppointmentDate: "",
        CheckUpTypeId: "",
        TimeRangeId: "",
        StatusId: "",
        UserNotes: "",
        DoctorNotes: ""
    }

    $scope.onCancel = function () {
        $scope.dataUpdate = {
            AppointmentDate: "",
            CheckUpTypeId: "",
            TimeRangeId: "",
            StatusId: "",
            UserNotes: "",
            DoctorNotes: ""
        }
        $scope.TimeRangeListDisable = false;
    }


    $scope.init = function(id) {
        $scope.getDateToday(id);
    }

    $scope.getDateToday = function (id)
    {
        crudDataFactory.getAll('appointments/today')
            .then(function (res) {
                $scope.data.DateAppointment = new Date(moment(res.data).format("DD-MMMM-YYYY"));
                $scope.data.Date = moment(res.data).format('YYYY-MM-DDTHH:mm:ss');
                $scope.initialize(id);
            }).catch(globalExceptionHandler)
            .finally(function () {
            });
    }

    $scope.filter = function(id) {
        $scope.data.Date = moment($scope.data.DateAppointment).format('YYYY-MM-DDTHH:mm:ss');
        $scope.initialize(id);
    }

    $scope.updateModal = function (id, disabled) {
        spinnerService.show('html5spinner');
        crudDataFactory.getById('appointments/getappointmentbyid', id)
            .then(function (res) {
                $scope.disabledField = disabled;
                $scope.dataUpdate = res.data;
                $scope.dataUpdate.AppointmentDate = new Date(moment(res.data.AppointmentDate).format("DD-MMMM-YYYY"));
                $scope.modalOpen('#dataModal', 'Update Data');
            }).catch(globalExceptionHandler)
            .finally(function () {
                spinnerService.hide('html5spinner');
            });
    };

    $scope.Save = function (user) {

        spinnerService.show('html5spinner');
        $scope.dataUpdate.UserId = user;
        crudDataFactory.save('appointments/save', $scope.dataUpdate)
            .then(function (res) {
                toastFactory.success('Success!', 'Data Saved!');
            }).catch(globalExceptionHandler)
            .finally(function () {
                $scope.filter(user);
                $scope.onCancel();
                $scope.modalClose("#dataModal");
            });
    };

    $scope.dataTable = {
        options: {
            aoColumns: [
                { 'sTitle': 'ID', 'visible': false },
                { 'sTitle': 'NAME', "width": "25%" },
                { 'sTitle': 'CHECK-UP TYPE', "width": "20%" },
                { 'sTitle': 'DATE', "width": "20%" },
                { 'sTitle': 'TIME', "width": "20%" },
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
            order: [[4, "asc"]]
        },
        data: []
    };

    $scope.initialize = function (userid) {
        $scope.userid = userid;
        spinnerService.show('html5spinner');
        crudDataFactory.save('appointments/myschedule', $scope.data)
            .then(function (res) {
                $scope.dataTable.data = [];
                for (var i = 0; i < res.data.length; i++) {

                    if (res.data[i].StatusId === 1) {
                        $scope.btn =
                            "<button class='btn btn-info btn-sm shadow btn-manage table-button-size' data-toggle='modal' data-target='#modal-default' onclick=\"angular.element(this).scope().updateModal(" +
                            res.data[i].AppointmentId +
                            ", false)\"><i class='fas fa-pencil-alt'></i>&nbsp; UPDATE </button>&nbsp;";
                    } else {
                        $scope.btn =
                            "<button class='btn btn-success btn-sm shadow btn-manage table-button-size' data-toggle='modal' data-target='#modal-default' onclick=\"angular.element(this).scope().updateModal(" +
                            res.data[i].AppointmentId +
                            ", true)\"><i class='fas fa-eye'></i>&nbsp; VIEW </button>&nbsp;";
                    }

                    $scope.dataTable.data.push([
                        res.data[i].AppointmentId,
                        res.data[i].FullName,
                        res.data[i].CheckUpType,
                        res.data[i].AppointmentDate,
                        moment(res.data[i].StartRange, ["HH:mm"]).format("h:mm A") + "-" + moment(res.data[i].EndRange, ["HH:mm"]).format("h:mm A"),
                        res.data[i].Status,
                        $scope.btn
                    ]);
                }
            }).catch(globalExceptionHandler)
            .finally(function () {
                spinnerService.hide('html5spinner');
            });
    };

}