function crudDataFactory($http) {

    var baseUrl = url + 'api/v1/';
    var fac = {};
    fac.path = "";

    fac.getAll = function (a) {
        return $http.get(baseUrl + a);
    };

    fac.getById = function(a, id) {
        return $http.get(baseUrl + a + "/" + id);
    };

    fac.toggle = function (a, id, windowsid) {
        return $http.delete(baseUrl + a + "/" + id + "/" + windowsid);
    }

    fac.save = function (api, vm) {
        return $http.post(baseUrl + api, vm);
    };

    fac.Post = function (controller, data) {

        return $http({
            method: "POST",
            url: url + controller,
            data: data,
            headers: { "Content-Type": "application/json" }
        });

    }

    fac.Get = function (controller) {
        return $http({
            method: "GET",
            url: url + controller,
            headers: { "Content-Type": "application/json" }
        });
    };
    return fac;
}