var App = App || {};

App.Alert = (function ($) {
    'use strict';

    var $alerts;

    function init() {
        $alerts = $('.site-alert');

        $alerts.each(function () {
            var $alert = $(this),
                alertId = $alert.data('alertid');

            if ($alert && !alertDismissed(alertId)) {
                $alert.on('click', '.site-alert__dismiss', function (e) {
                    e.preventDefault();
                    dismissAlert($alert, alertId);
                });
            }
        });
    }

    function dismissAlert($alert, alertId) {
        $alert.slideUp(300);
        App.Cookies.setItem('AlertDismissed-' + alertId, 'true', Infinity, '/', window.location.hostname, window.location.protocol === 'https:');
    }

    function alertDismissed(alertId) {
        return App.Cookies.getItem('AlertDismissed-' + alertId) === 'true' ? true : false;
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.Alert.init();
});