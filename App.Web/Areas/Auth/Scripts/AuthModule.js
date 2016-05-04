(function () {
    var config = window.config,
        name = config.name;

    function bindEvents() {
    
    }
    
    var authForm = {
        initMenu: function ($login_menu, $loginform) {
            var login_show = false;

            $login_menu.click(function () {
                if (login_show) {
                    $loginform.fadeOut();
                } else {
                    $loginform.fadeIn();
                }
                login_show = !login_show;
            });

            bindEvents();
        }
    };


    window[name] = {};
    window[name].authForm = authForm;
})();

