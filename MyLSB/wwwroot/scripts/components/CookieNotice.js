var App = App || {};

App.CookieNotice = (function ($) {
    'use strict';

    var $cookieNotice,
        transitionEnd = 'webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend';

    function init() {
        $cookieNotice = $('.cookie-notice');

        if ($cookieNotice.length && !noticeDismissed()) {
            $cookieNotice.on('click', '.cookie-notice__dismiss', function (e) {
                e.preventDefault();
                dismissNotice();
            });

            $cookieNotice.on(transitionEnd, '.cookie-notice__dismiss', function (e) {
                e.stopImmediatePropagation();
            });
        }
    }

    function dismissNotice() {
        $cookieNotice.addClass('cookie-notice--dismissed')
            .on(transitionEnd, function (e) {
                $cookieNotice.remove();
            });

        App.Cookies.setItem('CookieNoticeAccepted', 'true', Infinity, '/', window.location.hostname, window.location.protocol === 'https:');
    }

    function noticeDismissed() {
        return App.Cookies.getItem('CookieNoticeAccepted') === 'true' ? true : false;
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.CookieNotice.init();
});