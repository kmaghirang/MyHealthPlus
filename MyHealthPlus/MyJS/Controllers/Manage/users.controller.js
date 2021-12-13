App.controller('usersCtrl', usersCtrl);

function usersCtrl($scope, $http, $window, $interval, crudDataFactory, toastFactory, dropdownFactory, spinnerService) {

    function globalExceptionHandler(err) {
        const data = $(err.data);
        if (err && data) {
            const ex = data.filter("title").text();
            toastFactory.error("Error", ex);
        }
    }

    $scope.RolesDd();

    $scope.data = {
        UserName: "",
        LastName: "",
        FirstName: "",
        MiddleName: "",
        RoleId: "",
        UpdatedBy: ""
    }

    $scope.onCancel = function() {
        $scope.data = {
            UserName: "",
            LastName: "",
            FirstName: "",
            MiddleName: "",
            RoleId: "",
            UpdatedBy: ""
        }
    }

    $scope.updateModal = function (id) {
        spinnerService.show('html5spinner');
        crudDataFactory.getById('users', id)
            .then(function (res) {
                $scope.data = res.data;
                $scope.modalOpen('#dataModal', 'Update Data');
            }).catch(globalExceptionHandler)
            .finally(function () {
                spinnerService.hide('html5spinner');
            });
    };

    $scope.Save = function (user) {

        spinnerService.show('html5spinner');
        $scope.data.UpdatedBy = $scope.username;
        crudDataFactory.save('users', $scope.data)
            .then(function (res) {
                toastFactory.success('Success!', 'Data Saved!');
            }).catch(globalExceptionHandler)
            .finally(function () {
                $scope.initialize($scope.userid);
                $scope.onCancel();
                $scope.modalClose("#dataModal");
            });
    };

    $scope.dataTable = {
        options: {
            aoColumns: [
                { 'sTitle': 'ID', 'visible': false },
                { 'sTitle': 'USERNAME', "width": "20%" },
                { 'sTitle': 'LAST NAME', "width": "20%" },
                { 'sTitle': 'FIRST NAME', "width": "20%" },
                { 'sTitle': 'MIDDLE NAME', "width": "20%" },
                { 'sTitle': 'ROLE', "width": "10%" },
                { 'sTitle': 'OPTIONS', "width": "10%" }
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

    $scope.initialize = function (userid, username) {
        $scope.userid = userid;
        $scope.username = username;
        spinnerService.show('html5spinner');
        crudDataFactory.getAll('users/tbl')
            .then(function (res) {
                $scope.dataTable.data = [];
                for (var i = 0; i < res.data.length; i++) {
                    $scope.dataTable.data.push([
                        res.data[i].UserId,
                        res.data[i].UserName,
                        res.data[i].LastName,
                        res.data[i].FirstName,
                        res.data[i].MiddleName,
                        res.data[i].Role,
                        "<button class='btn btn-info btn-sm shadow btn-manage table-button-size' data-toggle='modal' data-target='#modal-default' onclick=\"angular.element(this).scope().updateModal(" +
                        res.data[i].UserId +
                        ")\"><i class='fas fa-pencil-alt'></i>&nbsp; UPDATE </button>&nbsp;"
                    ]);
                }
            }).catch(globalExceptionHandler)
            .finally(function () {
                spinnerService.hide('html5spinner');
            });
    };


}