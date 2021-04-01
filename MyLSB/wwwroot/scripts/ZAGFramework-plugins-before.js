// Avoid `console` errors in browsers that lack a console.
(function () {
    var method;
    var noop = function () { };
    var methods = [
        'assert', 'clear', 'count', 'debug', 'dir', 'dirxml', 'error',
        'exception', 'group', 'groupCollapsed', 'groupEnd', 'info', 'log',
        'markTimeline', 'profile', 'profileEnd', 'table', 'time', 'timeEnd',
        'timeStamp', 'trace', 'warn'
    ];
    var length = methods.length;
    var console = (window.console = window.console || {});

    while (length--) {
        method = methods[length];

        // Only stub undefined methods.
        if (!console[method]) {
            console[method] = noop;
        }
    }
}());

// Place any jQuery/helper plugins in here.
var ZAGFramework = ZAGFramework || {
    GetViewport: function () {
        var e = window, a = 'inner';
        if (!('innerWidth' in window)) {
            a = 'client';
            e = document.documentElement || document.body;
        }
        return { width: e[a + 'Width'], height: e[a + 'Height'] };
    },
    GetCurrentBP: function () {
        for (var key in this.BP) {
            if (key !== "compareArrays" && key !== "indexOf") {
                if (this.BP[key].matches) {
                    return key.toString();
                }
            }
        }
    },
    BP: {
        xs : window.matchMedia('(max-width: 575.98px)'),
        sm : window.matchMedia('(min-width: 576px) and (max-width: 767.98px)'),
        md : window.matchMedia('(min-width: 768px) and (max-width: 991.98px)'),
        lg : window.matchMedia('(min-width: 992px) and (max-width: 1199.98px)'),
        xl : window.matchMedia('(min-width: 1200px)')
    }
};