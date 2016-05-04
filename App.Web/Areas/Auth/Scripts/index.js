var config = window.config,
       name = config.name;

window[name] = window[name] || {};

$(document).ready(function () {
    var authForm = window[name].authForm;

    if (authForm) {
        authForm.initMenu($('.login_menu'), $('.login_form'));
    }
});