(function () {
    window.DataTable = function(elem, options) {
        var el = elem;
        var url = options.dataUrl;

        return {
            render: function() {

                $.ajax(url).then(function(data) { debugger; });

            }
        };
    }
})();