function jqDataTable() {
    return {
        restrict: 'E, A, C',
        link: function (scope, element, attrs, controller) {

            ( function ($) {
                var dataTable = $('#' + attrs.id).dataTable(scope.tableOptions);

                scope.$watch('tableData', function (newValue, oldValue, scope) {
                    dataTable.fnClearTable();
                    if (scope.tableData.length !== 0) {
                        dataTable.fnAddData(scope.tableData);
                    }
                }, true);
            })(jQuery);



        },
        scope: {
            tableOptions: '=',
            tableData: '='
        }
    };
}