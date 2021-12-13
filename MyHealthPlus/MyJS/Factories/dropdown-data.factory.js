function dropdownFactory($http) {

    var fac = {};

    fac.Roles = function () {
        return $http.get(url + "api/v1/roles/drop");
    };

    fac.CheckUpTypes = function () {
        return $http.get(url + "api/v1/checkuptypes/drop");
    };

    fac.TimeRangeList = function (vm) {
        return $http.post(url + "api/v1/timerange/drop", vm);
    };

    fac.TimeRangeList2 = function () {
        return $http.get(url + "api/v1/timerange/drop2");
    };

    fac.Status = function () {
        return $http.get(url + "api/v1/status/drop");
    };


    return fac;
}