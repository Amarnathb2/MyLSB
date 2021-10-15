var App = App || {};

App.Speedbump = (function ($) {
    'use strict';

    var exclusions = Speedbump.exclusions,
        uriSchemes = ['javascript:', 'mailto:', 'tel:'];

    function init() {
        $('a').on('click', function (e) {
            var $this = $(this),
                url = $this.attr('href');

            if ($this.attr('id') === "sbModalSubmit") {
                e.preventDefault();

                window.open(url);
                $('#sbModal').modal('hide');
            }

            else if (this.hostname !== location.hostname
                && $.inArray(this.hostname, exclusions) === -1
                && url
                && url.indexOf('#') !== 0
                && !isUriSchema(url)) {

                e.preventDefault();
                $('#sbModal').modal('show');
                $('#sbModalSubmit').attr('href', url);
            }
        });
    }

    function isUriSchema(url) {
        for (var i in uriSchemes) {
            if (url.indexOf(uriSchemes[i]) > -1) {
                return true;
            }
        }
        return false;
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.Speedbump.init();
});